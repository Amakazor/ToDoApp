using Common.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;


namespace Common.Models
{

    [Table("TaskList")]
    public class Tasklist
    {
        [Required]
        [StringLength(128)]
        public Guid Guid { get; }

        [MaxLength(64)]
        [Required]
        public string Name { get; set; }

        [MaxLength(64)]
        [Required]
        public User Owner { get; }
                
        //public HashSet<User> Members { get; }
        public HashSet<User> Members { get; set; } = new HashSet<User>();

        //public HashSet<Task> Tasks { get; }
        public HashSet<Task> Tasks { get; set; } = new HashSet<Task>();

        //public HashSet<TaskStatus> TaskStatuses { get; }
        public HashSet<TaskStatus> TaskStatuses { get; set; } = new HashSet<TaskStatus>();

    }
}
