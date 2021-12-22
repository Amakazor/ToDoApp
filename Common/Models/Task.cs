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
    [Table("Task")]
    public class Task
    {
        [ForeignKey(nameof(TasklistId))]
        public Tasklist Id { get; set; }
        public int? TasklistId { get; set; }

        [Required]
        [StringLength(128)]
        public Guid Guid { get; }

        [MaxLength(64)]
        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(128)]
        public string Description { get; set; }

        [MaxLength(64)]
        [Required]
        public User Author { get; }
       
        public TaskStatus Status { get; set; }

        public Task()
        {
        }

        public Task(Guid guid, string name, string description, User author, TaskStatus status)
        {
            this.Guid = guid;
            this.Name = name;
            this.Description = description;
            this.Author = author;
            this.Status = status;
        }
    }
}
