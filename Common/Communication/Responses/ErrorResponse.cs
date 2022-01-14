using Common.Communication.Responses.Enums;
using Common.Communication.Responses.ResponseEvents;
using System;
using System.Runtime.Serialization;

namespace Common.Communication.Responses
{
    [DataContract()]
    public class ErrorResponse : Response
    {
        public ErrorResponse(string message) : base()
        {
            Message = message;
        }

        [DataMember(IsRequired = true)]
        public string Message { get; private set; }

        [DataMember(IsRequired = true)]
        public override ResponseType Type => ResponseType.PING;

        protected new ErrorResponseEventArgs eventArgs;

        public override ErrorResponseEventArgs EventArgs
        {
            get
            {
                if (eventArgs == null) eventArgs = new(Message);
                return eventArgs;
            }
        }
    }
}
