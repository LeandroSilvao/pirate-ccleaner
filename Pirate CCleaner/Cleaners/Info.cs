using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirate_CCleaner.Cleaners
{
    class Info
    {
        public DriveInfo[] Disks { get; set; }
        public string UserName { get; set; }
        public List<string> TempsPath { get; set; }
        public long SizeTempsPath { get; set; }

    }
}
