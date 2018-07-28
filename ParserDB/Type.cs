using System;
using System.Collections.Generic;
using System.Text;

namespace ParserDB
{
    public class TypeItem
    {
        public float Capacity { get; set; }
        public int BasePrice { get; set; }
        public NameType Description { get; set; }
        public int FactionID { get; set; }
        public int GraphicID { get; set; }
        public int GroupID { get; set; }
        public double Mass { get; set; }
        public int IconID { get; set; }
        public int MarketGroupID { get; set; }
        public NameType Name { get; set; }
        public int PortionSize { get; set; }
        public bool Published { get; set; }
        public int RaceID { get; set; }
        public float Radius { get; set; }
        public string SofFactionName { get; set; }
        public int SoundID { get; set; }
        public TraitsType Traits { get; set; }
        public float Volume { get; set; }
    }

    public class NameType
    {
        public string en { get; set; }
        public string ru { get; set; }
    }

    public class TraitsType
    {
        public List<RoleBonusesType> RoleBonuses;
        public Dictionary<int, RoleBonusesType> Types;
    }

    public class RoleBonusesType
    {
        public int Bonus { get; set; }
        public NameType BonusText { get; set; }
        public int Importance { get; set; }
        public int UnitID { get; set; }
    }

    public class RoleBonusesListType
    {
        public List<RoleBonusesType> Bonus { get; set; }
    }
}

