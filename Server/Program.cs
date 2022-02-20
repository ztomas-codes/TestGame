using Server.Managers;
using Server.Objects;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    public class Program
    {

        public static TcpListener server;
        public static void Main()
        {
            TcpListener server = new TcpListener(IPAddress.Any, 9999);
            server.Start();
            new Thread(() => Listen()).Start();
        }

        private static void Listen()
        {
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                new Thread(() =>
                {
                    new PacketListener().ListenToClient(client);
                }
                ).Start();
            }
        }
    }
}