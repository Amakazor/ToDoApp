using System.Runtime.Serialization;
using Common.Communication.Requests.Enums;
using Common.Communication.Responses;

namespace Common.Communication.Requests
{
    [DataContract()]
    class PingRequest : Request
    {
        public override RequestType Type => RequestType.PING;

        public override Response GetResponse()
        {
            return new PingResponse();
        }
    }
}
