﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Console_Write_YAML
{
    public class Blueprint
    {
        public Activities Activities { get; set; }
        public int BlueprintTypeID { get; set; }
        public int MaxProductionLimit { get; set; }
    }

    public class Activities
    {
        public ActivityReaction Reaction { get; set; }
        public ActivityCopy Copying { get; set; }
        public ActivityInvenion Invention { get; set; }
        public ActivityManufacturing Manufacturing { get; set; }
        [YamlMember(Alias = "research_material", ApplyNamingConventions = false)]
        public ActivityRM ResearchMaterial { get; set; }
        [YamlMember(Alias = "research_time", ApplyNamingConventions = false)]
        public ActivityRT ResearchTime { get; set; }
    }

    public abstract class ActivityBase<T>
    {
        public List<Material> Materials { get; set; }
        public List<T> Products { get; set; }
        public List<Skill> Skills { get; set; }
        public int Time { get; set; }
    }

    public class ActivityCopy : ActivityBase<Material> { }

    public class ActivityReaction : ActivityBase<Material> { }

    public class ActivityInvenion : ActivityBase<InventionProduct> { }

    public class ActivityManufacturing : ActivityBase<Material> { }

    public class ActivityRM : ActivityBase<Material> { }

    public class ActivityRT : ActivityBase<Material> { }

    public class Material
    {
        public int Quantity { get; set; }
        public int TypeID { get; set; }
    }

    public class InventionProduct
    {
        public float Probability { get; set; }
        public int Quantity { get; set; }
        public int TypeID { get; set; }
    }

    public class Skill
    {
        public int Level { get; set; }
        public int TypeID { get; set; }
    }

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

            Console.WriteLine("Результат:"+bps[681].BlueprintTypeID);
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
