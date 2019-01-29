using System;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace DumbPrograms.ChromeDevTools.Generator
{
    class InspectionClientApiGenerator : CodeGenerator
    {
        public void GenerateCode(TextWriter writer, ProtocolDescriptor protocol)
        {
            StartTextWriter(writer);

            WIL("using System;");
            WIL("using System.Threading;");
            WIL("using System.Threading.Tasks;");

            WL();

            using (WILBlock("namespace DumbPrograms.ChromeDevTools"))
            {
                const string InspectionClient = "InspectionClient";

                using (WILBlock($"partial class {InspectionClient}"))
                {
                    foreach (var domain in protocol.Domains)
                    {
                        WILSummary(domain.Description);

                        var fieldName = $"__{domain.Name}__";

                        WIL($"public {domain.Name}{InspectionClient} {domain.Name} => {fieldName} ?? ({fieldName} = new {domain.Name}{InspectionClient}(this));");
                        WIL($"private {domain.Name}{InspectionClient} {fieldName};");
                    }

                    foreach (var domain in protocol.Domains)
                    {
                        WL();

                        using (WILBlock($"public class {domain.Name}{InspectionClient}"))
                        {
                            WIL($"private readonly {InspectionClient} {InspectionClient};");

                            WL();

                            using (WILBlock($"public {domain.Name}{InspectionClient}({InspectionClient} inspectionClient)"))
                            {
                                WIL($"{InspectionClient} = inspectionClient;");
                            }

                            if (domain.Commands != null)
                            {
                                foreach (var command in domain.Commands)
                                {
                                    WILSummary(command.Description);

                                    if (command.Parameters != null)
                                    {
                                        foreach (var parameter in command.Parameters)
                                        {
                                            WILXmlDocElement(new XElement("param", new XAttribute("name", parameter.Name), parameter.Description));
                                        }
                                    }

                                    if (command.Deprecated)
                                    {
                                        WIL("[Obsolete]");
                                    }

                                    var commandName = GetCSharpIdentifier(command.Name);
                                    var commandType = $"Protocol.{domain.Name}.{commandName}Command";
                                    var commandResponseType = $"Protocol.{domain.Name}.{commandName}Response";
                                    var returnType = command.Returns == null ? "Task" : $"Task<{commandResponseType}>";

                                    WIL($"public {returnType} {commandName}");
                                    using (WILBlock(blockType: BlockType.Brace))
                                    {
                                        WILParameters(domain.Name, command.Parameters);
                                    }
                                    using (WILBlock())
                                    {
                                        using (WILBlock($"return {InspectionClient}.InvokeCommand", BlockType.Brace))
                                        {
                                            using (WILBlock($"new {commandType}"))
                                            {
                                                if (command.Parameters != null)
                                                {
                                                    foreach (var parameter in command.Parameters)
                                                    {
                                                        WIL($"{GetCSharpIdentifier(parameter.Name)} = @{parameter.Name},");
                                                    }
                                                }

                                            }

                                            WIL(", cancellation");
                                        }
                                        WIL($";");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void WILParameters(string domain, PropertyDescriptor[] parameters)
        {
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    string csType;
                    if (parameter.Type != null)
                    {
                        csType = GetCSharpType(parameter.Type.Value, parameter.Optional, parameter.ArrayType);

                        var typeRef = parameter.ArrayType?.TypeReference;
                        if (parameter.Type == JsonTypes.Array && typeRef != null)
                        {
                            csType = $"Protocol.{(typeRef.Contains(".") ? "" : $"{domain}.")}{csType}";
                        }
                    }
                    else if (parameter.TypeReference != null)
                    {
                        var typeRef = parameter.TypeReference;
                        csType = $"Protocol.{(typeRef.Contains(".") ? "" : $"{domain}.")}{typeRef}";
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }

                    WIL($"{csType} @{parameter.Name}{(parameter.Optional ? " = default" : "" )}, ");
                }
            }

            WIL("CancellationToken cancellation = default");
        }
    }
}
