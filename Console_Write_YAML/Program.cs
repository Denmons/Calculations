using System;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Console_Write_YAML
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine("sde", "fsd", "blueprints.yaml");

            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(new CamelCaseNamingConvention())
                .Build();

            var fs = new FileStream(path, FileMode.Open, FileAccess.Read);

            var bps = deserializer.Deserialize<Dictionary<int, Blueprint>>(new StreamReader(fs));

            fs.Close();

            Console.WriteLine("Результат:" + bps[681].BlueprintTypeID);
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
