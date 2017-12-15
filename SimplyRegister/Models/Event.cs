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
        [Display(Name = "Event Name")]
        public string eventName { get; set; }
        [Display(Name = "Event Date")]
        public DateTime eventDate { get; set; }
        [Display(Name = "Event Type")]
        public string eventType { get; set; }//Corporate, Training, CLC, other
        [Display(Name = "Corporate Price")]
        public double corporatePrice { get; set; }
        [Display(Name = "Associate Price")]
        public double assocaitePrice { get; set; }
        [Display(Name = "CBA Price")]
        public double cbaPrice { get; set; }
        [Display(Name = "IAP Price")]
        public double iapPrice { get; set; }
        [Display(Name = "Non-Member Price")]
        public double nonMemberPrice { get; set; }

        public List<Customer> Registration { get; set; }


        public virtual ICollection<Registration> Registrations { get; set; }


    }
}