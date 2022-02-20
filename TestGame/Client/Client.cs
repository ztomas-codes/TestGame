using Client.Objects;
using Client.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Object = Client.Objects.Object;

namespace TestGame.Client
{
    public class Client
    {
        public TcpClient client;
        public NetworkStream stream;
        public Thread listenThread;

        public bool Running;

        public Client(string ip, int port)
        {
            client = new TcpClient();
            client.Connect(ip, port);

            stream = client.GetStream();
            Running = false;
        }

        public void Start()
        {
            Running = true;
            listenThread = new Thread(() => Listen());
            listenThread.Start();
        }
        public void Stop()
        {
            Running = false;
            listenThread.Suspend();
        }


        private void Listen()
        {
            while (Running)
            {
                byte[] buffer = new byte[client.ReceiveBufferSize];
                int read = stream.Read(buffer, 0, buffer.Length);
                if (read > 0)
                {
                    string data = System.Text.Encoding.ASCII.GetString(buffer, 0, read);
                    PacketSort(data);
                }
            }
        }

        private void PacketSort(string packet)
        {
            switch (packet.Split('|')[1])
            {
                case "EnemyUpdate":
                    //    { "Id", $"{enemy.Id}" },
                    //{ "X", $"{enemy.Location.X}"},
                    //{ "Y", $"{enemy.Location.Y}"}
                    Enemy e = new Enemy();
                    e.Id = int.Parse( packet.Split('|')[2]);
                    e.Location = new Location(
                        int.Parse(packet.Split('|')[3]),
                        int.Parse(packet.Split('|')[4])
                        );

                    if (!Object.Objects.Any(x => x.Id == e.Id)) Object.Objects.Add(e);
                    else Object.Objects.FirstOrDefault(x => x.Id == e.Id).Location = e.Location;

                    break;
                default:
                    Console.WriteLine("unknown packet");
                    break;
            }
        }


    }
}
