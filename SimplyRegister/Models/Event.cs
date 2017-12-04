using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimplyRegister.Models
{
    public class Event
    {
        public string eventId { get; set; }

        public string eventName { get; set; }

        public DateTime eventDate { get; set; }

        public string eventType { get; set; }//Corporate, Training, CLC, other


    }
}