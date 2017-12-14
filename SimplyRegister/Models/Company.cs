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

        public string companyName { get; set; }
        
        public string mainContactEmail { get; set; }

        public string companyMembershipLevel { get; set; }//Corporate, Associate, CBA, IAP, Non-Member
    }
}