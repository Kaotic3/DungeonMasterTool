using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMasterv4.Models
{
    public class MonsterAPI
    {
        public class Rootobject
        {
            public string index { get; set; }
            public string name { get; set; }
            public string size { get; set; }
            public string type { get; set; }
            public string subtype { get; set; }
            public string alignment { get; set; }
            public int armor_class { get; set; }
            public int hit_points { get; set; }
            public string hit_dice { get; set; }
            public Speed speed { get; set; }
            public int strength { get; set; }
            public int dexterity { get; set; }
            public int constitution { get; set; }
            public int intelligence { get; set; }
            public int wisdom { get; set; }
            public int charisma { get; set; }
            public Proficiency[] proficiencies { get; set; }
            public string[] damage_vulnerabilities { get; set; }
            public string[] damage_resistances { get; set; }
            public string[] damage_immunities { get; set; }
            public Condition_Immunities[] condition_immunities { get; set; }
            public Senses senses { get; set; }
            public string languages { get; set; }
            public float challenge_rating { get; set; }
            public int xp { get; set; }
            public Special_Abilities[] special_abilities { get; set; }
            public Action[] actions { get; set; }
            public string url { get; set; }
            public Legendary_Actions[] legendary_actions { get; set; }
            public Reaction[] reactions { get; set; }
            public Form[] forms { get; set; }
        }

        public class Speed
        {
            public string walk { get; set; }
            public string fly { get; set; }
            public string swim { get; set; }
            public string burrow { get; set; }
            public string climb { get; set; }
            public bool hover { get; set; }
        }

        public class Senses
        {
            public int passive_perception { get; set; }
            public string blindsight { get; set; }
            public string darkvision { get; set; }
            public string truesight { get; set; }
            public string tremorsense { get; set; }
        }

        public class Proficiency
        {
            public Proficiency1 proficiency { get; set; }
            public int value { get; set; }
        }

        public class Proficiency1
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Condition_Immunities
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Special_Abilities
        {
            public string name { get; set; }
            public string desc { get; set; }
            public Spellcasting spellcasting { get; set; }
            public Usage1 usage { get; set; }
            public Damage[] damage { get; set; }
            public Dc dc { get; set; }
            public int attack_bonus { get; set; }
        }

        public class Spellcasting
        {
            public int level { get; set; }
            public Ability ability { get; set; }
            public int dc { get; set; }
            public int modifier { get; set; }
            public string[] components_required { get; set; }
            public string school { get; set; }
            public Slots slots { get; set; }
            public Spell[] spells { get; set; }
        }

        public class Ability
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Slots
        {
            [JsonProperty("1")]
            public int _1 { get; set; }
            [JsonProperty("2")]
            public int _2 { get; set; }
            [JsonProperty("3")]
            public int _3 { get; set; }
            [JsonProperty("4")]
            public int _4 { get; set; }
            [JsonProperty("5")]
            public int _5 { get; set; }
            [JsonProperty("6")]
            public int _6 { get; set; }
            [JsonProperty("7")]
            public int _7 { get; set; }
            [JsonProperty("8")]
            public int _8 { get; set; }
            [JsonProperty("9")]
            public int _9 { get; set; }
        }

        public class Spell
        {
            public string name { get; set; }
            public int level { get; set; }
            public string url { get; set; }
            public Usage usage { get; set; }
            public string notes { get; set; }
        }

        public class Usage
        {
            public string type { get; set; }
            public int times { get; set; }
        }

        public class Usage1
        {
            public string type { get; set; }
            public int times { get; set; }
            public string[] rest_types { get; set; }
        }

        public class Dc
        {
            public Dc_Type dc_type { get; set; }
            public int dc_value { get; set; }
            public string success_type { get; set; }
        }

        public class Dc_Type
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Damage
        {
            public Damage_Type damage_type { get; set; }
            public string damage_dice { get; set; }
        }

        public class Damage_Type
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Action
        {
            public string name { get; set; }
            public string desc { get; set; }
            public int attack_bonus { get; set; }
            public Damage2[] damage { get; set; }
            public Options options { get; set; }
            public Dc1 dc { get; set; }
            public Usage2 usage { get; set; }
            public Attack_Options attack_options { get; set; }
            public Attack[] attacks { get; set; }
            public string damage_dice { get; set; }
        }

        public class Options
        {
            public int choose { get; set; }
            public From[][] from { get; set; }
        }

        public class From
        {
            public string name { get; set; }
            public object count { get; set; }
            public string type { get; set; }
            public string notes { get; set; }
        }

        public class Dc1
        {
            public Dc_Type1 dc_type { get; set; }
            public int dc_value { get; set; }
            public string success_type { get; set; }
        }

        public class Dc_Type1
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Usage2
        {
            public string type { get; set; }
            public string dice { get; set; }
            public int min_value { get; set; }
            public int times { get; set; }
            public string[] rest_types { get; set; }
        }

        public class Attack_Options
        {
            public int choose { get; set; }
            public string type { get; set; }
            public From1[] from { get; set; }
        }

        public class From1
        {
            public string name { get; set; }
            public Dc2 dc { get; set; }
            public Damage1[] damage { get; set; }
        }

        public class Dc2
        {
            public Dc_Type2 dc_type { get; set; }
            public int dc_value { get; set; }
            public string success_type { get; set; }
        }

        public class Dc_Type2
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Damage1
        {
            public Damage_Type1 damage_type { get; set; }
            public string damage_dice { get; set; }
        }

        public class Damage_Type1
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Damage2
        {
            public Damage_Type2 damage_type { get; set; }
            public string damage_dice { get; set; }
            public Dc3 dc { get; set; }
            public int choose { get; set; }
            public string type { get; set; }
            public From2[] from { get; set; }
        }

        public class Damage_Type2
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Dc3
        {
            public Dc_Type3 dc_type { get; set; }
            public int dc_value { get; set; }
            public string success_type { get; set; }
        }

        public class Dc_Type3
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class From2
        {
            public Damage_Type3 damage_type { get; set; }
            public string damage_dice { get; set; }
        }

        public class Damage_Type3
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Attack
        {
            public string name { get; set; }
            public Dc4 dc { get; set; }
            public Damage3[] damage { get; set; }
        }

        public class Dc4
        {
            public Dc_Type4 dc_type { get; set; }
            public int dc_value { get; set; }
            public string success_type { get; set; }
        }

        public class Dc_Type4
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Damage3
        {
            public Damage_Type4 damage_type { get; set; }
            public string damage_dice { get; set; }
        }

        public class Damage_Type4
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Legendary_Actions
        {
            public string name { get; set; }
            public string desc { get; set; }
            public Dc5 dc { get; set; }
            public Damage4[] damage { get; set; }
            public int attack_bonus { get; set; }
        }

        public class Dc5
        {
            public Dc_Type5 dc_type { get; set; }
            public int dc_value { get; set; }
            public string success_type { get; set; }
        }

        public class Dc_Type5
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Damage4
        {
            public Damage_Type5 damage_type { get; set; }
            public string damage_dice { get; set; }
        }

        public class Damage_Type5
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Reaction
        {
            public string name { get; set; }
            public string desc { get; set; }
            public Dc6 dc { get; set; }
        }

        public class Dc6
        {
            public Dc_Type6 dc_type { get; set; }
            public int dc_value { get; set; }
            public string success_type { get; set; }
        }

        public class Dc_Type6
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Form
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }



    }
}
