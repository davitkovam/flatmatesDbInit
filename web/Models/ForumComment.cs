using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace web.Models
{
    public class ForumComment{
        [Key]
        
        public int commentID {get; set;}
        public int postID { get; set; }
        public int userID { get; set; }


       

        public string content { get; set; }

        public DateTime timestamp {get; set;}

        

    
    }
}