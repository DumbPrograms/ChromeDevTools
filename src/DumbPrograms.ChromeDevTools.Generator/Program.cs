using System;
using System.IO;
using Newtonsoft.Json;

namespace DumbPrograms.ChromeDevTools.Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            var workingDir = Environment.CurrentDirectory;
            if (args?.Length > 0)
            {
                workingDir = Path.Combine(Environment.CurrentDirectory, args[0]);
            }

            foreach (var path in Directory.EnumerateFiles(workingDir, "*.json"))
            {
                var filename = Path.GetFileName(path);
                Console.WriteLine($"Processing {filename}..");

                var json = File.ReadAllText(path);
                var protocol = JsonConvert.DeserializeObject<ProtocolDescriptor>(json);

                using (var writer = File.CreateText(Path.Combine(workingDir, filename + ".cs")))
                {
                    new ProtocolCodeGenerator(writer).WriteProtocolCode(protocol);
                }
            }
        }
    }
}
