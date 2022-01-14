using Common.Communication.Requests.Enums;
using Common.Communication.Requests.RequestEvents;
using Common.Models;
using System.Runtime.Serialization;

namespace Common.Communication.Requests
{
    [DataContract()]
    public abstract class TickedRequest : Request
    {
        public TickedRequest(string username, string password, Ticket ticket) : base(username, password)
        {
            Ticket = ticket;
        }

        [DataMember(IsRequired = true)]
        public Ticket Ticket { get; }

        protected new TicketRequestEventArgs eventArgs;

        public override TicketRequestEventArgs EventArgs
        {
            get
            {
                if (eventArgs == null) eventArgs = new(new(Username, Password), Ticket);
                return eventArgs;
            }
        }
    }
}
