using Client.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Objects
{
    public class Object
    {
        public string Type = "Unknown";
        public int Id { get; set; }
        public Location Location = new Location(0, 0);
        public static List<Object> Objects = new List<Object>();
    }
}
