using System;
using System.Net;
using System.Text;
using System.Net.Sockets;

namespace ConsoleServer
{
    class ConnectionConfig
    {
        private static int port = 32000;
        private static string ip_address = "127.0.0.1";

        public static void Run()
        {
            //SetIp();
            Console.WriteLine(ip_address + " Run" + port);
            SocketServer server = new SocketServer(ip_address, port);
            server.Initialize();
            server.AcceptsRequests();
            server.Close();
            //TcpHelper.StartServer(ip_address, port);
        }


        // nieużywane funkcje \\
        // ****************** \\                
        public static void SetIppp()
        {
            int exist = 1;
            string address = "192.168.1.1";
            while (exist == 1)
            {
                IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());

                Console.WriteLine("Enter port...");

                string portstring = Console.ReadLine();
                        try
                        {
                            ip_address = address.ToString();
                            port = int.Parse(portstring);
                            Console.WriteLine($"Server Socket started. Listening to TCP clients at {ip_address}:{port}");
                            exist = 0;
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error..." + e.ToString());
                            port = 443;
                            ip_address = "127.0.0.1";
                            Console.WriteLine("Default ip address: " + ip_address);
                            Console.WriteLine("Default port: " + port);
                            exist = 1;
                            //continue;
                        }

            }
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
                            port = int.Parse(portstring);
                            Console.WriteLine($"Server Socket started. Listening to TCP clients at {ip_address}:{port}");
                            exist = 0;
                            //break;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error..." + e.ToString());
                            port = 443;
                            ip_address = "127.0.0.1";
                            Console.WriteLine("Default ip address: " + ip_address);
                            Console.WriteLine("Default port: " + port);
                            exist = 1;
                            //continue;
                        }

                    }
                }
            }
        }
    }
}

        

