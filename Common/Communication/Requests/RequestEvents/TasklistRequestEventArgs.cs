using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Communication.Requests.RequestEvents
{
    public class TasklistRequestEventArgs : RequestEventArgs
    {
        public TasklistRequestEventArgs(User user, Tasklist tasklist) : base(user)
        {
            Tasklist = tasklist;
        }

        public Tasklist Tasklist { get; }
    }
}
