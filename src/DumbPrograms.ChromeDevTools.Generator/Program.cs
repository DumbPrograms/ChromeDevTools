using System;
using System.Linq;
using System.Collections.Generic;
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

            var descriptors = new List<(string filename, ProtocolDescriptor protocol)>();
            var aliasTypes = new HashSet<string>();

            Console.WriteLine($"Parsing json files..");

            foreach (var path in Directory.EnumerateFiles(workingDir, "*.json"))
            {
                var filename = Path.GetFileName(path);
                var jsonText = File.ReadAllText(path);
                var settings = new JsonSerializerSettings
                {
                    MetadataPropertyHandling = MetadataPropertyHandling.Ignore
                };
                var protocol = JsonConvert.DeserializeObject<ProtocolDescriptor>(jsonText, settings);

                descriptors.Add((filename, protocol));
            }

            Console.WriteLine("Collecting alias types..");

            foreach (var descriptor in descriptors)
            {
                aliasTypes.UnionWith(from domain in descriptor.protocol.Domains
                                     where domain.Types != null
                                     from type in domain.Types
                                     where type.Type != JsonTypes.Object
                                     select $"{domain.Name}.{type.Name}");
            }

            Console.WriteLine("Generating mapping types..");

            foreach (var (filename, protocol) in descriptors)
            {
                using (var writer = File.CreateText(Path.Combine(workingDir, filename + ".cs")))
                {
                    new MappingTypesGenerator(aliasTypes).WriteProtocolCode(writer, protocol);
                }
            }

        }
    }
}
