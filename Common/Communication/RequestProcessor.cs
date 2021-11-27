using Common.Communication.Requests;
using Common.Communication.Requests.Enums;
using Common.Communication.Responses;
using Common.Serialization;

namespace Common.Communication
{
    public static class RequestProcessor
    {
        public static Response Process(string requestData, Server server)
        {
            return Serializer.DeserializeObject<Request>(requestData).Type switch
            {
                RequestType.PING => Serializer.DeserializeObject<PingRequest>(requestData).GetResponse(),
                _ => throw new System.NotImplementedException(),
            };
        }
    }
}
