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
        // AddTeam : Allows Tutors to create new teams of existing registered students.
        [HttpGet]
        public ActionResult AddTeam()
        {
            var userList = _context.Users.OrderBy(u => u.UserName).ToList().Select(uu => new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();
            ViewBag.Users = userList;
            return View();
        }

        [HttpPost]
        public ActionResult AddTeam(Team team)
        {
            View();
            _teamService.addTeam(team);
            return View("Teams", "Tutor");
        }

        // READ =====================================================================
        // Dashboard : Returns control page for Tutors.
        public ActionResult Dashboard()
        {
            return View();
        }
        
        // Teams : Returns list of student teams.
        public ActionResult Teams()
        {
            return View(_teamService.getTeams());
        }

        // UPDATE ===================================================================


        // DELETE ===================================================================
    
    }

}
