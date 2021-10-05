using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMasterv4.Models
{
    public class ConditionsAPI
    {
        public class Rootobject
        {
            public string index { get; set; }
            public string name { get; set; }
            public string[] desc { get; set; }
            public string url { get; set; }
        }

    }
}
