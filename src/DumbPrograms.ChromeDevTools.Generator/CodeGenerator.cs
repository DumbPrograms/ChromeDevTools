using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace DumbPrograms.ChromeDevTools.Generator
{
    abstract class CodeGenerator
    {
        protected int Indent { get; set; }
        protected TextWriter Writer { get; set; }

        protected void StartTextWriter(TextWriter writer)
        {
            Indent = 0;
            Writer = writer;
        }

        protected void W(string content)
        {
            Writer.Write(content);
        }

        protected void WL()
        {
            Writer.WriteLine();
        }

        protected void WL(string line)
        {
            Writer.WriteLine(line);
        }

        protected void WI()
        {
            for (int i = 0; i < Indent; i++)
            {
                W("    ");
            }
        }

        protected void WI(string content)
        {
            WI();
            W(content);
        }

        protected void WIL(string line)
        {
            WI();
            WL(line);
        }

        protected void WILOpen()
        {
            WIL("{");
            Indent++;
        }

        protected void WILClose()
        {
            Indent--;
            WIL("}");
        }

        protected void WILSummary(string description)
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

        protected string GetCSharpIdentifier(string name)
            => String.Join("", name.Split('_', '-', ' ').Select(n => Char.ToUpperInvariant(n[0]) + n.Substring(1, n.Length - 1)));

        protected string GetCSharpType(JsonTypes jsonType, bool optional, PropertyDescriptor arrayType)
        {
            switch (jsonType)
            {
                case JsonTypes.Any:
                case JsonTypes.Object:
                    return "object";
                case JsonTypes.Boolean:
                    return optional ? "bool?" : "bool";
                case JsonTypes.Integer:
                    return optional ? "int?" : "int";
                case JsonTypes.Number:
                    return optional ? "double?" : "double";
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
                        return GetCSharpType(arrayType.Type.Value, arrayType.Optional, arrayType.ArrayType) + "[]";
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }
                default:
                    throw new UnreachableCodeReachedException();
            }
        }

        protected BlockStructureWriter WILBlock(string header) => new BlockStructureWriter(this, header);

        internal class BlockStructureWriter : IDisposable
        {
            private readonly CodeGenerator Generator;

            public BlockStructureWriter(CodeGenerator generator, string header)
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
