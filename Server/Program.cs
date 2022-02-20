using Server.Commands;
using Server.Commands.Updates;
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

            Server.Objects.Object.Objects.Add(new Enemy());
            server = new TcpListener(IPAddress.Any, 9999);
            server.Start();
            new Thread(() => Listen()).Start();
            new Thread(() =>
            {
                while (true)
                {
                    Objects.Object.Objects.OfType<Player>().ToList().ForEach(x =>
                    {
                        Objects.Object.Objects.OfType<Enemy>().ToList().ForEach(y =>
                        {
                            Write(x.client.GetStream(), new EnemiesUpdate(y));
                        });
                        Console.WriteLine($"{x.Id}");
                    });
                    Thread.Sleep(1000);
                }
            }).Start();
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