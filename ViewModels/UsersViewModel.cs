﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternetBasedDiscussionForum.ViewModels
{
    public class UsersViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}