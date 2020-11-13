using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class Inventory{
        [Key]
        public int itemID { get; set; }
        public int householdID { get; set; }

        public string categoryName { get; set; }

        

        public string itemName { get; set;   } 

        public Boolean essential { get; set; }


    
    }
}