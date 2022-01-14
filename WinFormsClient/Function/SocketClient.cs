using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace WinFormsClient
{
    public partial class SocketClient
    {
        
            String host;
            int socketNo;

            public SocketClient(String _host, int _socketNo)
            {
                host = _host;
                socketNo = _socketNo;
            }

            public void Connect()
            {

                try
                {
                TcpClient client = new TcpClient();
                client.Connect(IPAddress.Parse(host), socketNo);
                MessageBox.Show("Connected");
                Logs.LogEntry($"Connected {host}: {socketNo}");
                Users form2 = new Users();
                form2.Show();
                //client.Connect(new IPEndPoint(IPAddress.Parse(host), socketNo));
                //Status_Info.text
                //client.ConnectAsync(IPAddress.Parse(host), socketNo);
                NetworkStream nstr = client.GetStream();

                    StreamReader sr = new StreamReader(new BufferedStream(nstr), Encoding.UTF8);
                    StreamWriter sw = new StreamWriter(nstr, Encoding.UTF8);
                /*
                    while (true)
                    {
                        try
                        {
                            string data;
                            MessageBox.Show("Enter text (q - exits): ");
                            data = "wysyłka danych";
                            //data = Console.ReadLine();

                            if (data.CompareTo("q") == 0)
                            {
                                break;
                            }


                            sw.WriteLine(data);
                            sw.Flush();
                            MessageBox.Show("Send data: " + data);
                            string recv = sr.ReadLine();
                            MessageBox.Show("Recv data: " + recv);
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.ToString());
                            break;
                        }
                    }*/
                    nstr.Close();
                    client.Close();
                }
                catch (Exception e)
                {
                    //MessageBox.Show("Error... " + e.ToString());
                    MessageBox.Show("Correct your IP number or port number and try again");
                }
                
            }
        }
    }

