using System.Net.Sockets;

namespace Common
{
    public abstract class ResponseHandler
    {
        public abstract void HandlePingResponse();
        public abstract void HandleNullResponse();
    }
}
