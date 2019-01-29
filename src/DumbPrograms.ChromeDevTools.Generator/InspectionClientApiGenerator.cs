using System.IO;

namespace DumbPrograms.ChromeDevTools.Generator
{
    class InspectionClientApiGenerator : CodeGenerator
    {
        public void GenerateCode(TextWriter writer, ProtocolDescriptor protocol)
        {
            StartTextWriter(writer);

            WIL("using System;");
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

                                    var commandName = GetCSharpIdentifier(command.Name);
                                    var commandType = $"Protocol.{domain.Name}.{commandName}Command";
                                    var commandResponseType = $"Protocol.{domain.Name}.{commandName}Response";
                                    var returnType = command.Returns == null ? "Task" : $"Task<{commandResponseType}>";

                                    using (WILBlock($"public {returnType} {commandName}()"))
                                    {
                                        WIL("throw new NotImplementedException();");
                                        // WIL($"return {InspectionClient}.InvokeCommand<{commandType}, {commandResponseType}>(new {commandType} {{ }});");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
