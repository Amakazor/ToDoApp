using Common.Communication.Requests.Enums;
using Common.Models;
using System.Runtime.Serialization;

namespace Common.Communication.Requests
{
    [DataContract()]
    public class TaskstatusAddRequest : TaskStastusRequest
    {
        public TaskstatusAddRequest(string username, string password, TaskStatus taskStatus, Tasklist tasklist) : base(username, password, taskStatus, tasklist)
        {
        }

        [DataMember(IsRequired = true)]
        public override RequestType Type => RequestType.TASKSTATUS_ADD;
    }
}
