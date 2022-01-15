using Common.Models;
using System;
using System.Collections.Generic;

namespace WinFormsClient
{
    public class TasklistsChangedEventArgs : EventArgs
    {
        public TasklistsChangedEventArgs(List<Tasklist> tasklists)
        {
            Tasklists = tasklists;
        }

        public List<Tasklist> Tasklists { get; set; }
    }
}
