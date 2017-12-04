using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimplyRegister.Models
{
    public class Administrator
    {
        [Key]
        public string adminId { get; set; }

        public string adminFirstName { get; set; }

        public string adminLastName { get; set; }

        public bool adminCurrentEmployee { get; set; }

    }
}