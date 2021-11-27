using Common.Communication.Responses.Enums;
using Common.Communication.Responses;
using Common.Serialization;

namespace Common.Communication
{
    public static class ResponseProcessor
    {
        public static void Process(string responseData, Client client)
        {
            switch (Serializer.DeserializeObject<Response>(responseData).Type)
            {
                case ResponseType.PING:
                    Serializer.DeserializeObject<PingResponse>(responseData).Process(client.HandlePingResponse);
                    Serializer.DeserializeObject<NullResponse>(responseData).Process(client.HandleNullResponse);
                    break;
            }
        }
    }
}
