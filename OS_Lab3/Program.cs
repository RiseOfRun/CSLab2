using System;
using System.Collections.Generic;
using System.Net;

namespace OS_Lab3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                bool compleate = false;
                string[] Option = Console.ReadLine().Split();
                string[] IP = Option[1].Split(':');
                switch (Option[0])
                {
                    case "start":
                        Server server = new Server(int.Parse(IP[1]),IPAddress.Parse(IP[0]));
                        server.Start();
                        compleate = true;
                        break;
                    case "connect":
                        IPHostEntry test = Dns.GetHostEntry("37.193.85.223");
                        Client client = new Client(IPAddress.Any, int.Parse(IP[1]));
                        client.Session(Console.ReadLine(), new IPEndPoint(IPAddress.Parse(IP[0]),int.Parse(IP[1])));
                        compleate = true;
                        break;
                }

                if (compleate)
                {
                    break;
                }
            }

            Console.ReadKey();

        }
    }
}