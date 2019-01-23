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

            WL("using System;");
        }

        public void WriteProtocolCode(ProtocolDescriptor protocol)
        {
            foreach (var domain in protocol.Domains)
            {
                WL();

                WLSummary(domain.Description);

                WL($"namespace DumbPrograms.ChromeDevTools.Protocol.{domain.Domain}");
                WLOpen();

                if (domain.Types != null)
                {
                    foreach (var type in domain.Types)
                    {
                        WL();

                        WLSummary(type.Description);

                        if (type.Deprecated)
                        {
                            WL("[Obsolete]");
                        }

                        WL($"public class {type.Name}");
                        WLOpen();


                        WLClose();
                    }
                }

                if (domain.Commands != null)
                {
                    foreach (var command in domain.Commands)
                    {
                        WL();

                        WLSummary(command.Description);

                        if (command.Deprecated)
                        {
                            WL("[Obsolete]");
                        }

                        WL($"public class {command.Name}Command");
                        WLOpen();
                        WLClose();
                    }
                }

                WLClose();
            }

            Writer.Flush();
        }

        void WL()
        {
            Writer.WriteLine();
        }

        void WL(string line)
        {
            for (int i = 0; i < Indent; i++)
            {
                Writer.Write("    ");
            }

            Writer.WriteLine(line);
        }

        void WLOpen()
        {
            WL("{");
            Indent++;
        }

        void WLClose()
        {
            Indent--;
            WL("}");
        }

        private void WLSummary(string description)
        {
            if (String.IsNullOrWhiteSpace(description))
            {
                return;
            }

            var xml = new XElement("summary", Environment.NewLine + description + Environment.NewLine).ToString();
            foreach (var line in xml.Split(Environment.NewLine))
            {
                WL("/// " + line);
            }
        }
    }
}
