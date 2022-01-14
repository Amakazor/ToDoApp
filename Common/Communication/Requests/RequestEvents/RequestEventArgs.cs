using Common.Communication.Responses;
using Common.Models;
using System;

namespace Common.Communication.Requests.RequestEvents
{
    public class RequestEventArgs : EventArgs
    {
        public RequestEventArgs(User user)
        {
            User = user;
            ResponseHandle = null;
        }

        public User User { get; }
        public Response ResponseHandle { get; set; }
    }
}
