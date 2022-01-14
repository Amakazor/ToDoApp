using Common.Communication.Requests.Enums;
using Common.Communication.Responses.Enums;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Communication.Requests
{
    [DataContract()]
    internal class HelpdeskTicketUpdateRequest : TickedRequest
    {
        public HelpdeskTicketUpdateRequest(string username, string password, Ticket ticket) : base(username, password, ticket)
        {
        }

        [DataMember(IsRequired = true)]
        public override RequestType Type => RequestType.HELPDESK_TICKET_UPDATE;
    }
}
