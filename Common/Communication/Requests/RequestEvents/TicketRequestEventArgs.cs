using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Communication.Requests.RequestEvents
{
    public class TicketRequestEventArgs : RequestEventArgs
    {
        public TicketRequestEventArgs(User user, Ticket ticket) : base(user)
        {
            Ticket = ticket;
        }

        public Ticket Ticket { get; }
    }
}
