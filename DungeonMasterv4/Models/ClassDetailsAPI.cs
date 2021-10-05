using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMasterv4.Models
{
    public class ClassDetailsAPI
    {
        public class Rootobject
        {
            public string index { get; set; }
            public string name { get; set; }
            public int hit_die { get; set; }
            public Proficiency_Choices1[] proficiency_choices { get; set; }
            public Proficiency1[] proficiencies { get; set; }
            public Saving_Throws[] saving_throws { get; set; }
            public Starting_Equipment[] starting_equipment { get; set; }
            public Starting_Equipment_Options[] starting_equipment_options { get; set; }
            public string class_levels { get; set; }
            public Multi_Classing multi_classing { get; set; }
            public Subclass[] subclasses { get; set; }
            public Spellcasting spellcasting { get; set; }
            public string spells { get; set; }
            public string url { get; set; }
        }

        public class Multi_Classing
        {
            public Prerequisite[] prerequisites { get; set; }
            public Proficiency[] proficiencies { get; set; }
            public Proficiency_Choices[] proficiency_choices { get; set; }
            public Prerequisite_Options prerequisite_options { get; set; }
        }

        public class Prerequisite_Options
        {
            public string type { get; set; }
            public int choose { get; set; }
            public From[] from { get; set; }
        }

        public class From
        {
            public Ability_Score ability_score { get; set; }
            public int minimum_score { get; set; }
        }

        public class Ability_Score
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Prerequisite
        {
            public Ability_Score1 ability_score { get; set; }
            public int minimum_score { get; set; }
        }

        public class Ability_Score1
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Proficiency
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Proficiency_Choices
        {
            public int choose { get; set; }
            public string type { get; set; }
            public From1[] from { get; set; }
        }

        public class From1
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Spellcasting
        {
            public int level { get; set; }
            public Spellcasting_Ability spellcasting_ability { get; set; }
            public Info[] info { get; set; }
        }

        public class Spellcasting_Ability
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Info
        {
            public string[] desc { get; set; }
            public string name { get; set; }
        }

        public class Proficiency_Choices1
        {
            public int choose { get; set; }
            public string type { get; set; }
            public From2[] from { get; set; }
        }

        public class From2
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Proficiency1
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Saving_Throws
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Starting_Equipment
        {
            public Equipment equipment { get; set; }
            public int quantity { get; set; }
        }

        public class Equipment
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Starting_Equipment_Options
        {
            public int choose { get; set; }
            public string type { get; set; }
            public From3[] from { get; set; }
        }

        public class From3
        {
            public Equipment1 equipment { get; set; }
            public int quantity { get; set; }
            public Equipment_Option equipment_option { get; set; }
            public Prerequisite1[] prerequisites { get; set; }
            [JsonProperty("0")]
            public _0 _0 { get; set; }
            [JsonProperty("1")]
            public _1 _1 { get; set; }
            public Equipment_Category2 equipment_category { get; set; }
            [JsonProperty("2")]
            public _2 _2 { get; set; }
        }

        public class Equipment1
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Equipment_Option
        {
            public int choose { get; set; }
            public string type { get; set; }
            public From4 from { get; set; }
        }

        public class From4
        {
            public Equipment_Category equipment_category { get; set; }
        }

        public class Equipment_Category
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class _0
        {
            public Equipment2 equipment { get; set; }
            public int quantity { get; set; }
        }

        public class Equipment2
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class _1
        {
            public Equipment3 equipment { get; set; }
            public int quantity { get; set; }
            public Equipment_Option1 equipment_option { get; set; }
        }

        public class Equipment3
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Equipment_Option1
        {
            public int choose { get; set; }
            public string type { get; set; }
            public From5 from { get; set; }
        }

        public class From5
        {
            public Equipment_Category1 equipment_category { get; set; }
        }

        public class Equipment_Category1
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Equipment_Category2
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }
        public class _2
        {
            public Equipment4 equipment { get; set; }
            public int quantity { get; set; }
        }

        public class Equipment4
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Prerequisite1
        {
            public string type { get; set; }
            public Proficiency2 proficiency { get; set; }
        }

        public class Proficiency2
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
