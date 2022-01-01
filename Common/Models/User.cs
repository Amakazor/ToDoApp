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

    [Table("User")]
    
    public class User
    {
        [ForeignKey(nameof(UserId))]
        public Tasklist Id { get; set; }
        public int? UserId { get; set; }

        [MaxLength(64)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(64)]
        [Required]
        public string Lastname { get; set; }

        [MaxLength(64)]
        [Required]
        public string Username { get; set; }

        [MaxLength(64)]
        [Required]
        public string Password { get; set; }

        [Required]
        public UserType UserType { get; set; }
        public User()
        {
        }
        public User(string firstName, string lastName, string username,string password, UserType userType, Tasklist id)
        {
            this.FirstName = firstName;
            this.Lastname = lastName;
            this.Username = username;
            this.Password = password;
            this.UserType = userType;
            this.Id = id;
        }
    }
}
