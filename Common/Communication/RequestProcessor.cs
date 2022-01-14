using Common.Communication.Requests;
using Common.Communication.Requests.Enums;
using Common.Communication.Requests.RequestEvents;
using Common.Communication.Responses;
using Common.Serialization;
using System;

namespace Common.Communication
{
    public class RequestProcessor
    {
        public event EventHandler<PingRequestEventArgs> RequestedPing;

        public event EventHandler<UserRequestEventArgs> RequestedLogin;
        public event EventHandler<UserRequestEventArgs> RequestedRegister;

        public event EventHandler<RequestEventArgs> RequestedTasklistGet;

        public event EventHandler<TasklistRequestEventArgs> RequestedTasklistAdd;
        public event EventHandler<TasklistRequestEventArgs> RequestedTasklistDelete;
        public event EventHandler<TasklistRequestEventArgs> RequestedTasklistUpdate;

        public event EventHandler<MemberRequestEventArgs> RequestedMemberAdd;
        public event EventHandler<MemberRequestEventArgs> RequestedMemberRemove;
        public event EventHandler<MemberRequestEventArgs> RequestedOwnershipGive;

        public event EventHandler<TaskRequestEventArgs> RequestedTaskAdd;
        public event EventHandler<TaskRequestEventArgs> RequestedTaskDelete;
        public event EventHandler<TaskRequestEventArgs> RequestedTaskUpdate;

        public event EventHandler<TaskStatusRequestEventArgs> RequestedTaskstatusAdd;
        public event EventHandler<TaskStatusRequestEventArgs> RequestedTaskstatusDelete;
        public event EventHandler<TaskStatusRequestEventArgs> RequestedTaskstatusUpdate;

        public Response Process(string requestData)
        {
            return FireEvent(Serializer.DeserializeObject<Request>(requestData).Type switch
            {
                RequestType.PING => Serializer.DeserializeObject<PingRequest>(requestData),

                RequestType.USER_LOGIN => Serializer.DeserializeObject<UserLoginRequest>(requestData),
                RequestType.USER_REGISTER => Serializer.DeserializeObject<UserRegisterRequest>(requestData),

                RequestType.TASKLIST_GET => Serializer.DeserializeObject<TasklistGetRequest>(requestData),

                RequestType.TASKLIST_ADD => Serializer.DeserializeObject<TasklistAddRequest>(requestData),
                RequestType.TASKLIST_DELETE => Serializer.DeserializeObject<TasklistDeleteRequest>(requestData),
                RequestType.TASKLIST_UPDATE => Serializer.DeserializeObject<TasklistUpdateRequest>(requestData),

                RequestType.TASKLIST_MEMBER_ADD => Serializer.DeserializeObject<MemberAddRequest>(requestData),
                RequestType.TASKLIST_MEMBER_REMOVE => Serializer.DeserializeObject<MemberDeleteRequest>(requestData),
                RequestType.TASKLIST_OWNERSHIP_GIVE => Serializer.DeserializeObject<OwnershipGiveRequest>(requestData),

                RequestType.TASK_ADD => Serializer.DeserializeObject<TaskAddRequest>(requestData),
                RequestType.TASK_DELETE => Serializer.DeserializeObject<TaskDeleteRequest>(requestData),
                RequestType.TASK_UPDATE => Serializer.DeserializeObject<TaskUpdateRequest>(requestData),

                RequestType.TASKSTATUS_ADD => Serializer.DeserializeObject<TaskstatusAddRequest>(requestData),
                RequestType.TASKSTATUS_DELETE => Serializer.DeserializeObject<TaskstatusDeleteRequest>(requestData),
                RequestType.TASKSTATUS_UPDATE => Serializer.DeserializeObject<TaskstatusUpdateRequest>(requestData),
                _ => throw new NotImplementedException(),
            }).EventArgs.ResponseHandle;
        }

        private Request FireEvent(Request request)
        {
            switch (request.Type)
            {
                case RequestType.PING:
                    RequestedPing(this, (PingRequestEventArgs)request.EventArgs);
                    break;
                case RequestType.USER_LOGIN:
                    RequestedLogin(this, (UserRequestEventArgs)request.EventArgs);
                    break;
                case RequestType.USER_REGISTER:
                    RequestedRegister(this, (UserRequestEventArgs)request.EventArgs);
                    break;
                case RequestType.TASKLIST_GET:
                    RequestedTasklistGet(this, (RequestEventArgs)request.EventArgs);
                    break;
                case RequestType.TASKLIST_ADD:
                    RequestedTasklistAdd(this, (TasklistRequestEventArgs)request.EventArgs);
                    break;
                case RequestType.TASKLIST_DELETE:
                    RequestedTasklistDelete(this, (TasklistRequestEventArgs)request.EventArgs);
                    break;
                case RequestType.TASKLIST_UPDATE:
                    RequestedTasklistUpdate(this, (TasklistRequestEventArgs)request.EventArgs);
                    break;
                case RequestType.TASKLIST_MEMBER_ADD:
                    RequestedMemberAdd(this, (MemberRequestEventArgs)request.EventArgs);
                    break;
                case RequestType.TASKLIST_MEMBER_REMOVE:
                    RequestedMemberRemove(this, (MemberRequestEventArgs)request.EventArgs);
                    break;
                case RequestType.TASKLIST_OWNERSHIP_GIVE:
                    RequestedOwnershipGive(this, (MemberRequestEventArgs)request.EventArgs);
                    break;
                case RequestType.TASK_ADD:
                    RequestedTaskAdd(this, (TaskRequestEventArgs)request.EventArgs);
                    break;
                case RequestType.TASK_DELETE:
                    RequestedTaskDelete(this, (TaskRequestEventArgs)request.EventArgs);
                    break;
                case RequestType.TASK_UPDATE:
                    RequestedTaskUpdate(this, (TaskRequestEventArgs)request.EventArgs);
                    break;
                case RequestType.TASKSTATUS_ADD:
                    RequestedTaskstatusAdd(this, (TaskStatusRequestEventArgs)request.EventArgs);
                    break;
                case RequestType.TASKSTATUS_DELETE:
                    RequestedTaskstatusDelete(this, (TaskStatusRequestEventArgs)request.EventArgs);
                    break;
                case RequestType.TASKSTATUS_UPDATE:
                    RequestedTaskstatusUpdate(this, (TaskStatusRequestEventArgs)request.EventArgs);

                    break;
            }

            return request;
        }
    }
}
