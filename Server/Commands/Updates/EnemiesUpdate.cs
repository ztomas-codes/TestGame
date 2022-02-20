using Server.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Commands.Updates
{
    public class EnemiesUpdate : Command
    {
        public EnemiesUpdate(Enemy enemy)
        {
            Prefix = "EnemyUpdate";
            Args = new Dictionary<string, string>
            {
                { "Id", $"{enemy.Id}" },
                { "X", $"{enemy.Location.X}"},
                { "Y", $"{enemy.Location.Y}"}
            };
        }
    }
}
