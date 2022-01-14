using Common.Communication.Responses.Enums;
using Common.Communication.Responses.ResponseEvents;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Communication.Responses
{
    [DataContract()]
    public class TasklistGetResponse : Response
    {
        public TasklistGetResponse(HashSet<Tasklist> tasklists) : base()
        {
            Tasklists = tasklists;
        }

        [DataMember(IsRequired = true)]
        public HashSet<Tasklist> Tasklists { get; }


        [DataMember(IsRequired = true)]
        public override ResponseType Type => ResponseType.TASKLIST_GET;

        protected new TasklistGetResponseEventArgs eventArgs;

        public override TasklistGetResponseEventArgs EventArgs
        {
            get
            {
                if (eventArgs == null) eventArgs = new(Tasklists);
                return eventArgs;
            }
        }

    }
}
