using Common.Communication;
using Common.Serialization;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Common.Communication.Responses;
using Common.Communication.Requests.RequestEvents;
using Common.Models;
using System.IO;
using System.Collections.Generic;

namespace ConsoleServer
{
    public partial class Logs
    {
        private static bool firstLog = false;
        public static void LogEntry(string message)
        {
            StreamWriter logFile;
            if (firstLog)
            {
                logFile = File.AppendText("logs.txt");
            }
            else
            {
                logFile = File.CreateText("logs.txt");
                firstLog = true;
            }

            logFile.WriteLine(message);
            logFile.Close();
        }
    }
}
