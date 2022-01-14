using Common.Communication.Requests.Enums;
using Common.Models;
using System.Runtime.Serialization;

namespace Common.Communication.Requests
{
    [DataContract()]
    public class UserRegisterRequest : UserLoginRequest
    {
        public UserRegisterRequest(User user) : base(user)
        {
        }

        [DataMember(IsRequired = true)]
        public override RequestType Type => RequestType.USER_REGISTER;
    }
}
