using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class Korisnik{
        [Key]
        public int userID { get; set; }

        public string name { get; set; }

        public string surname { get; set;   } 

        public string email { get; set; }

        public string phone_number { get; set; }

        public string password { get; set; }

    
    }
}