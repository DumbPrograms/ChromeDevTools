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
                Console.WriteLine($"Processing {Path.GetFileName(path)}..");

                var json = File.ReadAllText(path);
                var protocol = JsonConvert.DeserializeObject<ProtocolDescriptor>(json);

                using (var writer = File.CreateText($"{Path.GetFileNameWithoutExtension(path)}.g.cs"))
                {
                    new ProtocolCodeGenerator(writer).WriteProtocolCode(protocol);
                }
            }
        }
    }
}
