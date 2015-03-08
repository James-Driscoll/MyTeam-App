using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyTeam.Data;
using MyTeam.Models;

namespace MyTeam.Controllers
{

    //[Authorize]
    //[Authorize(Roles = "Tutor")]
    public class TutorController : ApplicationController
    {

        // Declare model.
        private MyTeam.Models.ApplicationDbContext _context;

        // CONSTRUCTOR ==============================================================
        public TutorController()
        {
            _context = new MyTeam.Models.ApplicationDbContext();
        }

        // CREATE ===================================================================

        
        // READ =====================================================================
        // Index : Returns an IList of all teams.
        public ActionResult Index()
        {
            return View(_teamService.getTeams());
        }
        
        // UPDATE ===================================================================


        // DELETE ===================================================================
    
    }

}
