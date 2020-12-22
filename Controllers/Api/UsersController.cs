using InternetBasedDiscussionForum.Models;
using InternetBasedDiscussionForum.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InternetBasedDiscussionForum.Controllers.Api
{
    public class UsersController : ApiController
    {
        ApplicationDbContext _context;
        public UsersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        [HttpGet]
        public IHttpActionResult PendingUsers()
        {
            var users = _context.Users.Where(u => !(u.IsActive)).ToList();
            List<PendingUsersViewModel> pendingUsers = new List<PendingUsersViewModel>();
            foreach(var user in users)
            {
                PendingUsersViewModel pendingUser = new PendingUsersViewModel
                {
                    Name = user.Name,
                    Email = user.Email,
                    Id = user.Id
                };
                pendingUsers.Add(pendingUser);
            }
            return Ok(pendingUsers);
        }
    }
}
