using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InternetBasedDiscussionForum.Models
{
    public class Thread
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        public DateTime CreatedOn { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public bool IsApproved { get; set; } = false;
        public bool IsFavourite { get; set; } = false; 
    }
}