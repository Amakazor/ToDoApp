using Common.Communication.Requests.Enums;
using Common.Models;
using System.Runtime.Serialization;

namespace Common.Communication.Requests
{
    [DataContract()]
    internal class MemberAddRequest : MemberRequest
    {
        public MemberAddRequest(string username, string password, User member, Tasklist tasklist) : base(username, password, member, tasklist)
        {
        }

        [DataMember(IsRequired = true)]
        public override RequestType Type => RequestType.TASKLIST_MEMBER_ADD;
    }
}
