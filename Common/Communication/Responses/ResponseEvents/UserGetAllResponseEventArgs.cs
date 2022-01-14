using Common.Models;
using System.Collections.Generic;

namespace Common.Communication.Responses.ResponseEvents
{
    public class UserGetAllResponseEventArgs : ResponseEventArgs
    {
        public UserGetAllResponseEventArgs(HashSet<User> users) : base()
        {
            Users = users;
        }

        public HashSet<User> Users { get; }
    }
}
