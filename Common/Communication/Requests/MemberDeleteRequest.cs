using Common.Communication.Requests.Enums;
using Common.Models;
using System.Runtime.Serialization;

namespace Common.Communication.Requests
{
    [DataContract()]
    public class MemberDeleteRequest : MemberRequest
    {
        public MemberDeleteRequest(string username, string password, User member, Tasklist tasklist) : base(username, password, member, tasklist)
        {
        }

        [DataMember(IsRequired = true)]
        public override RequestType Type => RequestType.TASKLIST_MEMBER_REMOVE;
    }
}
