using System;
using System.Net;
using System.Text;
using System.Net.Sockets;

namespace ConsoleServer
{
    class ConnectionConfig
    {
        private static int port;
        private static string ip_address;
        public static void Run()
        {
            SetIp();
            TcpHelper.StartServer(ip_address, port);
        }
        public static void SetIp()
        {
            int exist = 1;
            while (exist == 1)
            {
                IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());

                Console.WriteLine("Enter port...");
                string portstring = Console.ReadLine();

                foreach (IPAddress address in localIP)
                {
                    if (address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        try
                        {
                            ip_address = address.ToString();
                            port = Int32.Parse(portstring);
                            exist = 0;
                            break;
                        }
                        catch (Exception e)
                        {
                            ip_address = "127.0.0.1";
                            port = 443;
                            Console.WriteLine("Error..." + e.ToString());
                            Console.WriteLine("Default ip address: " + ip_address);
                            Console.WriteLine("Default port: " + port);
                            exist = 1;
                            continue;
                        }

                    }
                }
            }
        }
    }
}

        

