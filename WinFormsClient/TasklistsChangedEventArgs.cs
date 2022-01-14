using Common.Models;
using System;
using System.Collections.Generic;

namespace WinFormsClient
{
    public class TasklistsChangedEventArgs : EventArgs
    {
        public TasklistsChangedEventArgs(HashSet<Tasklist> tasklists)
        {
            Tasklists = tasklists;
        }

        public HashSet<Tasklist> Tasklists { get; set; }
    }
}
