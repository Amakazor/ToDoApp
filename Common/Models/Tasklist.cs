using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Models
{
    [DataContract()]
    [Table("TaskList")]
    public class Tasklist
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember(IsRequired = true)]
        public int? TaskListID { get; set; }

        [MaxLength(64)]
        [Required]
        [DataMember(IsRequired = true)]
        public string Name { get; set; }

        [Required]
        [DataMember(IsRequired = true)]
        public User Owner { get; set; }

        [Required]
        [DataMember(IsRequired = true)]
        public HashSet<User> Members { get; set; }

        [Required]
        [DataMember(IsRequired = true)]
        public HashSet<Task> Tasks { get; set; }

        [Required]
        [DataMember(IsRequired = true)]
        public HashSet<TaskStatus> TaskStatuses { get; set; }
    }
}
