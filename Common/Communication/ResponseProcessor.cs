using Common.Communication.Responses.Enums;
using Common.Communication.Responses;
using Common.Serialization;

namespace Common.Communication
{
    public static class ResponseProcessor
    {
        public static void Process(string responseData, ResponseHandler responseHandler)
        {
            switch (Serializer.DeserializeObject<Response>(responseData).Type)
            {
                case ResponseType.PING:
                    Serializer.DeserializeObject<PingResponse>(responseData).Process(responseHandler.HandlePingResponse);
                    Serializer.DeserializeObject<NullResponse>(responseData).Process(responseHandler.HandleNullResponse);
                    break;
            }
        }
    }
}
