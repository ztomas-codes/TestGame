using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

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
                    Console.WriteLine("Received: {0}", data);
                }
            }
        }


    }
}
