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

    }

}
