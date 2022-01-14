using System;
using System.Text;
using System.Net.Sockets;
using System.Windows.Forms;
using Common.Communication;
using Common.Communication.Requests;
using Common.Serialization;
using Common.Models.Enums;
using System.Diagnostics;
using System.IO;

namespace WinFormsClient
{
    public partial class SocketClient
    {

        private string Host { get; }
        private int Port { get; }
        private ResponseProcessor responseProcessor { get; }

        public SocketClient(string host, int port)
        {
            Host = host;
            Port = port;
            responseProcessor = new();

            responseProcessor.RespondedPing += ResponseProcessor_RespondedPing;
            responseProcessor.RespondedNull += ResponseProcessor_RespondedNull;
            responseProcessor.RespondedLogin += ResponseProcessor_RespondedLogin;
            responseProcessor.RespondedTasklistGet += ResponseProcessor_RespondedTasklistGet;
            responseProcessor.RespondedError += ResponseProcessor_RespondedError;
        }

        public void SendRequest(Request request)
        {
            try
            {
                TcpClient client = new TcpClient(Host, Port);
                MessageBox.Show("Connected");
                Logs.LogEntry($"Connected {Host}: {Port}");
                //Users form2 = new Users();
                //form2.Show();


                BinaryWriter writer = new(client.GetStream(), Encoding.UTF8, true);
                writer.Write(Serializer.SerializeObject<Request>(request));
                writer.Dispose();

                BinaryReader reader = new(client.GetStream(), Encoding.UTF8, true);
                responseProcessor.Process(reader.ReadString());
                reader.Dispose();

           
                client.Close();
            }
            catch (SocketException)
            {
                //MessageBox.Show("Error... " + e.ToString());
                MessageBox.Show("Correct your IP number or port number and try again");
            }

        }

        private void ResponseProcessor_RespondedError(object sender, Common.Communication.Responses.ResponseEvents.ErrorResponseEventArgs e)
        {
            //returns error to show in box
            throw new NotImplementedException();
        }

        private void ResponseProcessor_RespondedTasklistGet(object sender, Common.Communication.Responses.ResponseEvents.TasklistGetResponseEventArgs e)
        {
            //returns all tasklist for the user, only for testing
            throw new NotImplementedException();
        }

        private void ResponseProcessor_RespondedLogin(object sender, Common.Communication.Responses.ResponseEvents.LoginResponseEventArgs e)
        {
            if (e.UserLogged)
            {
                //Login successfull
                switch (e.User.UserType)
                {
                    case UserType.USER:
                        break;
                    case UserType.ADMIN:
                        break;
                    case UserType.HELPDESK:
                        break;
                }
            }
            else
            {
                //Login not successfull or logged-out
            }
        }

        private void ResponseProcessor_RespondedNull(object sender, Common.Communication.Responses.ResponseEvents.NullResponseEventArgs e)
        {
            //returns nothing, only for testing
            throw new NotImplementedException();
            
        }

        private void ResponseProcessor_RespondedPing(object sender, Common.Communication.Responses.ResponseEvents.PingResponsetEventArgs e)
        {
            //returns message, can be used to test if server exists
            Debug.WriteLine(e.Message);
            
        }
    }
}

