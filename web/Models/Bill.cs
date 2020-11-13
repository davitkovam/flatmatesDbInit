using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class Bill{
        [Key]
        public int billID { get; set; }
        public int userID { get; set; }

        public int householdID { get; set; }

        public string content { get; set; }

        public int cost { get; set; }

        public Boolean paid { get; set; }

    
    }
}