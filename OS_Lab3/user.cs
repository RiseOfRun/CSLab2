using System.Net;
using System.Net.Sockets;

namespace OS_Lab3
{
    public class User
    {
        public IPAddress IP;
        public Socket connection;

        public User(IPAddress ip, Socket connection)
        {
            IP = ip;
            this.connection = connection;
        }
    }
}