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

            WIL("namespace DumbPrograms.ChromeDevTools.Protocol");
            WILOpen();

            foreach (var domain in protocol.Domains)
            {
                WL();

                WILSummary(domain.Description);

                WIL($"namespace {domain.Name}");
                WILOpen();

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

                        WIL($"public class {type.Name}");
                        WILOpen();


                        WILClose();
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

                        var commandClassName = Char.ToUpperInvariant(command.Name[0]) + command.Name.Substring(1, command.Name.Length - 1);

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

                WILClose();
            }

            WILClose();

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
    }
}
