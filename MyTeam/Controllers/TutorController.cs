using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyTeam.Data;

namespace MyTeam.Controllers
{
    
    public class TutorController : ApplicationController
    {

        // CREATE ===================================================================
        // AddTeam : Allows Tutors to create new teams of existing registered students.
        [HttpGet]
        public ActionResult AddTeam()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTeam(Team team)
        {
            //var userList = _context.Users.OrderBy(u => u.UserName).ToList().Select(uu => new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();
            View();
            _teamService.addTeam(team);
            return View("Teams", "Tutor");
        }

        // READ =====================================================================
        // Teams : Returns list of student teams.
        public ActionResult Teams()
        {
            return View(_teamService.getTeams());
        }

        // UPDATE ===================================================================


        // DELETE ===================================================================
    
    }

}
