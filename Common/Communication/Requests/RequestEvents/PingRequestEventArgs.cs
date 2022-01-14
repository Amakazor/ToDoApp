using Common.Models;

namespace Common.Communication.Requests.RequestEvents
{
    public class PingRequestEventArgs : RequestEventArgs
    {
        public PingRequestEventArgs(User user, string message) : base(user)
        {
            Message = message;
        }

        public string Message { get; }
    }
}
