using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Common.Entities
{
    [DataContract()]
    public class Tasklist
    {
        [DataMember(IsRequired = true)]
        public Guid Guid { get; }

        [DataMember(IsRequired = true)]
        public string Name { get; set; }

        [DataMember(IsRequired = true)]
        public User Owner { get; }

        [DataMember(IsRequired = true)]
        public HashSet<User> Members { get; }

        [DataMember(IsRequired = true)]
        public HashSet<Task> Tasks { get; }

        [DataMember(IsRequired = true)]
        public HashSet<TaskStatus> TaskStatuses { get; }
    }
}
