using Common.Models;

namespace Common.Communication.Responses.ResponseEvents
{
    public class LoginResponseEventArgs : ResponseEventArgs
    {
        public LoginResponseEventArgs(bool userLogged, User user) : base()
        {
            UserLogged = userLogged;
            User = user;
        }

        public bool UserLogged { get; }
        public User User { get; }
    }
}
