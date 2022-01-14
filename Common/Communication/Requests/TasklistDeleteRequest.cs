using Common.Communication.Requests.Enums;
using System.Runtime.Serialization;
using Common.Models;

namespace Common.Communication.Requests
{
    [DataContract()]
    public class TasklistDeleteRequest : TasklistRequest
    {
        public TasklistDeleteRequest(string username, string password, Tasklist tasklist) : base(username, password, tasklist)
        {
        }

        [DataMember(IsRequired = true)]
        public override RequestType Type => RequestType.TASKLIST_DELETE;
    }
}
