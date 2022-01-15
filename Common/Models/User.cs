using Common.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Linq;
using Common.Security;
using System.Collections.Generic;
using System;

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

        [Required]
        [DataMember(IsRequired = true)]
        public UserStatus UserStatus { get; set; }

        [Required]
        [DataMember(IsRequired = true)]
        public HashSet<Tasklist> TasklistsOwned { get; set; }

        [Required]
        [DataMember(IsRequired = true)]
        public HashSet<Tasklist> TasklistsMembered { get; set; }


        public User(string firstName, string lastName, string username, string password, UserType userType, UserStatus userStatus)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password;
            UserType = userType;
            UserStatus = userStatus;
        }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public User Authenticate()
        {
            using DatabaseContext dbContext = new();
            User dbUser = (from user in dbContext.Users where user.Username.Equals(Username) select user).FirstOrDefault();
            bool authentic = dbUser != null && HashedPassword.VerifySaltedPassword(Password, dbUser.Password) && dbUser.UserStatus == UserStatus.ACTIVE;

            if (authentic)
            {
                return dbUser;
            }

            return null;
        }

        public bool Register()
        {
            using DatabaseContext dbContext = new();
            User dbUser = (from user in dbContext.Users where user.Username.Equals(Username) select user).FirstOrDefault();

            if (dbUser is null)
            {
                HashPassword();
                //UserStatus = UserStatus.INACTIVE; // WOULD BE FEASIBLE IF WE WERE ACTUALLY IMPLEMENTING ADMINS
                UserStatus = UserStatus.ACTIVE;
                dbContext.Users.Add(this);
                dbContext.SaveChanges();

                return true;
            }

            return false;
        }

        public static void CreateAdminIfNotExists()
        {
            using DatabaseContext dbContext = new();
            User dbAdmin = (from user in dbContext.Users where user.Username.Equals("admin") select user).FirstOrDefault();
            if (dbAdmin is null)
            {
                User admin = new("admin", "admin", "admin", "admin", UserType.ADMIN, UserStatus.ACTIVE);
                admin.HashPassword();

                dbContext.Users.Add(admin);
                dbContext.SaveChanges();
            }
        }

        public static void CreateUserIfNotExists()
        {
            using DatabaseContext dbContext = new();
            User dbAdmin = (from user in dbContext.Users where user.Username.Equals("user") select user).FirstOrDefault();
            if (dbAdmin is null)
            {
                User admin = new("user", "user", "user", "user", UserType.USER, UserStatus.ACTIVE);
                admin.HashPassword();

                dbContext.Users.Add(admin);
                dbContext.SaveChanges();
            }
        }

        public static void CreateHelpdeskIfNotExists()
        {
            using DatabaseContext dbContext = new();
            User dbAdmin = (from user in dbContext.Users where user.Username.Equals("helpdesk") select user).FirstOrDefault();
            if (dbAdmin is null)
            {
                User admin = new("helpdesk", "helpdesk", "helpdesk", "helpdesk", UserType.HELPDESK, UserStatus.ACTIVE);
                admin.HashPassword();

                dbContext.Users.Add(admin);
                dbContext.SaveChanges();
            }
        }

        public static string Activate(User admin, User newUser)
        {
            if (admin is null) return "Admin doesn't exists";
            if (newUser is null) return "User to activate doesn't exists";

            using DatabaseContext dbContext = new();
            User dbAdmin = (from user in dbContext.Users where user.Username.Equals(admin.Username) select user).FirstOrDefault();
            User dbUser = (from user in dbContext.Users where user.Username.Equals(newUser.Username) select user).FirstOrDefault();
            if (dbAdmin is null) return "Admin doesn't exists";
            if (dbUser is null) return "User to activate doesn't exists";
            if (dbAdmin.UserType != UserType.ADMIN) return "Admin is not admin";
            if (dbUser.UserStatus != UserStatus.INACTIVE) return "User is already active";

            dbUser.UserStatus = UserStatus.ACTIVE;
            dbContext.SaveChanges();

            return null;
        }

        public static string Delete(User admin, User modifiedUser)
        {
            if (admin is null) return "Admin doesn't exists";
            if (modifiedUser is null) return "User to activate doesn't exists";

            using DatabaseContext dbContext = new();
            User dbAdmin = (from user in dbContext.Users where user.Username.Equals(admin.Username) select user).FirstOrDefault();
            User dbUser = (from user in dbContext.Users where user.Username.Equals(modifiedUser.Username) select user).FirstOrDefault();
            if (dbAdmin is null) return "Admin doesn't exists";
            if (dbUser is null) return "User to delete doesn't exists";
            if (dbAdmin.UserType != UserType.ADMIN) return "Admin is not admin";

            dbContext.Users.Remove(dbUser);
            dbContext.SaveChanges();

            return null;
        }

        public static string IsAdminError(User admin)
        {
            if (admin is null) return "Admin doesn't exists";

            using DatabaseContext dbContext = new();
            User dbAdmin = (from user in dbContext.Users where user.Username.Equals(admin.Username) select user).FirstOrDefault();
            if (dbAdmin is null) return "Admin doesn't exists";
            if (dbAdmin.UserType != UserType.ADMIN) return "Admin is not admin";

            return null;
        }

        public static HashSet<User> GetAll(User admin)
        {

            using DatabaseContext dbContext = new();
            return (from user in dbContext.Users select user).ToHashSet();
        }

        public void HashPassword()
        {
            Password = HashedPassword.GenerateSaltedHash(16, Password);
        }

        public void ClearPassword()
        {
            Password = null;
        }
    }
}
