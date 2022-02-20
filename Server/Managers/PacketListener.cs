using Server.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.Managers
{
    public class PacketListener
    {
        public static Dictionary<TcpClient, Player> players = new();

        public void ListenToClient(TcpClient client)
        {
            while (client.Connected)
            {
                byte[] msg = new byte[1024];
                client.GetStream().Read(msg, 0, msg.Length);
                SortPacket(Encoding.ASCII.GetString(msg));
            }
        }

        private void SortPacket(string packet)
        {
            Console.WriteLine(packet);
        }
    }
}
