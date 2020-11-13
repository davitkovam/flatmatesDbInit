using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class Tenant{
        [Key]
        public int tenantID {get; set;}
        public int userID { get; set; }

        public int householdID { get; set; }

        public string role { get; set; }

    
    }
}