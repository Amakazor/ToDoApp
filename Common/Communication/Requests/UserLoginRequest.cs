using Common.Communication.Requests.Enums;
using Common.Communication.Requests.RequestEvents;
using Common.Models;
using System.Runtime.Serialization;

namespace Common.Communication.Requests
{
    [DataContract()]
    public class UserLoginRequest : Request
    {

        public UserLoginRequest(User user) : base(user.Username, user.Password)
        {
            User = user;
        }

        [DataMember(IsRequired = true)]
        public User User { get; private set; }

        [DataMember(IsRequired = true)]
        public override RequestType Type => RequestType.USER_LOGIN;

        protected new UserRequestEventArgs eventArgs;

        public override UserRequestEventArgs EventArgs
        {
            get
            {
                if (eventArgs == null) eventArgs = new(User);
                return eventArgs;
            }
        }
    }
}
