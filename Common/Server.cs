using System.Net;
using System.Net.Sockets;

namespace Common
{
    public abstract class Server : TcpListener
    {
        protected Server(IPAddress localaddr, int port) : base(localaddr, port)
        {
        }
    }
}
