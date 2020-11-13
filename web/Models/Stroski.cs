using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class Stroski{
        [Key]
        public int strosekID { get; set; }

        public string month { get; set; }

        public int householdID { get; set; }
        public int amount { get; set; }

        public Boolean paid { get; set; }

        public string description { get; set;   } 


    
    }
}