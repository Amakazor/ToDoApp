using System.Runtime.Serialization;
using Common.Communication.Requests.Enums;
using Common.Communication.Requests.RequestEvents;

namespace Common.Communication.Requests
{
    [DataContract()]
    public class PingRequest : Request
    {
        [DataMember(IsRequired = true)]
        public string Message { get; private set; }

        public PingRequest(string username, string password, string message): base(username, password)
        {
            Message = message;
        }

        [DataMember(IsRequired = true)]
        public override RequestType Type => RequestType.PING;

        protected new PingRequestEventArgs eventArgs;

        public override PingRequestEventArgs EventArgs
        {
            get
            {
                if (eventArgs == null) eventArgs = new(new(Username, Password), Message);
                return eventArgs;
            }
        }
    }
}
