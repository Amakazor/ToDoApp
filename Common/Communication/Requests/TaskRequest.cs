using Common.Communication.Requests.Enums;
using Common.Communication.Requests.RequestEvents;
using Common.Models;
using System.Runtime.Serialization;

namespace Common.Communication.Requests
{
    [DataContract()]
    public abstract class TaskRequest: Request
    {
        public TaskRequest(string username, string password, Task task, Tasklist tasklist) : base(username, password)
        {
            Task = task;
            Tasklist = tasklist;
        }

        [DataMember(IsRequired = true)]
        public Task Task { get; private set; }
        [DataMember(IsRequired = true)]
        public Tasklist Tasklist { get; private set; }

        protected new TaskRequestEventArgs eventArgs;

        public override TaskRequestEventArgs EventArgs
        {
            get
            {
                if (eventArgs == null) eventArgs = new(new(Username, Password), Task, Tasklist);
                return eventArgs;
            }
        }
    }
}
