using Common.Communication.Requests.Enums;
using Common.Communication.Requests.RequestEvents;
using Common.Models;
using System.Runtime.Serialization;

namespace Common.Communication.Requests
{
    [DataContract()]
    public abstract class AdminUserRequest : Request
    {
        public AdminUserRequest(string username, string password, User modifiedUser) : base(username, password)
        {
            ModifiedUser = modifiedUser;
        }

        [DataMember(IsRequired = true)]
        public User ModifiedUser { get; }

        protected new AdminUserEventArgs eventArgs;

        public override AdminUserEventArgs EventArgs
        {
            get
            {
                if (eventArgs == null) eventArgs = new(new(Username, Password), ModifiedUser);
                return eventArgs;
            }
        }
    }
}
