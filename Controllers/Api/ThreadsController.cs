using InternetBasedDiscussionForum.Models;
using InternetBasedDiscussionForum.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InternetBasedDiscussionForum.Controllers.Api
{
    public class ThreadsController : ApiController
    {
        ApplicationDbContext _context;
        public ThreadsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        ///api/threads
        [HttpGet]
        [Authorize(Roles = UserRole.Student + "," + UserRole.Alumni + "," + UserRole.Teacher)]
        public IHttpActionResult Threads()
        {
            var threads = _context.Threads.Include(t => t.User).Where(t => t.IsApproved).ToList();
            List<ListThreadsViewModel> ViewModelList = new List<ListThreadsViewModel>();
            foreach(var thread in threads)
            {
                var ViewModel = new ListThreadsViewModel{
                    Id = thread.Id,
                    AuthorName = thread.User.Name,
                    IsFavourite = thread.IsFavourite,
                    Title = thread.Title,
                    IsApproved = thread.IsApproved
                };
                ViewModelList.Add(ViewModel);
            }
            return Ok(ViewModelList);
        }
        /// api/threads/id
        [Authorize]
        [HttpGet]
        public IHttpActionResult Threads(int id)
        {
            
            var thread = _context.Threads.Include(t => t.User).SingleOrDefault(t => t.Id == id);
            
            if (thread == null)
            {
                return NotFound();
            }
            var ViewModel = new ListThreadsViewModel
            {
                Id = thread.Id,
                AuthorName = thread.User.Name,
                IsFavourite = thread.IsFavourite,
                Title = thread.Title,
                IsApproved = thread.IsApproved,
                Body = thread.Body
            };
            if (!ViewModel.IsApproved)
            {
                if (User.IsInRole(UserRole.Admin))
                    return Ok(ViewModel);
                else
                    return Ok();
            }
            return Ok(ViewModel);
        }

    }
}
