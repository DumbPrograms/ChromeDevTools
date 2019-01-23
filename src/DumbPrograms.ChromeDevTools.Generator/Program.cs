using System;
using System.IO;
using Newtonsoft.Json;

namespace DumbPrograms.ChromeDevTools.Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var path in Directory.EnumerateFiles(Environment.CurrentDirectory, "*.json"))
            {
                var filename = Path.GetFileName(path);
                Console.WriteLine($"Processing {filename}..");

                var json = File.ReadAllText(path);
                var protocol = JsonConvert.DeserializeObject<ProtocolDescriptor>(json);

                using (var writer = File.CreateText(filename + ".cs"))
                {
                    new ProtocolCodeGenerator(writer).WriteProtocolCode(protocol);
                }
            }
        }
    }
}
