using System;
using System.Runtime.Serialization;

namespace Todo.Common.Entities
{
    [DataContract()]
    public class Task : IEquatable<Task>
    {
        [DataMember(IsRequired = true)]
        public Guid Guid { get; }

        [DataMember(IsRequired = true)]
        public string Name { get; set; }

        [DataMember(IsRequired = true)]
        public string Description { get; set; }

        [DataMember(IsRequired = true)]
        public User Author { get; }

        [DataMember(IsRequired = true)]
        public TaskStatus Status { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Task);
        }

        public bool Equals(Task other)
        {
            return other != null &&
                   Guid.Equals(other.Guid);
        }

        public override int GetHashCode()
        {
            return Guid.GetHashCode();
        }

        public override string ToString()
        {
            return Name + ": " + Status.ToString();
        }
    }
}
