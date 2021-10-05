using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMasterv4.Models.EquipmentCat
{
    public class AdventuringGear
    {
        public class Rootobject
        {
            public string index { get; set; }
            public string name { get; set; }
            public Equipment[] equipment { get; set; }
            public string url { get; set; }
        }

        public class Equipment
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

    }
}
