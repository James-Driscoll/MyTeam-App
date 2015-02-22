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
    
    public class AdminController : Controller
    {

        // Declare services.
        private MyTeam.Models.ApplicationDbContext _context;

        // CONSTRUCTOR ==============================================================
        public AdminController()
        {
            _context = new MyTeam.Models.ApplicationDbContext();
        }

        // CREATE ===================================================================
        // AddRole
        [HttpGet]
        public ActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddRole(FormCollection collection)
        {
            try
            {
                _context.Roles.Add(new IdentityRole() { Name = collection["RoleName"] });
                _context.SaveChanges();
                return RedirectToAction("ControlPanel");
            }
            catch
            {
                return View("ControlPanel");
            }
        }

        // READ =====================================================================
        // ControlPanel : Returns view that contains a list of Admin specific operations.
        public ActionResult ControlPanel() {
            return View();
        }

        // Users : Returns list of all system registered users of any role.
        public ActionResult Users()
        {
            return View(_context.Users.ToList());
        }

        // Roles : Returns list of all system registered roles.
        public ActionResult Roles()
        {
            return View(_context.Roles.ToList());
        }

        // EditRole : Allows modification of the saved role name.
        [HttpGet]
        public ActionResult EditRole(string role)
        {
            var thisRole = _context.Roles.Where(r => r.Name.Equals(role, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            return View(thisRole);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRole(Microsoft.AspNet.Identity.EntityFramework.IdentityRole role)
        {
            try
            {
                _context.Entry(role).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Roles", "Admin");
            }
            catch
            {
                return View();
            }
            
        }

        // UPDATE ===================================================================
        [HttpGet]
        public ActionResult ManageUserRoles()
        {
            // populate roles for the view dropdown
            var roleList = _context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = roleList;

            // populate users for the view dropdown
            var userList = _context.Users.OrderBy(u => u.UserName).ToList().Select(uu => new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();
            ViewBag.Users = userList;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ManageUserRoles(string UserName, string RoleName)
        {
            ApplicationUser user = _context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
            var idResult = um.AddToRole(user.Id, RoleName);

            // repopulate roles for the view dropdown
            var roleList = _context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = roleList;

            // populate users for the view dropdown
            var userList = _context.Users.OrderBy(u => u.UserName).ToList().Select(uu => new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();
            ViewBag.Users = userList;

            return View("ManageUserRoles");
        }

        // DELETE ===================================================================
        

    }

}
