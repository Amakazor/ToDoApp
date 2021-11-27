using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace Common.Entities
{
    [DataContract()]
    public class TaskStatus : IEquatable<TaskStatus>
    {
        [DataMember(IsRequired = true)]
        public Guid Guid { get; }

        [DataMember(IsRequired = true)]
        public string Name { get; set; }

        [DataMember(IsRequired = true)]
        public Color Color { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as TaskStatus);
        }

        public bool Equals(TaskStatus other)
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
            return Name;
        }
    }
}
