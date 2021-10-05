using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMasterv4.Models.Rules
{
    public class AdventuringListAPI
    {
        public class Rootobject
        {
            public string name { get; set; }
            public string index { get; set; }
            public string desc { get; set; }
            public Subsection[] subsections { get; set; }
            public string url { get; set; }
        }

        public class Subsection
        {
            public string name { get; set; }
            public string index { get; set; }
            public string url { get; set; }
        }

    }
}
