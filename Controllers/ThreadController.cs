using InternetBasedDiscussionForum.Models;
using InternetBasedDiscussionForum.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InternetBasedDiscussionForum.Controllers
{
    public class ThreadController : Controller
    {
        ApplicationDbContext _context;
        public ThreadController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Threads
        [Authorize(Roles = UserRole.Student + "," + UserRole.Alumni + "," + UserRole.Teacher)]
        public ActionResult Index()
        {
            return View("Threads");
        }
        [Authorize]
        public ActionResult ViewThread(int id)
        {
            ViewBag.id = id;
            return View();
        }
        
        [Authorize(Roles = UserRole.Student + "," + UserRole.Alumni + "," + UserRole.Teacher)]
        public ActionResult NewThread()
        {
            var model = new Thread();
            return View(model);
        }
        [Authorize(Roles = UserRole.Student + "," + UserRole.Alumni + "," + UserRole.Teacher)]
        [HttpPost]
        public ActionResult NewThread(Thread model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.CreatedOn = DateTime.UtcNow;
            model.UserId = User.Identity.GetUserId();
            _context.Threads.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index", "Thread");
        }
        
    }
}