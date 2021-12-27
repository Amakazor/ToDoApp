using System;

namespace ConsoleServer
{
    class MainServer
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Hello Arek");
            TcpHelper.StartServer(443);
            TcpHelper.Listen(); // Start listening. 
        }
    }
}
