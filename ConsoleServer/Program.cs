﻿using System;

namespace ConsoleServer
{
    class MainServer
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Hello Arek");
            ConnectionConfig.Run();
            /*
            TcpHelper.Listen(); // Start listening.
            
            SocketServer server = new SocketServer(host, socketNo);
            server.Initialize();
            server.AcceptsRequests();
            server.Close();*/
        }
    }
}
