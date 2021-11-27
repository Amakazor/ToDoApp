using System.Net.Sockets;

namespace Common
{
    public abstract class Client : TcpClient
    {
        public abstract void HandlePingResponse();
        public abstract void HandleNullResponse();
    }
}
