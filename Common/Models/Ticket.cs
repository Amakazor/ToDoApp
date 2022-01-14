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
    }
}
