using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimplyRegister.Models
{
    public class Customer
    {
        public int customerId { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string customerCompany { get; set; }

        public bool clcMember { get; set; }
    }
}