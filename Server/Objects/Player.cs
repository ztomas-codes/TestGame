using Server.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.Objects
{
    public class Player : Object
    {
        public string Name;
        public TcpClient client;

        public Player(string name, TcpClient client)
        {
            Type = "Player";
            Name = name;
            Id = GetId();

            this.client = client;

            Objects.Add(this);
        }

    }
}
