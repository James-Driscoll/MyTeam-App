using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        // UPDATE ===================================================================
        

        // DELETE ===================================================================
        

    }

}
