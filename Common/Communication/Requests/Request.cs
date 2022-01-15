using System.Runtime.Serialization;
using Common.Communication.Requests.Enums;
using Common.Communication.Requests.RequestEvents;

namespace Common.Communication.Requests
{
    [DataContract()]
    [KnownType(typeof(PingRequest))]
    [KnownType(typeof(UserLoginRequest))]
    [KnownType(typeof(UserRegisterRequest))]
    [KnownType(typeof(TasklistGetRequest))]
    [KnownType(typeof(TasklistAddRequest))]
    [KnownType(typeof(TasklistDeleteRequest))]
    [KnownType(typeof(TasklistUpdateRequest))]
    [KnownType(typeof(MemberAddRequest))]
    [KnownType(typeof(MemberDeleteRequest))]
    [KnownType(typeof(OwnershipGiveRequest))]
    [KnownType(typeof(TaskAddRequest))]
    [KnownType(typeof(TaskDeleteRequest))]
    [KnownType(typeof(TaskUpdateRequest))]
    [KnownType(typeof(TaskstatusAddRequest))]
    [KnownType(typeof(TaskstatusUpdateRequest))]
    [KnownType(typeof(TaskstatusDeleteRequest))]
    [KnownType(typeof(TickedAddRequest))]
    [KnownType(typeof(UserTicketGetAllRequest))]
    [KnownType(typeof(HelpdeskTicketGetAllRequest))]
    [KnownType(typeof(HelpdeskTicketUpdateRequest))]
    [KnownType(typeof(AdminUserGetAllRequest))]
    [KnownType(typeof(AdminUserActivateRequest))]
    [KnownType(typeof(AdminUserDeleteRequest))]
    public abstract class Request
    {
        [DataMember(IsRequired = true)]
        protected string Username { get; private set; }

        [DataMember(IsRequired = true)]
        protected string Password { get; private set; }

        [DataMember(IsRequired = true)]
        public virtual RequestType Type { get; private set; }

        protected RequestEventArgs eventArgs;

        protected Request(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public virtual RequestEventArgs EventArgs 
        { 
            get 
            { 
                if (eventArgs == null) eventArgs = new(new(Username, Password));
                return eventArgs;
            } 
        }
    }
}
