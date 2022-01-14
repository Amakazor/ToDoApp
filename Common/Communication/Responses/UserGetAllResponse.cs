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
    public class UserGetAllResponse : Response
    {
        public UserGetAllResponse(HashSet<User> users) : base()
        {
            Users = users;
        }


        [DataMember(IsRequired = true)]
        public HashSet<User> Users { get; private set; }


        [DataMember(IsRequired = true)]
        public override ResponseType Type => ResponseType.USER_GET_ALL;

        protected new UserGetAllResponseEventArgs eventArgs;

        public override UserGetAllResponseEventArgs EventArgs
        {
            get
            {
                if (eventArgs == null) eventArgs = new(Users);
                return eventArgs;
            }
        }

    }
}
