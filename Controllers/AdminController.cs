using InternetBasedDiscussionForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using InternetBasedDiscussionForum.ViewModels;

namespace InternetBasedDiscussionForum.Controllers
{
    [Authorize(Roles = UserRole.Admin)]
    public class AdminController : Controller
    {
        ApplicationDbContext _context;
        public AdminController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PendingUsers()
        {
            return View();
        }
        public ActionResult Threads()
        {
            return View();
        }
        public ActionResult PendingThreads()
        {
            return View();
        }
        public ActionResult NewTeacher()
        {
            return View();
        }
        [HttpGet]
        public JsonResult AllThreads()
        {
            var threads = _context.Threads.Include(t => t.User).ToList();
            List<ListThreadsViewModel> ViewModelList = new List<ListThreadsViewModel>();
            foreach (var thread in threads)
            {
                var ViewModel = new ListThreadsViewModel
                {
                    Id = thread.Id,
                    AuthorName = thread.User.Name,
                    IsFavourite = thread.IsFavourite,
                    Title = thread.Title,
                    IsApproved = thread.IsApproved
                };
                ViewModelList.Add(ViewModel);
            }
            return Json(ViewModelList, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetThreads(int id)
        {
            var thread = _context.Threads.Include(t => t.User).SingleOrDefault(t => t.Id == id);
            
                var ViewModel = new ListThreadsViewModel
                {
                    Id = thread.Id,
                    AuthorName = thread.User.Name,
                    IsFavourite = thread.IsFavourite,
                    Title = thread.Title,
                    IsApproved = thread.IsApproved,
                    Body = thread.Body
                };
            
            return Json(ViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPut]
        public void ThreadAction(int id)
        {
            var thread = _context.Threads.SingleOrDefault(t => t.Id == id);
            if (thread == null)
            {
                return;
            }
            if (thread.IsApproved)
            {
                if (!thread.IsFavourite)
                {
                    thread.IsFavourite = true;
                }
                else
                {
                    thread.IsFavourite = false;
                }
                _context.SaveChanges();
                return;
            }
            thread.IsApproved = true;
            _context.SaveChanges();
            return;
        }

    }
}