using Server.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Commands
{
    public class Movement : Command
    {
        public Movement(Objects.Object obj, Location loc )
        {
            Prefix = "Movement";
            Args = new Dictionary<string, string> 
            {
                { "Type", obj.Type },
                { "Id", $"{obj.Id}" },
                { "X", $"{obj.Location.X}"},
                { "Y", $"{obj.Location.Y}"}
            };
        }
    }
}
