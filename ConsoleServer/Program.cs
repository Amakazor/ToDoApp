using Common.Communication;
using Common.Serialization;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ConsoleServer
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = null;
            ConcreteRequestHandler requestHandler = new();
            
            try
            {
                Console.WriteLine("Enter server port:");
                int port;
                while (!int.TryParse(Console.ReadLine(), out port))
                {
                    Console.WriteLine("\nWrong port, try again.");
                    Console.WriteLine("Enter server port:");

                }

                server = new TcpListener(IPAddress.Loopback, port);
                server.Start();

                byte[] buffer = new byte[256];
                string data;

                while (true)
                {
                    Console.Write("Waiting for a connection... ");

                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");

                    NetworkStream stream = client.GetStream();
                    int i;

                    while((i = stream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        data = Encoding.UTF8.GetString(buffer, 0, i);
                        Console.WriteLine("Received: {0}", data);

                        byte[] message = Encoding.UTF8.GetBytes(Serializer.SerializeObject(RequestProcessor.Process(data, requestHandler)));

                        stream.Write(message, 0, message.Length);
                        Console.WriteLine("Sent: {0}", data);
                    }

                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                server?.Stop();
            }
        }
    }
}
