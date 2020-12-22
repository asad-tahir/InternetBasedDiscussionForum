using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternetBasedDiscussionForum.ViewModels
{
    public class ListThreadsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsApproved { get; set; }
        public bool IsFavourite { get; set; }
        public string AuthorName { get; set; }
    }
}