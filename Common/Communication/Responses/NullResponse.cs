using Common.Communication.Responses.Enums;
using Common.Communication.Responses.ResponseEvents;
using System;
using System.Runtime.Serialization;

namespace Common.Communication.Responses
{
    [DataContract()]
    public class NullResponse : Response
    {
        public NullResponse() : base()
        {
        }

        [DataMember(IsRequired = true)]
        public override ResponseType Type => ResponseType.NULL;

        protected new NullResponseEventArgs eventArgs;

        public override NullResponseEventArgs EventArgs
        {
            get
            {
                if (eventArgs == null) eventArgs = new();
                return eventArgs;
            }
        }
    }
}
