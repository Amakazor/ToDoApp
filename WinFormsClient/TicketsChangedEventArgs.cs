using Common.Models;
using System;
using System.Collections.Generic;

namespace WinFormsClient
{
    public class TicketsChangedEventArgs: EventArgs
    {
        public TicketsChangedEventArgs(HashSet<Ticket> tickets)
        {
            Tickets = tickets;
        }

        public HashSet<Ticket> Tickets { get; set; }
    }
}
