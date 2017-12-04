using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimplyRegister.Models
{
    public class Company
    {
        public string companyId { get; set; }

        public string companyName { get; set; }
        
        public string mainContactEmail { get; set; }

        public string companyMembershipLevel { get; set; }//Corporate, Assocaite, CBA, IAP, Non-Member
    }
}