using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client.Objects
{
    public class Player : Object
    {
        public string Name;
        public Player(string name, TcpClient client)
        {
            Type = "Player";
            Name = name;
        }

    }
}
