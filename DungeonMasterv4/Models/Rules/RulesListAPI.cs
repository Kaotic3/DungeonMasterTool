using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMasterv4.Models
{
    public class RulesListAPI
    {
        public class Rootobject
        {
            public int count { get; set; }
            public Result[] results { get; set; }
        }

        public class Result
        {
            public string name { get; set; }
            public string index { get; set; }
            public string url { get; set; }
        }
    }
}
