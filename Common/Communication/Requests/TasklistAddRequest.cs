using Common.Communication.Requests.Enums;
using Common.Communication.Requests.RequestEvents;
using System.Runtime.Serialization;
using Common.Models;

namespace Common.Communication.Requests
{
    [DataContract()]
    public class TasklistAddRequest : TasklistRequest
    {
        public TasklistAddRequest(string username, string password, Tasklist tasklist) : base(username, password, tasklist)
        {
        }

        [DataMember(IsRequired = true)]
        public override RequestType Type => RequestType.TASKLIST_ADD;
    }
}
