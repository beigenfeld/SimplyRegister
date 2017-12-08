using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimplyRegister.Models
{
    public class Customer
    {
        public int customerId { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public int customerCompany { get; set; }

        public bool clcMember { get; set; }

        public bool isAdmin { get; set; }

        public Company company { get; set; }
        [Display(Name = "Company Name")]
        public int? companyId { get; set; }

        public IEnumerable<Company> Companies { get; set; }
    }
}