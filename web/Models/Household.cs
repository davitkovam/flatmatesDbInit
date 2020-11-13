using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class Household{
        [Key]
        public int householdID { get; set; }

        public string address { get; set; }

        public string code { get; set;   } 

        public string description { get; set; }


    
    }
}