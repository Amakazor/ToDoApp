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
        public static void LogEntry(string message)
        {
            string timestamp = "[" + DateTime.Now.ToString("u") + "]";

            StreamWriter logFile;

            logFile = File.AppendText("logs.txt");

            logFile.WriteLine(timestamp + message + '\n');
            logFile.Close();
        }
    }
}
