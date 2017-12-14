using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SimplyRegister.Models
{
    public class Registration
    {
        [Key]
        public int registrationId { get; set; }

        [ForeignKey("customerId")]
        public virtual Customer Customers { get; set; }
        [Display(Name = "Customer")]
        public int customerId { get; set; }

        [ForeignKey("eventId")]
        public virtual Event Events { get; set; }

        [Display(Name = "Event")]
        public int eventId { get; set; }

        public double amountBilled { get; set; }

        public double amountPaid { get; set; }

        public bool invoiceRequested { get; set; }

        public bool invoiceSent { get; set; }

        //public virtual ICollection<Event> Events { get; set; }
        //public virtual ICollection<Customer> Customers { get; set; }


        












    }
}