using Server.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Commands.Updates
{
    public class PlayersUpdate : Command
    {
        public PlayersUpdate(Player player)
        {
            Prefix = "PlayerUpdate";
            Args = new Dictionary<string, string>
            {
                { "Id", $"{player.Id}" },
                { "Name", $"{player.Name}" },
                { "X", $"{player.Location.X}"},
                { "Y", $"{player.Location.Y}"}
            };
        }
    }
}
