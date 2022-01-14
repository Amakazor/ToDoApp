using Common.Communication.Requests.Enums;
using Common.Communication.Responses.Enums;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Communication.Requests
{
    [DataContract()]
    internal class AdminUserDeleteRequest : AdminUserRequest
    {
        public AdminUserDeleteRequest(string username, string password, User modifiedUser) : base(username, password, modifiedUser)
        {
        }

        [DataMember(IsRequired = true)]
        public override RequestType Type => RequestType.ADMIN_USER_ACTIVATE;
    }
}
