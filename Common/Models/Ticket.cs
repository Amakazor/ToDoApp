using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Common.Models.Enums;

namespace Common.Models
{
    public class Ticket
    {
        public Ticket(string name, string description, User author, TicketStatus status)
        {
            Name = name;
            Description = description;
            Author = author;
            Status = status;
        }
        public Ticket()
        { 
        }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember(IsRequired = true)]
        public int? TicketId { get; set; }

        [MaxLength(64)]
        [Required]
        [DataMember(IsRequired = true)]
        public string Name { get; set; }

        [Required]
        [StringLength(128)]
        [DataMember(IsRequired = true)]
        public string Description { get; set; }

        [Required]
        [StringLength(128)]
        [DataMember(IsRequired = true)]
        public string Note { get; set; }

        [Required]
        [DataMember(IsRequired = true)]
        public User Author { get; set; }

        [Required]
        [DataMember(IsRequired = true)]
        public TicketStatus Status { get; set; }

        [DataMember(IsRequired = true)]
        public User LastChangedBy { get; set; }

        public static HashSet<Ticket> GetAll(User user)
        {
            if (user.UserType == UserType.HELPDESK)
            {
                using DatabaseContext dbContext = new();
                return (from ti in dbContext.Tickets select ti).ToHashSet();
            }
            else
            {
                using DatabaseContext dbContext = new();
                return (from ti in dbContext.Tickets where ti.Author.UserID.Equals(user.UserID) select ti).ToHashSet();
            }
        }

        public static string TryUpdate(User user, Ticket ticket)
        {
            if (ticket is null) return "Tasklist doesn't exists";
            if (user.UserType != UserType.HELPDESK) return "User is not a helpdesk member";

            using DatabaseContext dbContext = new();

            Ticket dbTicket = (from ti in dbContext.Tickets where ti.Author.UserID.Equals(user.UserID) select ti).FirstOrDefault();

            if (dbTicket is null) return "Tasklist doesn't exists";

            dbTicket.Status = ticket.Status;
            dbTicket.LastChangedBy = user;

            dbContext.SaveChanges();

            return null;
        }

        public static string TryAdd(User user, Ticket ticket)
        {
            if (ticket is null) return "Ticket doesn't exists";

            using DatabaseContext dbContext = new();

            Ticket dbTicket = (from ti in dbContext.Tickets where ti.Author.UserID.Equals(user.UserID) select ti).FirstOrDefault();

            if (dbTicket is not null) return "Ticket already exists";

            dbContext.Tickets.Add(ticket);
            dbContext.SaveChanges();

            return null;
        }
    }
}
