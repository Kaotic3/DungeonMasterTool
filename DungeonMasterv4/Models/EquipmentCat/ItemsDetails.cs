using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMasterv4.Models.EquipmentCat
{
    public class ItemsDetails
    {
        public class Rootobject
        {
            public string index { get; set; }
            public string name { get; set; }
            public Equipment_Category equipment_category { get; set; }
            public string[] desc { get; set; }
            public Gear_Category gear_category { get; set; }
            public string armor_category { get; set; }
            public Armor_Class armor_class { get; set; }
            public int str_minimum { get; set; }
            public bool stealth_disadvantage { get; set; }
            public string weapon_category { get; set; }
            public string weapon_range { get; set; }
            public string category_range { get; set; }
            public Cost cost { get; set; }
            public Damage damage { get; set; }
            public Range range { get; set; }
            public float weight { get; set; }
            public Property1[] properties { get; set; }
            public string url { get; set; }
        }
        public class Equipment_Category
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }
        public class Cost
        {
            public float quantity { get; set; }
            public string unit { get; set; }
        }
        public class Gear_Category
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }
        public class Damage
        {
            public string damage_dice { get; set; }
            public Damage_Type damage_type { get; set; }
        }
        public class Damage_Type
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }
        public class Range
        {
            public int normal { get; set; }
            [JsonProperty("long")]
            public object _long { get; set; }
        }
        public class Property1
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }
        public class Armor_Class
        {
            [JsonProperty("base")]
            public int _base { get; set; }
            public bool dex_bonus { get; set; }
            public int max_bonus { get; set; }
        }

    }
}
