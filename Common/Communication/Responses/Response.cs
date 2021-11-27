using Common.Communication.Responses.Enums;
using System;
using System.Runtime.Serialization;

namespace Common.Communication.Responses
{
    [DataContract()]
    public class Response
    {
        [DataMember(IsRequired = true)]
        public string Username { get; }

        [DataMember(IsRequired = true)]
        public virtual ResponseType Type { get; }
    }
}
