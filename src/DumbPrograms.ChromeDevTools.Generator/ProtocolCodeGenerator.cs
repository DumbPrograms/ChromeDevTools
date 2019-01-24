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
        }

        public void WriteProtocolCode(ProtocolDescriptor protocol)
        {
            WL();

            using (WILBlock("namespace DumbPrograms.ChromeDevTools.Protocol"))
            {
                foreach (var domain in protocol.Domains)
                {
                    WL();

                    WILSummary(domain.Description);

                    using (WILBlock($"namespace {domain.Name}"))
                    {
                        if (domain.Types != null)
                        {
                            foreach (var type in domain.Types)
                            {
                                WL();

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
                                        var csTypeName = GetCSharpTypeName(type.Type, type.ArrayType);
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
                                                    WIL($"public static {type.Name} {GetCSharpIdentifierName(value)} => new {type.Name}(\"{value}\");");
                                                }
                                            }
                                        }
                                        break;
                                    case JsonTypes.Object:
                                        using (WILBlock($"public class {type.Name}"))
                                        {

                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }

                        if (domain.Commands != null)
                        {
                            foreach (var command in domain.Commands)
                            {
                                WL();

                                WILSummary(command.Description);

                                if (command.Deprecated)
                                {
                                    WIL("[Obsolete]");
                                }

                                var commandClassName = GetCSharpIdentifierName(command.Name);

                                WI($"public class {commandClassName}Command : ICommand");

                                if (command.Returns != null)
                                {
                                    WL($"<{commandClassName}Response>");
                                }
                                else
                                {
                                    WL();
                                }

                                WILOpen();

                                WIL($"string ICommand.Name {{ get; }} = \"{domain.Name}.{command.Name}\";");

                                WILClose();

                                if (command.Returns != null)
                                {
                                    WL();
                                    WIL($"public class {commandClassName}Response");
                                    WILOpen();
                                    WILClose();
                                }
                            }
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

        string GetCSharpIdentifierName(string name)
            => String.Join("", name.Split('-', ' ').Select(n => Char.ToUpperInvariant(n[0]) + n.Substring(1, n.Length - 1)));

        string GetCSharpTypeName(JsonTypes jsonType, PropertyDescriptor arrayType)
        {
            switch (jsonType)
            {
                case JsonTypes.Any:
                    return "object";
                case JsonTypes.Boolean:
                    return "boolean";
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
                        return GetCSharpTypeName(arrayType.Type.Value, arrayType.ArrayType) + "[]";
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }
                case JsonTypes.Object:

                default:
                    throw new NotImplementedException();
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
