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
    [Authorize(Roles = UserRole.Admin)]
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
        public IHttpActionResult Users()
        {
            var users = _context.Users.ToList();
            List<UsersViewModel> UsersList = new List<UsersViewModel>();
            foreach(var user in users)
            {
                UsersViewModel pendingUser = new UsersViewModel
                {
                    Name = user.Name,
                    Email = user.Email,
                    Id = user.Id,
                    IsActive = user.IsActive
                };
                UsersList.Add(pendingUser);
            }
            return Ok(UsersList);
        }
        // /api/users/id
        [HttpPut]
        public IHttpActionResult ApproveUser(string id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);
            if(user == null)
            {
                return NotFound();
            }
            user.IsActive = true;
            user.LockoutEndDateUtc = null;
            _context.SaveChanges();
            return Ok();
        }
        
    }
}
