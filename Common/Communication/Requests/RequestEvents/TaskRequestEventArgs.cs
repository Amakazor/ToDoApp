using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Communication.Requests.RequestEvents
{
    public class TaskRequestEventArgs: RequestEventArgs
    {
        public TaskRequestEventArgs(User user, Task task, Tasklist tasklist) : base(user)
        {
            Task = task;
            Tasklist = tasklist;
        }

        public Models.Task Task { get; }
        public Tasklist Tasklist { get; }
    }
}
