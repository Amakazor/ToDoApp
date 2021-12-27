using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace WinFormsClient
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
