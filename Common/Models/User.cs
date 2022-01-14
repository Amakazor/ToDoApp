using Common.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Linq;
using Common.Security;

namespace Common.Models
{
    [DataContract()]
    [Table("User")]
    public class User
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember(IsRequired = true)]
        public int? UserID { get; set; }

        [MaxLength(64)]
        [Required]
        [DataMember(IsRequired = true)]
        public string FirstName { get; set; }

        [MaxLength(64)]
        [Required]
        [DataMember(IsRequired = true)]
        public string LastName { get; set; }

        [MaxLength(64)]
        [Required]
        [DataMember(IsRequired = true)]
        public string Username { get; set; }

        [MaxLength(1024)]
        [Required]
        [DataMember(IsRequired = true)]
        public string Password { get; set; }

        [Required]
        [DataMember(IsRequired = true)]
        public UserType UserType { get; set; }


        public User(string firstName, string lastName, string username, string password, UserType userType)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password;
            UserType = userType;
        }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public bool Authenticate()
        {
            using DatabaseContext dbContext = new();
            User dbUser = (from user in dbContext.Users where user.Username.Equals(Username) select user).FirstOrDefault();
            bool authentic = dbUser != null && HashedPassword.VerifySaltedPassword(Password, dbUser.Password);

            if (authentic)
            {
                FirstName = dbUser.FirstName;
                LastName = dbUser.LastName;
                UserType = dbUser.UserType;
            }

            return authentic;
        }

        public bool Register()
        {
            using DatabaseContext dbContext = new();
            User dbUser = (from user in dbContext.Users where user.Username.Equals(Username) select user).FirstOrDefault();

            if (dbUser is null)
            {
                HashPassword();
                dbContext.Users.Add(this);
                dbContext.SaveChanges();

                return true;
            }

            return false;
        }

        public void HashPassword()
        {
            Password = HashedPassword.GenerateSaltedHash(16, Password);
        }
    }
}
