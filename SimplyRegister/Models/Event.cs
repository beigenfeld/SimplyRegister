using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SimplyRegister.Models
{
    public class Event
    {
        public int eventId { get; set; }

        public string eventName { get; set; }

        public DateTime eventDate { get; set; }

        public string eventType { get; set; }//Corporate, Training, CLC, other

        public double corporatePrice { get; set; }

        public double assocaitePrice { get; set; }

        public double cbaPrice { get; set; }

        public double iapPrice { get; set; }

        public double nonMemberPrice { get; set; }

        public List<Customer> Registration { get; set; }


        public virtual ICollection<Registration> Registrations { get; set; }


    }
}