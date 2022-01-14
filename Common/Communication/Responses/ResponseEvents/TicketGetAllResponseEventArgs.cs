using Common.Models;
using System.Collections.Generic;

namespace Common.Communication.Responses.ResponseEvents
{
    public class TicketGetAllResponseEventArgs : ResponseEventArgs
    {
        public TicketGetAllResponseEventArgs(HashSet<Ticket> tickets) : base()
        {
            Tickets = tickets;
        }

        public HashSet<Ticket> Tickets { get; }
    }
}
