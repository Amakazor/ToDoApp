using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Communication.Requests.RequestEvents
{
    public class TaskStatusRequestEventArgs : RequestEventArgs
    {
        public TaskStatusRequestEventArgs(User user, TaskStatus taskStatus, Tasklist tasklist) : base(user)
        {
            TaskStatus = taskStatus;
            Tasklist = tasklist;
        }

        public TaskStatus TaskStatus { get; }
        public Tasklist Tasklist { get; }
    }
}
