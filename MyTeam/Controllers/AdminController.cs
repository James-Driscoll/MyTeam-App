using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyTeam.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MyTeam.Controllers
{
    //[Authorize]
    //[Authorize(Roles= "Admin")]
    public class AdminController : Controller
    {

        // Declare model.
        private MyTeam.Models.ApplicationDbContext _context;

        // CONSTRUCTOR ==============================================================
        public AdminController()
        {
            _context = new MyTeam.Models.ApplicationDbContext();
        }

        // CREATE ===================================================================


        // READ =====================================================================
        // Index : Returns view that contains a list of Admin specific operations.
        public ActionResult Index() {
            return View();
        }

        // Users : Returns list of all system registered users of any role.
        public ActionResult Users()
        {
            return View(_context.Users.ToList());
        }

        // RolesForUser : Returns list of roles associated with a particular user.
        [HttpGet]
        public ActionResult RolesForUser()
        {
            // populates user list for the view drop down menu.
            List<SelectListItem> userList = new List<SelectListItem>();
            foreach (var item in _context.Users.ToList())
            {
                userList.Add(
                    new SelectListItem()
                    {
                        Text = item.FirstName + " " + item.LastName + " | " + item.UserName,
                        Value = item.UserName
                    });
            }
            ViewBag.userList = userList;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RolesForUser(string userName)
        {
            if (!string.IsNullOrWhiteSpace(userName))
            {
                ApplicationUser user = _context.Users.Where(u => u.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
                ViewBag.RolesForThisUser = userManager.GetRoles(user.Id);
            }
            return View("RolesForUserConfirmed");
        }
        
        // UPDATE ===================================================================   
        // ManageUserRoles : Allows Admin to manage the roles associate with a particular user.
        [HttpGet]
        public ActionResult ManageUserRoles()
        {
            // populates roles for the view dropdown
            var roleList = _context.Roles.OrderBy(r => r.Name).ToList().Select(rr =>
                new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = roleList;

            // populates users for the view dropdown
            var userList = _context.Users.OrderBy(u => u.UserName).ToList().Select(uu =>
                new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();
            ViewBag.Users = userList;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ManageUserRoles(string UserName, string RoleName)
        {
            ApplicationUser user = _context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
            userManager.AddToRole(user.Id, RoleName);

            // prepopulat roles for the view dropdown
            //var roleList = _context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            //ViewBag.Roles = roleList;

            // populate users for the view dropdown
            //var userList = _context.Users.OrderBy(u => u.UserName).ToList().Select(uu => new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();
            //ViewBag.Users = userList;

            //return View();

            return RedirectToAction("Index");
        }

        // DELETE ===================================================================

        
    }

}
