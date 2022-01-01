using System;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleServer
{
    public class SocketServer
    {
        int socketNo;
        TcpListener listener;
        bool endFlag = true;
        Task mainLoopTask;
        string host;

        public SocketServer(string _host, int _socketNo)
        {
            socketNo = _socketNo;
            host = _host;
        }

        public void Initialize()
        {
            //listener = new TcpListener(IPAddress.Parse(host), socketNo);
            listener = new TcpListener(IPAddress.Parse(host), socketNo);
            Console.WriteLine(IPAddress.Parse(host) + " Initialize" + socketNo);
            listener.Start();
        }


        public void AcceptsRequests()
        {
            mainLoopTask = Task.Factory.StartNew(() =>
            {
                while (endFlag)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    Task.Factory.StartNew(() =>
                    {
                        NetworkStream nstr = client.GetStream();

                        StreamReader sr = new StreamReader(new BufferedStream(nstr), Encoding.UTF8);
                        StreamWriter sw = new StreamWriter(nstr, Encoding.UTF8);

                        int threadId = Thread.CurrentThread.ManagedThreadId;
                        while (endFlag)
                        {
                            try
                            {
                                string message = sr.ReadLine();
                                string response = message.ToUpper().Trim();
                                sw.WriteLine(response);
                                sw.Flush();
                                Console.WriteLine("Thread: " + threadId + " receive: " + message + " send: " + response);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.ToString());
                                break;
                            }
                        }
                        nstr.Close();
                        client.Close();
                    });
                }
            });

            while (true)
            {
                try
                {
                    string data;
                    Console.Write("Enter text (q - exits): ");
                    data = Console.ReadLine();

                    if (data.CompareTo("q") == 0)
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    break;
                }
            }
        }

        public void Close()
        {
            endFlag = false;
            listener.Stop();
            Task.WaitAll(mainLoopTask);
        }

    }
}

        

