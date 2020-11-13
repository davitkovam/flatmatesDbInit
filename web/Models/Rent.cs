using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class Rent{
        [Key]
        public int rentID { get; set; }

        public string month { get; set; }

        public Boolean paid { get; set; }

        public int amount { get; set; }

        public int householdID { get; set; }

    
    }
}