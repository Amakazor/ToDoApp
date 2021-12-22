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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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

        [ForeignKey(nameof(StatusId))]
        public TaskStatus Status { get; set; }

        public int? StatusId { get; set; }

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
