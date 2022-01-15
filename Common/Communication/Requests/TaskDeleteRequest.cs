using Common.Communication.Requests.Enums;
using Common.Models;
using System.Runtime.Serialization;

namespace Common.Communication.Requests
{
    [DataContract()]
    public class TaskDeleteRequest : TaskRequest
    {
        public TaskDeleteRequest(string username, string password, Task task, Tasklist tasklist) : base(username, password, task, tasklist)
        {
        }

        [DataMember(IsRequired = true)]
        public override RequestType Type => RequestType.TASK_DELETE;
    }
}
