using Common.Models;

namespace Common.Communication.Responses.ResponseEvents
{
    public class PingResponsetEventArgs : ResponseEventArgs
    {
        public PingResponsetEventArgs(string message) : base()
        {
            Message = message;
        }

        public string Message { get; }
    }
}
