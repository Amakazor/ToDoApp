using Common.Communication.Responses.Enums;
using Common.Communication.Responses.ResponseEvents;
using System;
using System.Runtime.Serialization;

namespace Common.Communication.Responses
{
    [DataContract()]
    [KnownType(typeof(PingResponse))]
    [KnownType(typeof(NullResponse))]
    [KnownType(typeof(LoginResponse))]
    [KnownType(typeof(TasklistGetResponse))]
    [KnownType(typeof(ErrorResponse))]
    public abstract class Response
    {
        [DataMember(IsRequired = true)]
        public virtual ResponseType Type { get; private set; }

        protected ResponseEventArgs eventArgs;

        protected Response()
        {
        }

        public virtual ResponseEventArgs EventArgs
        {
            get
            {
                if (eventArgs == null) eventArgs = new();
                return eventArgs;
            }
        }
    }
}
