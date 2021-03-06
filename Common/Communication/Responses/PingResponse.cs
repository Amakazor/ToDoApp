using Common.Communication.Responses.Enums;
using Common.Communication.Responses.ResponseEvents;
using System;
using System.Runtime.Serialization;

namespace Common.Communication.Responses
{
    [DataContract()]
    public class PingResponse : Response
    {
        public PingResponse(string message) : base()
        {
            Message = message;
        }

        [DataMember(IsRequired = true)]
        public string Message { get; private set; }

        [DataMember(IsRequired = true)]
        public override ResponseType Type => ResponseType.PING;

        protected new PingResponsetEventArgs eventArgs;

        public override PingResponsetEventArgs EventArgs
        {
            get
            {
                if (eventArgs == null) eventArgs = new(Message);
                return eventArgs;
            }
        }
    }
}
