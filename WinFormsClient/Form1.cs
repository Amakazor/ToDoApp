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
    public partial class Form1 : Form
    {
        TcpClient client = new TcpClient();
        /*private TcpClient client;
        public StreamReader STR;
        public StreamWriter STW;
        public string recieve;
        public String TextToSend;
        */

        public Form1()
        {
            InitializeComponent();
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());

            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    Ip_address.Text = address.ToString();
                }
            }
        }

        private void Ip_address_TextChanged(object sender, EventArgs e)
        {

        }

        private void Connect_button_Click(object sender, EventArgs e)
        {
            /*
            client = new TcpClient();
            IPEndPoint IpEnd = new IPEndPoint(IPAddress.Parse(Ip_address.Text), int.Parse(Port.Text));

            try
            {
                client.Connect(IpEnd);

                if (client.Connected)
                {
                    txtLogs.AppendText("Connected to server" + "\n");
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
            */
            try
            {
                MessageBox.Show("Client Socket");
                TcpClient tcpclnt = new TcpClient();
                MessageBox.Show("Connecting.....");

                tcpclnt.ConnectAsync("127.0.0.1", 443);
                // use the ipaddress as in the server program

                while (true)
                {
                    MessageBox.Show("Connected");
                    MessageBox.Show("Enter the string to be transmitted : ");

                    //String str = Console.ReadLine();
                    String str = "tekst do wysłania";
                    System.IO.Stream stm = tcpclnt.GetStream();

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
            }

        }
    }
}
