using Common.Communication.Requests.Enums;
using Common.Models;
using System.Runtime.Serialization;

namespace Common.Communication.Requests
{
    [DataContract()]
    internal class OwnershipGiveRequest : MemberRequest
    {
        public OwnershipGiveRequest(string username, string password, User member, Tasklist tasklist) : base(username, password, member, tasklist)
        {
        }

        [DataMember(IsRequired = true)]
        public override RequestType Type => RequestType.TASKLIST_OWNERSHIP_GIVE;

    }
}
