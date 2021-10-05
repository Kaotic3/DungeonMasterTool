using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DungeonMasterv4.Models
{
    public class ArmourSingle
    {

        public class Rootobject
        {
            public string index { get; set; }
            public string name { get; set; }
            public Equipment_Category equipment_category { get; set; }
            public string armor_category { get; set; }
            public Armor_Class armor_class { get; set; }
            public int str_minimum { get; set; }
            public bool stealth_disadvantage { get; set; }
            public int weight { get; set; }
            public Cost cost { get; set; }
            public string url { get; set; }
        }

        public class Equipment_Category
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
            public object max_bonus { get; set; }
        }

        public class Cost
        {
            public int quantity { get; set; }
            public string unit { get; set; }
        }


    }
}
