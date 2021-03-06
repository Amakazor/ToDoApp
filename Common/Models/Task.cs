using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Models
{
    [Table("Task")]
    [DataContract()]
    public class Task
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember(IsRequired = true)]
        public int? TaskId { get; set; }

        [MaxLength(64)]
        [Required]
        [DataMember(IsRequired = true)]
        public string Name { get; set; }

        [Required]
        [StringLength(128)]
        [DataMember(IsRequired = true)]
        public string Description { get; set; }

        [Required]
        [DataMember(IsRequired = true)]
        public User Author { get; set; }

        [Required]
        [DataMember(IsRequired = true)]
        public TaskStatus Status { get; set; }

        [Required]
        [DataMember(IsRequired = true)]
        public Tasklist Tasklist { get; set; }

        public Task(string name, string description, User author, TaskStatus status)
        {
            Name = name;
            Description = description;
            Author = author;
            Status = status;
        }

        private Task()
        {}

        public override string ToString()
        {
            return Name + ": " + Status.ToString();
        }
    }
}
