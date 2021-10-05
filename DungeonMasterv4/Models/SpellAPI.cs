using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMasterv4.Models
{
    public class SpellAPI
    {
        public class Rootobject
        {
            public string index { get; set; }
            public string name { get; set; }
            public string[] desc { get; set; }
            public string range { get; set; }
            public string[] components { get; set; }
            public bool ritual { get; set; }
            public string duration { get; set; }
            public bool concentration { get; set; }
            public string casting_time { get; set; }
            public int level { get; set; }
            public Damage damage { get; set; }
            public Dc dc { get; set; }
            public School school { get; set; }
            public Class2[] classes { get; set; }
            public Subclass[] subclasses { get; set; }
            public string url { get; set; }
            public string[] higher_level { get; set; }
            public string material { get; set; }
            public Heal_At_Slot_Level heal_at_slot_level { get; set; }
            public Area_Of_Effect area_of_effect { get; set; }
            public string attack_type { get; set; }
        }

        public class Damage
        {
            public Damage_Type damage_type { get; set; }
            public Damage_At_Character_Level damage_at_character_level { get; set; }
            public Damage_At_Slot_Level damage_at_slot_level { get; set; }
        }

        public class Damage_Type
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Damage_At_Character_Level
        {
            [JsonProperty("1")]
            public string _1 { get; set; }
            [JsonProperty("5")]
            public string _5 { get; set; }
            [JsonProperty("11")]
            public string _11 { get; set; }
            [JsonProperty("17")]
            public string _17 { get; set; }
        }

        public class Damage_At_Slot_Level
        {
            [JsonProperty("7")]
            public string _7 { get; set; }
            [JsonProperty("4")]
            public string _4 { get; set; }
            [JsonProperty("6")]
            public string _6 { get; set; }
            [JsonProperty("5")]
            public string _5 { get; set; }
            [JsonProperty("8")]
            public string _8 { get; set; }
            [JsonProperty("9")]
            public string _9 { get; set; }
            [JsonProperty("2")]
            public string _2 { get; set; }
            [JsonProperty("3")]
            public string _3 { get; set; }
            [JsonProperty("1")]
            public string _1 { get; set; }
        }

        public class Dc
        {
            public Dc_Type dc_type { get; set; }
            public string dc_success { get; set; }
            public string desc { get; set; }
        }

        public class Dc_Type
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class School
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Heal_At_Slot_Level
        {
            [JsonProperty("2")]
            public string _2 { get; set; }
            [JsonProperty("3")]
            public string _3 { get; set; }
            [JsonProperty("4")]
            public string _4 { get; set; }
            [JsonProperty("5")]
            public string _5 { get; set; }
            [JsonProperty("6")]
            public string _6 { get; set; }
            [JsonProperty("7")]
            public string _7 { get; set; }
            [JsonProperty("8")]
            public string _8 { get; set; }
            [JsonProperty("9")]
            public string _9 { get; set; }
            [JsonProperty("1")]
            public string _1 { get; set; }
        }

        public class Area_Of_Effect
        {
            public string type { get; set; }
            public int size { get; set; }
        }

        public class Class2
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Subclass
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

    }
}
