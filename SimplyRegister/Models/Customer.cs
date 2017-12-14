using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SimplyRegister.Models
{
    public class Customer
    {
        [Key]
        public int customerId { get; set; }

        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        [Display(Name = "Company")]
        public int customerCompany { get; set; }

        [Display(Name = "CLC Member")]
        public bool clcMember { get; set; }

        public bool isAdmin { get; set; }

        public Company company { get; set; }
        [Display(Name = "Company Name")]
        public int? companyId { get; set; }

        public IEnumerable<Company> Companies { get; set; }

        public virtual ICollection<Event> Events { get; set; }

        [ForeignKey("userId")]
        public virtual ApplicationUser user { get; set; }
        public string userId { get; set; }
      







    }
}