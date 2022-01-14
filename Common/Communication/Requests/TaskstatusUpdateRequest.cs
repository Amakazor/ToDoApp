using Common.Communication.Requests.Enums;
using Common.Models;
using System.Runtime.Serialization;

namespace Common.Communication.Requests
{
    [DataContract()]
    internal class TaskstatusUpdateRequest : TaskStastusRequest
    {
        public TaskstatusUpdateRequest(string username, string password, TaskStatus taskStatus, Tasklist tasklist) : base(username, password, taskStatus, tasklist)
        {
        }

        [DataMember(IsRequired = true)]
        public override RequestType Type => RequestType.TASKSTATUS_DELETE;
    }
}
