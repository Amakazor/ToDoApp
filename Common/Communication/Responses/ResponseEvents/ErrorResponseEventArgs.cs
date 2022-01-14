using Common.Models;

namespace Common.Communication.Responses.ResponseEvents
{
    public class ErrorResponseEventArgs : ResponseEventArgs
    {
        public ErrorResponseEventArgs(string message) : base()
        {
            Message = message;
        }

        public string Message { get; }
    }
}
