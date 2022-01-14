using Common.Communication.Responses.Enums;
using Common.Communication.Responses.ResponseEvents;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Communication.Responses
{
    [DataContract()]
    public class TicketGetAllResponse : Response
    {
        public TicketGetAllResponse(HashSet<Ticket> tickets) : base()
        {
            Tickets = tickets;
        }

        [DataMember(IsRequired = true)]
        public HashSet<Ticket> Tickets { get; private set; }


        [DataMember(IsRequired = true)]
        public override ResponseType Type => ResponseType.TICKET_GET_ALL;

        protected new TicketGetAllResponseEventArgs eventArgs;

        public override TicketGetAllResponseEventArgs EventArgs
        {
            get
            {
                if (eventArgs == null) eventArgs = new(Tickets);
                return eventArgs;
            }
        }

    }
}
