using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace ParserDB
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
}
