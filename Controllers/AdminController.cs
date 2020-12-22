using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InternetBasedDiscussionForum.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View("PendingUsers");
        }
        public ActionResult ListThreads()
        {
            return View();
        }
    }
}