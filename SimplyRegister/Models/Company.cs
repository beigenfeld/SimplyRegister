using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimplyRegister.Models
{
    public class Company
    {
        [Key]
        public int companyId { get; set; }
        [Display(Name = "Company Name")]
        public string companyName { get; set; }
        [Display(Name = "Main Contact Email")]
        public string mainContactEmail { get; set; }
        [Display(Name = "Company Membership Level")]
        public string companyMembershipLevel { get; set; }//Corporate, Associate, CBA, IAP, Non-Member
    }
}