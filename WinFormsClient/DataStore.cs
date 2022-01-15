using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsClient
{
    public class DataStore
    {
        private static DataStore instance;

        public static DataStore Instance 
        { 
            get 
            { 
                if (instance is null) 
                { 
                    instance = new DataStore(); 
                }  
                return instance; 
            } 
        }

        public event EventHandler<TicketsChangedEventArgs> TicketsChanged;

        private HashSet<Ticket> allTickets;
        public HashSet<Ticket> AllTickets 
        { 
            get 
            { 
                return allTickets; 
            } 
            
            set 
            { 
                allTickets = value;
                if (TicketsChanged is not null)
                {
                    TicketsChanged(this, new(allTickets));
                }
            } 
        }

        public event EventHandler<TasklistsChangedEventArgs> TakListsChanged;

        private List<Tasklist> allTasklists;
        public List<Tasklist> AllTasklists
        {
            get
            {
                return allTasklists;
            }

            set
            {
                allTasklists = value;
                if (TakListsChanged is not null)
                {
                    TakListsChanged(this, new(allTasklists));
                }
            }
        }

        private DataStore()
        {

        }
    }
}
