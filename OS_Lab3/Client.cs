using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace OS_Lab3
{
    class Client
    {
        private Socket connection;
        private int port;
        private IPAddress IP;
        public Client(IPAddress IP, int port)
        {
            this.IP = IP;
            this.port = port;
            connection = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.IP);
        }

        public void Session(string message, IPEndPoint serverIP)
        {
            connection.Connect(serverIP);
            byte[] tmp = new byte[200];
            tmp = Encoding.UTF8.GetBytes(message);
            Console.WriteLine($"connected to {serverIP}");
            connection.Send(tmp,tmp.Length,SocketFlags.None);
            byte[] buf = new byte[200];
            connection.Receive(buf);
            string NewMessage = Encoding.UTF8.GetString(buf);
            Console.Write(NewMessage);
            Console.ReadKey();
            connection.Close();
        }
    }
}