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
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_TaskList_number { get; set; }

        [Required]
        [StringLength(128)]
        public Guid Guid { get; set; }

        [MaxLength(64)]
        [Required]
        public string Name { get; set; }

        [MaxLength(64)]
        public User Owner { get; set; }
       
        //public HashSet<User> Members { get; }
        public HashSet<User> Members { get; set; } = new HashSet<User>();


        //public HashSet<Task> Tasks { get; }
        public HashSet<Task> Tasks { get; set; } = new HashSet<Task>();

        public HashSet<TaskStatus> TaskStatuses { get; set; } = new HashSet<TaskStatus>();
        //public HashSet<TaskStatus> TaskStatuses { get; set; } = new HashSet<TaskStatus>();
        //public TaskStatus TaskStatuses { get; set; }

    }
}
