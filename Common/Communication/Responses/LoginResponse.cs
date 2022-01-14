using Common.Communication.Responses.Enums;
using Common.Communication.Responses.ResponseEvents;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Communication.Responses
{
    [DataContract()]
    public class LoginResponse: Response
    {
        public LoginResponse(bool userValid, User user) : base()
        {
            UserValid = userValid;
            User = user;
        }

        [DataMember(IsRequired = true)]
        protected bool UserValid { get; private set; }

        [DataMember(IsRequired = true)]
        public User User { get; }

        [DataMember(IsRequired = true)]
        public override ResponseType Type => ResponseType.NULL;

        protected new LoginResponseEventArgs eventArgs;

        public override LoginResponseEventArgs EventArgs
        {
            get
            {
                if (eventArgs == null) eventArgs = new(UserValid, User);
                return eventArgs;
            }
        }
    }
}
