using System;
using System.Runtime.Serialization;
using Common.Entities.Enums;

namespace Common.Entities
{
    [DataContract()]
    public class User : IEquatable<User>
    {
        [DataMember(IsRequired = true)]
        public string FirstName { get; set; }

        [DataMember(IsRequired = true)]
        public string Lastname { get; set; }

        [DataMember(IsRequired = true)]
        public string Username { get; set; }

        [DataMember(IsRequired = true)]
        public string Password { get; set; }

        [DataMember(IsRequired = true)]
        public UserType UserType { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as User);
        }

        public bool Equals(User other)
        {
            return other != null &&
                   Username == other.Username;
        }

        public override int GetHashCode()
        {
            return Username.GetHashCode();
        }

        public override string ToString()
        {
            return FirstName + " " + Lastname + ": " + Username;
        }
    }
}
