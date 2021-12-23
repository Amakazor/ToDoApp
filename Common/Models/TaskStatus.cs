using Common.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Drawing;


namespace Common.Models
{
    [Table("TaskStatus")]
    public class TaskStatus
    {
        [ForeignKey(nameof(TaskStatusId))]
        public Tasklist Id { get; set; }
        public int? TaskStatusId { get; set; }

        [Required]
        [StringLength(128)]
        public Guid Guid { get; }

        [MaxLength(64)]
        [Required]
        public string Name { get; set; }

        [NotMapped]
        public Color Color { get; set; }

        public TaskStatus()
        {
        }

        public TaskStatus(Guid guid, string name, Color color)
        {
            this.Guid = guid;
            this.Name = name;
            this.Color = color;
        }
    }
}
