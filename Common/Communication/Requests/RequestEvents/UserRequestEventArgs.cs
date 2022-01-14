using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Communication.Requests.RequestEvents
{
    public class UserRequestEventArgs : RequestEventArgs
    {
        public UserRequestEventArgs(User user) : base(user)
        {
        }
    }
}
