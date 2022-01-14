using System;
using System.Text;
using System.Net.Sockets;
using System.Windows.Forms;
using Common.Communication;
using Common.Communication.Requests;
using Common.Serialization;
using Common.Models.Enums;
using System.Collections.Generic;
using System.IO;
using WinFormsClient.User_types;

namespace WinFormsClient
{
    public partial class SocketClient
    {
        private string Host { get; }
        //private string Host;
        private int Port { get; }
        //private int Port;
        private ResponseProcessor responseProcessor { get; }

        public static string User_name, User_password, First_name, Last_name;

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

                BinaryWriter writer = new(client.GetStream(), Encoding.UTF8, true);
                writer.Write(Serializer.SerializeObject<Request>(request));
                writer.Dispose();

                BinaryReader reader = new(client.GetStream(), Encoding.UTF8, true);
                responseProcessor.Process(reader.ReadString());
                reader.Dispose();
           
                client.Close();
            }
            catch (SocketException q)
            {
                MessageBox.Show("Correct your IP number or port number and try again");
                //MessageBox.Show(q.Message);
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
            //throw new NotImplementedException();
            MessageBox.Show(e.Tasklists.ToString());
            MessageBox.Show(e.Tasklists.Comparer.ToString());
            //e.Tasklists.             
            DisplaySet(e.Tasklists);

            void DisplaySet(HashSet<Common.Models.Tasklist> collection)
            {
                foreach (Common.Models.Tasklist i in collection)
                {                   
                   // MessageBox.Show(" {0}" + i.ToString());
                    MessageBox.Show(" {0}" + i.Name);
                }

            }

        }

        private void ResponseProcessor_RespondedLogin(object sender, Common.Communication.Responses.ResponseEvents.LoginResponseEventArgs e)
        {
            if (e.UserLogged)
            {
                First_name = e.User.FirstName;
                Last_name = e.User.LastName;
                User_name = e.User.Username;
                User_password = e.User.Password;

                //Login successfull
                switch (e.User.UserType)
                {
                    case UserType.USER:
                        User user = new User();
                        user.Show();
                        break;
                    case UserType.ADMIN:
                        Admin admin = new Admin();
                        admin.Show();
                        break;
                    case UserType.HELPDESK:
                        Helpdesk helpdesk = new Helpdesk();
                        helpdesk.Show();
                        break;
                }
            }
            
            else
            {
                //Login not successfull or logged-out
                MessageBox.Show("Correct your login or password and try again");
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
            //Debug.WriteLine(e.Message);
            MessageBox.Show("Connected");
            Users users = new Users();
            users.Show();
        }
    }
}

