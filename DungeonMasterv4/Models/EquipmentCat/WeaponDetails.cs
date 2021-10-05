using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMasterv4.Models.EquipmentCat
{
    public class WeaponDetails
    {


        public class Rootobject
        {
            public string index { get; set; }
            public string name { get; set; }
            public Equipment_Category equipment_category { get; set; }
            public string[] desc { get; set; }
            public string url { get; set; }
        }

        public class Equipment_Category
        {
            public string index { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }


    }
}
