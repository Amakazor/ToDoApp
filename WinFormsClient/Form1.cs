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
                    Logs.LogEntry($"Connecting.....{ip_address}: {port}");                   
                    client.SendRequest(new PingRequest(null, null, "TESTING CONNECTION"));
                    //client.SendRequest(new UserLoginRequest(new("admin", "admin")));
                    //MessageBox.Show("Connected");
                    break;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            

            //SocketClient client = new SocketClient(IPAddress.Parse(Ip_address), int.Parse(Port.Text));
            /*
            client = new TcpClient();
            IPEndPoint IpEnd = new IPEndPoint(IPAddress.Parse(Ip_address.Text), int.Parse(Port.Text));

            try
            {
                client.Connect(IpEnd);

                if (client.Connected)
                {
                    txtLogs.AppendText("Connected to server" + "\n");
                    Logs.LogEntry(recieve);
                    STW = new StreamWriter(client.GetStream());
                    STR = new StreamReader(client.GetStream());
                    STW.AutoFlush = true;
                    backgroundWorker1.RunWorkerAsync();
                    backgroundWorker2.WorkerSupportsCancellation = true;
                    txtLogs.Text += "Client Connected\n";
                    lblStatus.Text = "connected";

                }
                else
                {
                    txtLogs.Text += "Client did not connect\n";
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error";
                txtLogs.Text += "Client could not connect\n>>>" + ex.Message.ToString() + "\n";
            }
            
            try
            {
                TcpClient tcpclnt = new TcpClient();               
                Logs.LogEntry($"Connecting.....{Ip_address.ToString()}: {Int32.Parse(Port.Text)}");
                //tcpclnt.ConnectAsync(Ip_address.ToString(), Int32.Parse(Port.Text));
                tcpclnt.Connect(Ip_address.ToString(), Int32.Parse(Port.Text));
                while (true)
                {
                    Logs.LogEntry("Connected");
                    Status_Info.Text = "Connected";
                    MessageBox.Show("Enter the string to be transmitted : ");

                    //String str = Console.ReadLine();
                    String str = "tekst do wysłania";
                    Stream stm = tcpclnt.GetStream();

                    ASCIIEncoding asen = new ASCIIEncoding();
                    byte[] ba = asen.GetBytes(str);
                    MessageBox.Show("Transmitting.....");

                    stm.Write(ba, 0, ba.Length);

                    byte[] bb = new byte[1024];
                    int k = stm.Read(bb, 0, 1024);

                    for (int i = 0; i < k; i++)
                        MessageBox.Show(Convert.ToString(bb[i]));
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error..... " + ex.StackTrace);
            }*/

        }

        private void Status_Info_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
