using System;
using System.Runtime.Serialization;
using Common.Communication.Requests.Enums;
using Common.Communication.Responses;

namespace Common.Communication.Requests
{
    [DataContract()]
    public class Request
    {
        [DataMember(IsRequired = true)]
        public string Username { get; }

        [DataMember(IsRequired = true)]
        public string Password { get; }

        [DataMember(IsRequired = true)]
        public virtual RequestType Type { get; }

        public virtual Response GetResponse()
        {
            throw new NotImplementedException();
        }
    }
}
