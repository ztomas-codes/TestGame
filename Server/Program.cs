using Server.Commands;
using Server.Commands.Updates;
using Server.Managers;
using Server.Objects;
using Server.Utils;
using System.Net;
using System.Net.Sockets;
using Object = Server.Objects.Object;

namespace Server
{
    public class Program
    {

        public static TcpListener server;
        public static void Main()
        {

            Enemy e = new();
            e.Location = new Utils.Location(10, 10);
            Server.Objects.Object.Objects.Add(e);

            new Thread(() => 
            {
                while(true)
                {
                    e.Location = new Location(new Random().Next(0,100), new Random().Next(0, 100));

                    Object.Objects.OfType<Player>().ToList().ForEach(x =>
                    {
                        Write(x.client.GetStream(), new EnemiesUpdate(e));
                    });

                    Thread.Sleep(100);
                }
            }).Start();

            server = new TcpListener(IPAddress.Any, 9999);
            server.Start();
            new Thread(() => Listen()).Start();
        }

        private static void Listen()
        {
            int i = 0;
            while (true)
            {
                i++;
                TcpClient client = server.AcceptTcpClient();
                new Thread(() =>
                {
                    new Player($"Test{i}", client);
                    new PacketListener().ListenToClient(client);
                }
                ).Start();
            }
        }

        public static void Write(NetworkStream stream, Command command)
        {
            stream.Write(command.Message(), 0, command.Message().Length);
        }
    }
}