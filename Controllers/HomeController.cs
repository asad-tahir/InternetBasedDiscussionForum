﻿using InternetBasedDiscussionForum.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InternetBasedDiscussionForum.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //if (User.IsInRole(UserRole.Admin))
            //{
                
            //}
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}