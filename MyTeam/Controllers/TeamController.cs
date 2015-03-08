using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyTeam.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using MyTeam.Models;

namespace MyTeam.Controllers
{
   
    public class TeamController : ApplicationController
    {

        // Declare model.
        private MyTeam.Models.ApplicationDbContext _context;

        // CONSTRUCTOR ==============================================================
        public TeamController()
        {
            _context = new MyTeam.Models.ApplicationDbContext();
        }

        // CREATE ===================================================================
        // Create : Adds new Team.
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Team team)
        {
            View();
            _teamService.addTeam(team);
            return RedirectToAction("Index", "Tutor");
        }

        // AddMember : Adds a new student to a team.
        [HttpGet]
        public ActionResult AddMember(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMember(TeamMember teamMember, int id)
        {
            View();
            teamMember.FK_Team = id;
            _teamService.addTeamMember(teamMember);
            return RedirectToAction("Index", "Tutor");
        }

        // READ =====================================================================
        // Index : Returns list of teams that a particular student it a member of.
        public ActionResult Index(string id)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            ApplicationUser user = userManager.FindByIdAsync(User.Identity.GetUserId()).Result;
            var currentUser = userManager.FindById(User.Identity.GetUserId());
            return View(_teamService.getStudentTeams(currentUser.Id));
        }

        // Members : Returns an IList of all members that are part of a particular team.
        public ActionResult Members(int id)
        {
            // declare local list of team members.
            IList<TeamMember> _teamMembers = _teamService.getTeamMembers(id);

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            
            // loop through team member list and replace the UserID with the UserName.
            for (int i = 0; i < _teamMembers.Count; i++)
            {
                ApplicationUser user = userManager.FindById(_teamMembers[i].FK_Member);
                _teamMembers[i].FK_Member = user.UserName;
            }
            
            // return the modified list to the view.
            return View(_teamMembers);
        }

        // UPDATE ===================================================================
        // Edit : Allows for updateding one Team.
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Team record = _teamService.getTeam(id);
            return View(record);
        }

        [HttpPost]
        public ActionResult Edit(Team team)
        {
            try
            {
                _teamService.editTeam(team);
                return RedirectToAction("Index", "Tutor");
            }
            catch
            {
                return View();
            }
        }

        // DELETE ===================================================================
        // Delete : Removes a single Team.
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Team record = _teamService.getTeam(id);
            return View(record);
        }

        [HttpPost]
        public ActionResult Delete(Team team, int id)
        {
            try
            {
                Team _team = _teamService.getTeam(id);
                _teamService.deleteTeam(_team);
                return RedirectToAction("Index", "Tutor");
            }
            catch
            {
                return View();
            }
        }

    }

}
