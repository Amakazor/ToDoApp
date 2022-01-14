using Common.Communication.Requests.Enums;
using Common.Communication.Requests.RequestEvents;
using System.Runtime.Serialization;

namespace Common.Communication.Requests
{
    [DataContract()]
    public class AdminUserGetAllRequest : Request
    {
        public AdminUserGetAllRequest(string username, string password) : base(username, password)
        {
        }

        [DataMember(IsRequired = true)]
        public override RequestType Type => RequestType.ADMIN_USER_GETALL;

        protected new RequestEventArgs eventArgs;

        public override RequestEventArgs EventArgs
        {
            get
            {
                if (eventArgs == null) eventArgs = new(new(Username, Password));
                return eventArgs;
            }
        }
    }
}
