using Common.Communication.Requests.Enums;
using Common.Communication.Requests.RequestEvents;
using Common.Models;
using System.Runtime.Serialization;

namespace Common.Communication.Requests
{
    [DataContract()]
    public abstract class TaskStastusRequest : Request
    {
        public TaskStastusRequest(string username, string password, TaskStatus taskStatus, Tasklist tasklist) : base(username, password)
        {
            TaskStatus = taskStatus;
            Tasklist = tasklist;
        }

        [DataMember(IsRequired = true)]
        public TaskStatus TaskStatus { get; }

        [DataMember(IsRequired = true)]
        public Tasklist Tasklist { get; }

        protected new TaskStatusRequestEventArgs eventArgs;

        public override TaskStatusRequestEventArgs EventArgs
        {
            get
            {
                if (eventArgs == null) eventArgs = new(new(Username, Password), TaskStatus, Tasklist);
                return eventArgs;
            }
        }
    }
}
