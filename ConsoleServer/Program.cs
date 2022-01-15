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
    class MainServer
    {
        static void Main(string[] args)
        {
            User.CreateAdminIfNotExists();
            User.CreateUserIfNotExists();
            User.CreateHelpdeskIfNotExists();
            Tasklist.CreateDummyDataIfNotExists();

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
                requestProcessor.RequestedTicketAdd += RequestProcessor_RequestedTicketAdd;
                requestProcessor.RequestedTicketsGet += RequestProcessor_RequestedTicketsGet;
                requestProcessor.HelpdeskRequestedTicketGet += RequestProcessor_HelpdeskRequestedTicketGet;
                requestProcessor.HelpdeskRequestedTicketUpdate += RequestProcessor_HelpdeskRequestedTicketUpdate;
                requestProcessor.AdminRequestedUserGet += RequestProcessor_AdminRequestedUserGet;
                requestProcessor.AdminRequestedUserActivate += RequestProcessor_AdminRequestedUserActivate;
                requestProcessor.AdminRequestedUserDelete += RequestProcessor_AdminRequestedUserDelete;

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
                        Logs.LogEntry("Received: " + data);

                        string message = Serializer.SerializeObject<Response>(requestProcessor.Process(data));
                        Console.WriteLine("Sent: {0}", message);
                        Logs.LogEntry("Sent: " + message);
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

        private static void RequestProcessor_AdminRequestedUserDelete(object sender, AdminUserEventArgs e)
        {
            User authenticatedUser = e.User.Authenticate();
            if (authenticatedUser is null) e.ResponseHandle = new LoginResponse(false, authenticatedUser);
            else
            {
                string error = User.Delete(authenticatedUser, e.ModifiedUser);
                if (error is not null) e.ResponseHandle = new ErrorResponse(error);
                else e.ResponseHandle = new UserGetAllResponse(User.GetAll(authenticatedUser));
            }
        }

        private static void RequestProcessor_AdminRequestedUserActivate(object sender, AdminUserEventArgs e)
        {
            User authenticatedUser = e.User.Authenticate();
            if (authenticatedUser is null) e.ResponseHandle = new LoginResponse(false, authenticatedUser);
            else
            {
                string error = User.Activate(authenticatedUser, e.ModifiedUser);
                if (error is not null) e.ResponseHandle = new ErrorResponse(error);
                else e.ResponseHandle = new UserGetAllResponse(User.GetAll(authenticatedUser));
            }
        }

        private static void RequestProcessor_AdminRequestedUserGet(object sender, RequestEventArgs e)
        {
            User authenticatedUser = e.User.Authenticate();
            if (authenticatedUser is null) e.ResponseHandle = new LoginResponse(false, authenticatedUser);
            else
            {
                string error = User.IsAdminError(authenticatedUser);
                if (error is not null) e.ResponseHandle = new ErrorResponse(error);
                e.ResponseHandle = new UserGetAllResponse(User.GetAll(authenticatedUser));
            }
        }

        private static void RequestProcessor_HelpdeskRequestedTicketUpdate(object sender, TicketRequestEventArgs e)
        {
            User authenticatedUser = e.User.Authenticate();
            if (authenticatedUser is null) e.ResponseHandle = new LoginResponse(false, authenticatedUser);
            else
            {
                string error = Ticket.TryUpdate(authenticatedUser, e.Ticket);
                if (error is not null) e.ResponseHandle = new ErrorResponse(error);
                else e.ResponseHandle = new TasklistGetResponse(Tasklist.GetAll(authenticatedUser));
            }
        }

        private static void RequestProcessor_HelpdeskRequestedTicketGet(object sender, RequestEventArgs e)
        {
            User authenticatedUser = e.User.Authenticate();
            if (authenticatedUser is null) e.ResponseHandle = new LoginResponse(false, authenticatedUser);
            else
            {
                e.ResponseHandle = new TicketGetAllResponse(Ticket.GetAll(authenticatedUser));
            }
        }

        private static void RequestProcessor_RequestedTicketAdd(object sender, TicketRequestEventArgs e)
        {
            User authenticatedUser = e.User.Authenticate();
            if (authenticatedUser is null) e.ResponseHandle = new LoginResponse(false, authenticatedUser);
            else
            {
                string error = Ticket.TryAdd(authenticatedUser, e.Ticket);
                if (error is not null) e.ResponseHandle = new ErrorResponse(error);
                else e.ResponseHandle = new TasklistGetResponse(Tasklist.GetAll(authenticatedUser));
            }
        }

        private static void RequestProcessor_RequestedTicketsGet(object sender, RequestEventArgs e)
        {
            User authenticatedUser = e.User.Authenticate();
            if (authenticatedUser is null) e.ResponseHandle = new LoginResponse(false, authenticatedUser);
            else
            {
                e.ResponseHandle = new TicketGetAllResponse(Ticket.GetAll(authenticatedUser));
            }
        }

        private static void RequestProcessor_RequestedTaskstatusUpdate(object sender, TaskStatusRequestEventArgs e)
        {
            User authenticatedUser = e.User.Authenticate();
            if (authenticatedUser is null) e.ResponseHandle = new LoginResponse(false, authenticatedUser);
            else
            {
                string error = Tasklist.TryUpdateTaskstatus(authenticatedUser, e.Tasklist, e.TaskStatus);
                if (error is not null) e.ResponseHandle = new ErrorResponse(error);
                else e.ResponseHandle = new TasklistGetResponse(Tasklist.GetAll(authenticatedUser));
            }
        }

        private static void RequestProcessor_RequestedTaskstatusDelete(object sender, TaskStatusRequestEventArgs e)
        {
            User authenticatedUser = e.User.Authenticate();
            if (authenticatedUser is null) e.ResponseHandle = new LoginResponse(false, authenticatedUser);
            else
            {
                string error = Tasklist.TryDeleteTaskstatus(authenticatedUser, e.Tasklist, e.TaskStatus);
                if (error is not null) e.ResponseHandle = new ErrorResponse(error);
                else e.ResponseHandle = new TasklistGetResponse(Tasklist.GetAll(authenticatedUser));
            }
        }

        private static void RequestProcessor_RequestedTaskstatusAdd(object sender, TaskStatusRequestEventArgs e)
        {
            User authenticatedUser = e.User.Authenticate();
            if (authenticatedUser is null) e.ResponseHandle = new LoginResponse(false, authenticatedUser);
            else
            {
                string error = Tasklist.TryAddTaskstatus(authenticatedUser, e.Tasklist, e.TaskStatus);
                if (error is not null) e.ResponseHandle = new ErrorResponse(error);
                else e.ResponseHandle = new TasklistGetResponse(Tasklist.GetAll(authenticatedUser));
            }
        }

        private static void RequestProcessor_RequestedTaskUpdate(object sender, TaskRequestEventArgs e)
        {
            User authenticatedUser = e.User.Authenticate();
            if (authenticatedUser is null) e.ResponseHandle = new LoginResponse(false, authenticatedUser);
            else
            {
                string error = Tasklist.TryUpdateTask(authenticatedUser, e.Tasklist, e.Task);
                if (error is not null) e.ResponseHandle = new ErrorResponse(error);
                else e.ResponseHandle = new TasklistGetResponse(Tasklist.GetAll(authenticatedUser));
            }
        }

        private static void RequestProcessor_RequestedTaskDelete(object sender, TaskRequestEventArgs e)
        {
            User authenticatedUser = e.User.Authenticate();
            if (authenticatedUser is null) e.ResponseHandle = new LoginResponse(false, authenticatedUser);
            else
            {
                string error = Tasklist.TryRemoveTask(authenticatedUser, e.Tasklist, e.Task);
                if (error is not null) e.ResponseHandle = new ErrorResponse(error);
                else e.ResponseHandle = new TasklistGetResponse(Tasklist.GetAll(authenticatedUser));
            }
        }

        private static void RequestProcessor_RequestedTaskAdd(object sender, TaskRequestEventArgs e)
        {
            User authenticatedUser = e.User.Authenticate();
            if (authenticatedUser is null) e.ResponseHandle = new LoginResponse(false, authenticatedUser);
            else
            {
                string error = Tasklist.TryAddTask(authenticatedUser, e.Tasklist, e.Task);
                if (error is not null) e.ResponseHandle = new ErrorResponse(error);
                else e.ResponseHandle = new TasklistGetResponse(Tasklist.GetAll(authenticatedUser));
            }
        }

        private static void RequestProcessor_RequestedOwnershipGive(object sender, MemberRequestEventArgs e)
        {
            User authenticatedUser = e.User.Authenticate();
            if (authenticatedUser is null) e.ResponseHandle = new LoginResponse(false, authenticatedUser);
            else
            {
                string error = Tasklist.TryChangeOwner(authenticatedUser, e.Tasklist, e.Member);
                if (error is not null) e.ResponseHandle = new ErrorResponse(error);
                else e.ResponseHandle = new TasklistGetResponse(Tasklist.GetAll(authenticatedUser));
            }
        }

        private static void RequestProcessor_RequestedMemberRemove(object sender, MemberRequestEventArgs e)
        {
            User authenticatedUser = e.User.Authenticate();
            if (authenticatedUser is null) e.ResponseHandle = new LoginResponse(false, authenticatedUser);
            else
            {
                string error = Tasklist.TryRemoveMember(authenticatedUser, e.Tasklist, e.Member);
                if (error is not null) e.ResponseHandle = new ErrorResponse(error);
                else e.ResponseHandle = new TasklistGetResponse(Tasklist.GetAll(authenticatedUser));
            }
        }

        private static void RequestProcessor_RequestedMemberAdd(object sender, MemberRequestEventArgs e)
        {
            User authenticatedUser = e.User.Authenticate();
            if (authenticatedUser is null) e.ResponseHandle = new LoginResponse(false, authenticatedUser);
            else
            {
                string error = Tasklist.TryAddMember(authenticatedUser, e.Tasklist, e.Member);
                if (error is not null) e.ResponseHandle = new ErrorResponse(error);
                else e.ResponseHandle = new TasklistGetResponse(Tasklist.GetAll(authenticatedUser));
            }
        }

        private static void RequestProcessor_RequestedTasklistDelete(object sender, TasklistRequestEventArgs e)
        {
            User authenticatedUser = e.User.Authenticate();
            if (authenticatedUser is null) e.ResponseHandle = new LoginResponse(false, authenticatedUser);
            else
            {
                string error = Tasklist.TryDelete(authenticatedUser, e.Tasklist);
                if (error is not null) e.ResponseHandle = new ErrorResponse(error);
                else e.ResponseHandle = new TasklistGetResponse(Tasklist.GetAll(authenticatedUser));
            }
        }

        private static void RequestProcessor_RequestedTasklistAdd(object sender, TasklistRequestEventArgs e)
        {
            User authenticatedUser = e.User.Authenticate();
            if (authenticatedUser is null) e.ResponseHandle = new LoginResponse(false, authenticatedUser);
            else
            {
                string error = Tasklist.TryAdd(authenticatedUser, e.Tasklist);
                if (error is not null) e.ResponseHandle = new ErrorResponse(error);
                else e.ResponseHandle = new TasklistGetResponse(Tasklist.GetAll(authenticatedUser));
            }
        }

        private static void RequestProcessor_RequestedTasklistUpdate(object sender, TasklistRequestEventArgs e)
        {
            User authenticatedUser = e.User.Authenticate();
            if (authenticatedUser is null) e.ResponseHandle = new LoginResponse(false, authenticatedUser);
            else
            {
                string error = Tasklist.TryUpdate(authenticatedUser, e.Tasklist);
                if (error is not null) e.ResponseHandle = new ErrorResponse(error);
                else e.ResponseHandle = new TasklistGetResponse(Tasklist.GetAll(authenticatedUser));
            }
        }

        private static void RequestProcessor_RequestedTasklistGet(object sender, RequestEventArgs e)
        {
            User authenticatedUser = e.User.Authenticate();
            if (authenticatedUser is null) e.ResponseHandle = new LoginResponse(false, authenticatedUser);
            else
            {
                e.ResponseHandle = new TasklistGetResponse(Tasklist.GetAll(authenticatedUser));
            }
        }

        private static void RequestProcessor_RequestedRegister(object sender, UserRequestEventArgs e)
        {
            e.ResponseHandle = new LoginResponse(e.User.Register(), e.User);
        }

        private static void RequestProcessor_RequestedLogin(object sender, UserRequestEventArgs e)
        {
            User authenticatedUser = e.User.Authenticate();
            e.ResponseHandle = new LoginResponse(authenticatedUser is not null, authenticatedUser);
        }

        private static void RequestProcessor_RequestedPing(object sender, PingRequestEventArgs e)
        {
            e.ResponseHandle = new PingResponse(e.Message);
        }
    }
}
