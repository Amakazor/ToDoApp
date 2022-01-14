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

namespace ConsoleServer
{
    class MainServer
    {
        static void Main(string[] args)
        {
            User.CreateAdminIfNotExists();
            User.CreateUserIfNotExists();
            User.CreateHelpdeskIfNotExists();
            /*
            User admin = new("admin", "admin");
            admin.Authenticate();
            
            string error = Tasklist.TryAdd(new("admin", "admin"), new("firstlist", admin, new System.Collections.Generic.HashSet<User> {admin}, null,null));
            Console.WriteLine(error);
            */
            while (true)
            {
                TcpListener server = null;
                RequestProcessor requestProcessor = new();

                requestProcessor.RequestedPing += RequestProcessor_RequestedPing;
                requestProcessor.RequestedLogin += RequestProcessor_RequestedLogin;
                requestProcessor.RequestedRegister += RequestProcessor_RequestedRegister;
                requestProcessor.RequestedTasklistGet += RequestProcessor_RequestedTasklistGet;
                requestProcessor.RequestedTasklistAdd += RequestProcessor_RequestedTasklistAdd;
                requestProcessor.RequestedTasklistDelete += RequestProcessor_RequestedTasklistDelete;
                requestProcessor.RequestedTasklistUpdate += RequestProcessor_RequestedTasklistUpdate;
                requestProcessor.RequestedMemberAdd += RequestProcessor_RequestedMemberAdd;
                requestProcessor.RequestedMemberRemove += RequestProcessor_RequestedMemberRemove;
                requestProcessor.RequestedOwnershipGive += RequestProcessor_RequestedOwnershipGive;
                requestProcessor.RequestedTaskAdd += RequestProcessor_RequestedTaskAdd;
                requestProcessor.RequestedTaskDelete += RequestProcessor_RequestedTaskDelete;
                requestProcessor.RequestedTaskUpdate += RequestProcessor_RequestedTaskUpdate;
                requestProcessor.RequestedTaskstatusAdd += RequestProcessor_RequestedTaskstatusAdd;
                requestProcessor.RequestedTaskstatusDelete += RequestProcessor_RequestedTaskstatusDelete;
                requestProcessor.RequestedTaskstatusUpdate += RequestProcessor_RequestedTaskstatusUpdate;

                try
                {
                    Console.WriteLine("Enter server port:");
                    int port;
                    while (!int.TryParse(Console.ReadLine(), out port))
                    {
                        Console.WriteLine("\nWrong port, try again.");
                        Console.WriteLine("Enter server port:");

                    }

                    server = new TcpListener(IPAddress.Loopback, port);
                    server.Start();


                    byte[] buffer = new byte[256];
                    string data;

                    while (true)
                    {

                        Console.Write("Waiting for a connection... ");

                        TcpClient client = server.AcceptTcpClient();
                        Console.WriteLine("Connected!");


                        BinaryReader reader = new BinaryReader(client.GetStream(), Encoding.UTF8, true);
                        data = reader.ReadString();
                        Console.WriteLine("Received: {0}", data);

                        string message = Serializer.SerializeObject<Response>(requestProcessor.Process(data));
                        Console.WriteLine("Sent: {0}", message);
                        BinaryWriter writer = new BinaryWriter(client.GetStream(), Encoding.UTF8, true);
                        writer.Write(message);

                        client.Close();
                    }
                }
                catch (SocketException e)
                {
                    Console.WriteLine("SocketException: {0}", e);
                }
                finally
                {
                    server?.Stop();
                }
            }
        }

        private static void RequestProcessor_RequestedTaskstatusUpdate(object sender, TaskStatusRequestEventArgs e)
        {
            if (!e.User.Authenticate()) e.ResponseHandle = new LoginResponse(false, e.User);
            else
            {
                string error = Tasklist.TryUpdateTaskstatus(e.User, e.Tasklist, e.TaskStatus);
                if (error is not null) e.ResponseHandle = new ErrorResponse(error);
                else e.ResponseHandle = new TasklistGetResponse(Tasklist.GetAll(e.User));
            }
        }

        private static void RequestProcessor_RequestedTaskstatusDelete(object sender, TaskStatusRequestEventArgs e)
        {
            if (!e.User.Authenticate()) e.ResponseHandle = new LoginResponse(false, e.User);
            else
            {
                string error = Tasklist.TryDeleteTaskstatus(e.User, e.Tasklist, e.TaskStatus);
                if (error is not null) e.ResponseHandle = new ErrorResponse(error);
                else e.ResponseHandle = new TasklistGetResponse(Tasklist.GetAll(e.User));
            }
        }

        private static void RequestProcessor_RequestedTaskstatusAdd(object sender, TaskStatusRequestEventArgs e)
        {
            if (!e.User.Authenticate()) e.ResponseHandle = new LoginResponse(false, e.User);
            else
            {
                string error = Tasklist.TryAddTaskstatus(e.User, e.Tasklist, e.TaskStatus);
                if (error is not null) e.ResponseHandle = new ErrorResponse(error);
                else e.ResponseHandle = new TasklistGetResponse(Tasklist.GetAll(e.User));
            }
        }

