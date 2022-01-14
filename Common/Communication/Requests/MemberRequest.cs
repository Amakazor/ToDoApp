using Common.Communication.Requests.Enums;
using Common.Communication.Requests.RequestEvents;
using Common.Models;
using System.Runtime.Serialization;

namespace Common.Communication.Requests
{
    [DataContract()]
    public abstract class MemberRequest: Request
    {
        public MemberRequest(string username, string password, User member, Tasklist tasklist) : base(username, password)
        {
            Member = member;
            Tasklist = tasklist;
        }

        [DataMember(IsRequired = true)]
        public User Member { get; private set; }

        [DataMember(IsRequired = true)]
        public Tasklist Tasklist { get; private set; }

        protected new MemberRequestEventArgs eventArgs;

        public override MemberRequestEventArgs EventArgs
        {
            get
            {
                if (eventArgs == null) eventArgs = new(new(Username, Password), Member, Tasklist);
                return eventArgs;
            }
        }
    }
}
