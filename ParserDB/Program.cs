using System;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ParserDB
{
    class Program
    {
        static void Main(string[] args)
        {
            //var pathBlueprints = Path.Combine("sde", "fsd", "blueprints.yaml");
            var pathTypeid = Path.Combine("sde", "fsd", "typeIDs.yaml");

            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(new CamelCaseNamingConvention())
                .IgnoreUnmatchedProperties()
                .Build();

            //var fs = new FileStream(pathBlueprints, FileMode.Open, FileAccess.Read);
            var fs = new FileStream(pathTypeid, FileMode.Open, FileAccess.Read);
            var fs_stream = new StreamReader(fs);

            //var bps = deserializer.Deserialize<Dictionary<int, Blueprint>>(new StreamReader(fs));
            var tps = deserializer.Deserialize<Dictionary<int, TypeItem>>(fs_stream);

            fs.Close();

            // Console.WriteLine("Результат:" + bps[681].BlueprintTypeID);
            Console.WriteLine("Результат:" + tps[582].Name.Ru);
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