        private static void RequestProcessor_RequestedTaskUpdate(object sender, TaskRequestEventArgs e)
        {
            if (!e.User.Authenticate()) e.ResponseHandle = new LoginResponse(false, e.User);
            else
            {
                string error = Tasklist.TryUpdateTask(e.User, e.Tasklist, e.Task);
                if (error is not null) e.ResponseHandle = new ErrorResponse(error);
                else e.ResponseHandle = new TasklistGetResponse(Tasklist.GetAll(e.User));
            }
        }

        private static void RequestProcessor_RequestedTaskDelete(object sender, TaskRequestEventArgs e)
        {
            if (!e.User.Authenticate()) e.ResponseHandle = new LoginResponse(false, e.User);
            else
            {
                string error = Tasklist.TryRemoveTask(e.User, e.Tasklist, e.Task);
                if (error is not null) e.ResponseHandle = new ErrorResponse(error);
                else e.ResponseHandle = new TasklistGetResponse(Tasklist.GetAll(e.User));
            }
        }

        private static void RequestProcessor_RequestedTaskAdd(object sender, TaskRequestEventArgs e)
        {
            if (!e.User.Authenticate()) e.ResponseHandle = new LoginResponse(false, e.User);
            else
            {
                string error = Tasklist.TryAddTask(e.User, e.Tasklist, e.Task);
                if (error is not null) e.ResponseHandle = new ErrorResponse(error);
                else e.ResponseHandle = new TasklistGetResponse(Tasklist.GetAll(e.User));
            }
        }

        private static void RequestProcessor_RequestedOwnershipGive(object sender, MemberRequestEventArgs e)
        {
            if (!e.User.Authenticate()) e.ResponseHandle = new LoginResponse(false, e.User);
            else
            {
                string error = Tasklist.TryChangeOwner(e.User, e.Tasklist, e.Member);
                if (error is not null) e.ResponseHandle = new ErrorResponse(error);
                else e.ResponseHandle = new TasklistGetResponse(Tasklist.GetAll(e.User));
            }
        }

        private static void RequestProcessor_RequestedMemberRemove(object sender, MemberRequestEventArgs e)
        {
            if (!e.User.Authenticate()) e.ResponseHandle = new LoginResponse(false, e.User);
            else
            {
                string error = Tasklist.TryRemoveMember(e.User, e.Tasklist, e.Member);
                if (error is not null) e.ResponseHandle = new ErrorResponse(error);
                else e.ResponseHandle = new TasklistGetResponse(Tasklist.GetAll(e.User));
            }
        }

        private static void RequestProcessor_RequestedMemberAdd(object sender, MemberRequestEventArgs e)
        {
            if (!e.User.Authenticate()) e.ResponseHandle = new LoginResponse(false, e.User);
            else
            {
                string error = Tasklist.TryAddMember(e.User, e.Tasklist, e.Member);
                if (error is not null) e.ResponseHandle = new ErrorResponse(error);
                else e.ResponseHandle = new TasklistGetResponse(Tasklist.GetAll(e.User));
            }
        }

        private static void RequestProcessor_RequestedTasklistDelete(object sender, TasklistRequestEventArgs e)
        {
            if (!e.User.Authenticate()) e.ResponseHandle = new LoginResponse(false, e.User);
            else
            {
                string error = Tasklist.TryDelete(e.User, e.Tasklist);
                if (error is not null) e.ResponseHandle = new ErrorResponse(error);
                else e.ResponseHandle = new TasklistGetResponse(Tasklist.GetAll(e.User));
            }
        }

        private static void RequestProcessor_RequestedTasklistAdd(object sender, TasklistRequestEventArgs e)
        {
            if (!e.User.Authenticate()) e.ResponseHandle = new LoginResponse(false, e.User);
            else
            {
                string error = Tasklist.TryAdd(e.User, e.Tasklist);
                if (error is not null) e.ResponseHandle = new ErrorResponse(error);
                else e.ResponseHandle = new TasklistGetResponse(Tasklist.GetAll(e.User));
            }
        }

        private static void RequestProcessor_RequestedTasklistUpdate(object sender, TasklistRequestEventArgs e)
        {
            if (!e.User.Authenticate()) e.ResponseHandle = new LoginResponse(false, e.User);
            else
            {
                string error = Tasklist.TryUpdate(e.User, e.Tasklist);
                if (error is not null) e.ResponseHandle = new ErrorResponse(error);
                else e.ResponseHandle = new TasklistGetResponse(Tasklist.GetAll(e.User));
            }
        }

        private static void RequestProcessor_RequestedTasklistGet(object sender, RequestEventArgs e)
        {
            if (!e.User.Authenticate()) e.ResponseHandle = new LoginResponse(false, e.User);
            else
            {
                e.ResponseHandle = new TasklistGetResponse(Tasklist.GetAll(e.User));
            }
        }

        private static void RequestProcessor_RequestedRegister(object sender, UserRequestEventArgs e)
        {
            e.ResponseHandle = new LoginResponse(e.User.Register(), e.User);
        }

        private static void RequestProcessor_RequestedLogin(object sender, UserRequestEventArgs e)
        {
            e.ResponseHandle = new LoginResponse(e.User.Authenticate(), e.User);
        }

        private static void RequestProcessor_RequestedPing(object sender, PingRequestEventArgs e)
        {
            e.ResponseHandle = new PingResponse(e.Message);
        }
    }
}
