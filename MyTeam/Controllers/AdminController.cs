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
        // ControlPanel
        public ActionResult ControlPanel() {
            return View();
        }

        // Users
        public ActionResult Users()
        {
            return View(_context.Users.ToList());
        }

        // Roles
        public ActionResult Roles()
        {
            return View(_context.Roles.ToList());
        }

        // UPDATE ===================================================================
        

        // DELETE ===================================================================
        

    }

}
