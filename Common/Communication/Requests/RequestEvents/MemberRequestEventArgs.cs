using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Communication.Requests.RequestEvents
{
    public class MemberRequestEventArgs:RequestEventArgs
    {
        public MemberRequestEventArgs(User user, User member, Tasklist tasklist) : base(user)
        {
            Member = member;
            Tasklist = tasklist;
        }

        public User Member { get; }
        public Tasklist Tasklist { get; }
    }
}
