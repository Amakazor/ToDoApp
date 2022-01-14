using Common.Models;
using System.Collections.Generic;

namespace Common.Communication.Responses.ResponseEvents
{
    public class TasklistGetResponseEventArgs : ResponseEventArgs
    {
        public TasklistGetResponseEventArgs(HashSet<Tasklist> tasklists) : base()
        {
            Tasklists = tasklists;
        }

        public HashSet<Tasklist> Tasklists { get; }
    }
}
