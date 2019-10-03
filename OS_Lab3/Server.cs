using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace OS_Lab3
{
    public class Server
    {
        private int port;
        private IPAddress IP;
        private Socket ServerSocket;
        private List<User> users = new List<User>();


        public Server(int port, IPAddress ip)
        {
            IP = ip;
            this.port = port;
            ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint SocketIP = new IPEndPoint(IP,port);
            ServerSocket.Bind(SocketIP);
            ServerSocket.Listen(5);
        }

        public void Start()
        {
            while (true)
            {
                Socket connection;
                connection = ServerSocket.Accept();
                User connectedUser = new User(IPAddress.Any, connection);
                Console.WriteLine($"connected {connectedUser.IP}");
                byte[] buf = new byte[200];
                int size;
                size = connection.Receive(buf);
                string response = Processing(Encoding.UTF8.GetString(buf,0,size));
                buf = Encoding.UTF8.GetBytes(response);
                connectedUser.connection.Send(buf);
                Console.WriteLine($"connection with {connectedUser.IP} closed");
            }
        }

        private string Processing(string message)
        {
            string newMessage = message + $" {message.Length}";
            return newMessage;
        }
    }
}