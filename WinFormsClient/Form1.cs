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
using Microsoft.VisualBasic;
using Common.Communication.Requests;

namespace WinFormsClient
{
    public partial class Form1 : Form
    {
        public static int port;
        public static string ip_address = IPAddress.Loopback.ToString();

        public Form1()
        {
            InitializeComponent();
            Ip_address.Text = ip_address;
            Port.Text = "22222";
        }

        private void Ip_address_TextChanged(object sender, EventArgs e)
        {

        }

        private void Connect_button_Click(object sender, EventArgs e)
        {
            while (true)
            {
                try
                {
                    while (!int.TryParse(Port.Text, out port))
                    {
                        string input = Interaction.InputBox("Enter port", "Wrong port, try again.", "...", 10, 10);
                        Port.Text = input;
                        
                    }
                    SocketClient client = new (ip_address, port);
                    DataStore.Instance.SocketClient = client;

                    Logs.LogEntry($"Connecting.....{ip_address}: {port}");                   
                    client.SendRequest(new PingRequest(null, null, "TESTING CONNECTION"));
                    break;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Status_Info_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
