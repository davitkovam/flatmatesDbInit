using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class ForumPost{
        [Key]
        public int postID { get; set; }
        public int userID { get; set; }

        public int householdID { get; set; }

        public string content { get; set; }

        public DateTime timestamp {get; set;}

        

    
    }
}