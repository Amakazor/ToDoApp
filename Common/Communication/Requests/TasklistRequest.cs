using Common.Communication.Requests.Enums;
using Common.Communication.Requests.RequestEvents;
using Common.Models;
using System.Runtime.Serialization;

namespace Common.Communication.Requests
{
    [DataContract()]
    public abstract  class TasklistRequest: Request
    {
        public TasklistRequest(string username, string password, Tasklist tasklist) : base(username, password)
        {
            Tasklist = tasklist;
        }

        [DataMember(IsRequired = true)]
        public Tasklist Tasklist { get; private set; }

        protected new TasklistRequestEventArgs eventArgs;

        public override TasklistRequestEventArgs EventArgs
        {
            get
            {
                if (eventArgs == null) eventArgs = new(new(Username, Password), Tasklist);
                return eventArgs;
            }
        }
    }
}
