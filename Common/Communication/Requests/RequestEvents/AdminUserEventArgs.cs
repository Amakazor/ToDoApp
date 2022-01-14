using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Communication.Requests.RequestEvents
{
    public class AdminUserEventArgs : RequestEventArgs
    {
        public AdminUserEventArgs(User admin, User modifiedUser) : base(admin)
        {
            ModifiedUser = modifiedUser;
        }

        public User ModifiedUser { get; }
    }
}
