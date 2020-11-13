using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class Chore{
        [Key]
        public int choreID { get; set; }
        public int userID { get; set; }

        public int householdID { get; set; }

        public string choredesc { get; set; }

        public string duration {get; set; }

        public string repetition {get; set;}

        public Boolean finished { get; set; }        

    
    }
}