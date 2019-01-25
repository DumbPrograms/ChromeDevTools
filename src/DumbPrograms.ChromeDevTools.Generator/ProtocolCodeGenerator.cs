using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace DumbPrograms.ChromeDevTools.Generator
{
    class ProtocolCodeGenerator
    {
        int Indent;
        readonly TextWriter Writer;

        public ProtocolCodeGenerator(TextWriter writer)
        {
            Indent = 0;
            Writer = writer;

            WIL("using System;");
            WIL("using System.Collections.Generic;");
            WIL("using Newtonsoft.Json;");
        }

        public void WriteProtocolCode(ProtocolDescriptor protocol)
        {
            WL();

            using (WILBlock("namespace DumbPrograms.ChromeDevTools.Protocol"))
            {
                foreach (var domain in protocol.Domains)
                {
                    WILSummary(domain.Description);

                    using (WILBlock($"namespace {domain.Name}"))
                    {
                        if (domain.Types != null)
                        {
                            WL();
                            WIL("#region Types");

                            foreach (var type in domain.Types)
                            {
                                WILSummary(type.Description);

                                if (type.Deprecated)
                                {
                                    WIL("[Obsolete]");
                                }

                                switch (type.Type)
                                {
                                    case JsonTypes.Any:
                                    case JsonTypes.Boolean:
                                    case JsonTypes.Integer:
                                    case JsonTypes.Number:
                                    case JsonTypes.Array:
                                    case JsonTypes.String:
                                        var csTypeName = GetCSharpType(type.Type, type.ArrayType);
                                        using (WILBlock($"public struct {type.Name} : I{(type.EnumValues != null ? "Enum" : $"Alias<{csTypeName}>")}"))
                                        {

                                            WIL($"public {csTypeName} Value {{ get; private set; }}");

                                            WL();

                                            using (WILBlock($"public {type.Name}({csTypeName} value)"))
                                            {
                                                WIL("Value = value;");
                                            }

                                            WL();

                                            if (type.EnumValues != null)
                                            {
                                                foreach (var value in type.EnumValues)
                                                {
                                                    WIL($"public static {type.Name} {GetCSharpIdentifier(value)} => new {type.Name}(\"{value}\");");
                                                }
                                            }
                                        }
                                        break;
                                    case JsonTypes.Object:
                                        using (WILBlock($"public class {type.Name}{(type.Properties == null ? " : Dictionary<string, object>" : "")}"))
                                        {
                                            WILProperties(type.Properties);
                                        }
                                        break;
                                    default:
                                        throw new UnreachableCodeReachedException();
                                }
                            }

                            WL();
                            WIL("#endregion");
                        }

                        if (domain.Commands != null)
                        {
                            WL();
                            WIL("#region Commands");

                            foreach (var command in domain.Commands)
                            {
                                WILSummary(command.Description);

                                if (command.Deprecated)
                                {
                                    WIL("[Obsolete]");
                                }

                                var commandClassName = GetCSharpIdentifier(command.Name);
                                var commandInterface = "ICommand";
                                if (command.Returns != null)
                                {
                                    commandInterface += $"<{commandClassName}Response>";
                                }

                                using (WILBlock($"public class {commandClassName}Command : {commandInterface}"))
                                {
                                    WIL($"string ICommand.Name {{ get; }} = \"{domain.Name}.{command.Name}\";");

                                    WILProperties(command.Parameters);
                                }

                                if (command.Returns != null)
                                {
                                    WL();
                                    using (WILBlock($"public class {commandClassName}Response"))
                                    {
                                        WILProperties(command.Returns);
                                    }
                                }
                            }

                            WL();
                            WIL("#endregion");
                        }

                        if (domain.Events != null)
                        {
                            WL();
                            WIL("#region Events");

                            foreach (var @event in domain.Events)
                            {
                                WILSummary(@event.Description);

                                if (@event.Deprecated)
                                {
                                    WIL("[Obsolete]");
                                }

                                using (WILBlock($"public class {GetCSharpIdentifier(@event.Name)}Event : ICommand"))
                                {
                                    WIL($"string ICommand.Name {{ get; }} = \"{domain.Name}.{@event.Name}\";");

                                    WILProperties(@event.Parameters);
                                }
                            }

                            WL();
                            WIL("#endregion");
                        }
                    }
                }
            }

            Writer.Flush();
        }

        void W(string content)
        {
            Writer.Write(content);
        }

        void WL()
        {
            Writer.WriteLine();
        }

        void WL(string line)
        {
            Writer.WriteLine(line);
        }

        void WI()
        {
            for (int i = 0; i < Indent; i++)
            {
                W("    ");
            }
        }

        void WI(string content)
        {
            WI();
            W(content);
        }

        void WIL(string line)
        {
            WI();
            Writer.WriteLine(line);
        }

        void WILOpen()
        {
            WIL("{");
            Indent++;
        }

        void WILClose()
        {
            Indent--;
            WIL("}");
        }

        void WILSummary(string description)
        {
            WL();

            if (String.IsNullOrWhiteSpace(description))
            {
                return;
            }

            var xml = new XElement("summary", Environment.NewLine + description + Environment.NewLine).ToString();
            foreach (var line in xml.Split(Environment.NewLine))
            {
                WIL("/// " + line);
            }
        }

        BlockStructureWriter WILBlock(string header) => new BlockStructureWriter(this, header);

        void WILProperties(PropertyDescriptor[] properties)
        {
            if (properties != null)
            {
                foreach (var property in properties)
                {
                    string csPropType;
                    if (property.Type != null)
                    {
                        csPropType = GetCSharpType(property.Type.Value, property.ArrayType);
                    }
                    else if (property.TypeReference != null)
                    {
                        csPropType = property.TypeReference;
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }

                    WILSummary(property.Description);
                    WIL($"[JsonProperty(\"{property.Name}\")]");
                    WIL($"public {csPropType} {GetCSharpIdentifier(property.Name)} {{ get; set; }}");
                }
            }
        }

        string GetCSharpIdentifier(string name)
            => String.Join("", name.Split('_', '-', ' ').Select(n => Char.ToUpperInvariant(n[0]) + n.Substring(1, n.Length - 1)));

        string GetCSharpType(JsonTypes jsonType, PropertyDescriptor arrayType)
        {
            switch (jsonType)
            {
                case JsonTypes.Any:
                case JsonTypes.Object:
                    return "object";
                case JsonTypes.Boolean:
                    return "bool";
                case JsonTypes.Integer:
                    return "int";
                case JsonTypes.Number:
                    return "double";
                case JsonTypes.String:
                    return "string";
                case JsonTypes.Array:
                    if (arrayType == null)
                    {
                        return "Array";
                    }
                    else if (arrayType.TypeReference != null)
                    {
                        return arrayType.TypeReference + "[]";
                    }
                    else if (arrayType.Type != null)
                    {
                        return GetCSharpType(arrayType.Type.Value, arrayType.ArrayType) + "[]";
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }
                default:
                    throw new UnreachableCodeReachedException();
            }
        }

        class BlockStructureWriter : IDisposable
        {
            private readonly ProtocolCodeGenerator Generator;

            public BlockStructureWriter(ProtocolCodeGenerator generator, string header)
            {
                Generator = generator;

                generator.WIL(header);
                generator.WILOpen();
            }

            public void Dispose()
            {
                Generator.WILClose();
            }
        }
    }
}
