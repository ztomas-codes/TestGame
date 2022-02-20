using Server.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Objects
{
    public class Object
    {
        public string Type = "Unknown";
        public int Id { get; set; }
        public Location Location = new Location(0, 0);
        public static List<Object> Objects = new List<Object>();

        public int GetId()
        {
            int randomId = new Random().Next(0, 10000);
            while (Objects.Any(x => x.Id == randomId))
            {
                randomId = new Random().Next(0, 10000);
            }
            return randomId;
        }
    }
}
