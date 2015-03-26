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
        [HttpGet] [Authorize(Roles = "Tutor, Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost] [Authorize(Roles = "Tutor, Admin")]
        public ActionResult Create(Team team)
        {
            View();
            _teamService.addTeam(team);
            return RedirectToAction("Index", "Tutor");
        }

        // AddMember : Adds a new student to a team.
        [HttpGet] [Authorize(Roles = "Tutor, Admin")]
        public ActionResult AddMember(int id)
        {
            return View();
        }

        [HttpPost] [Authorize(Roles = "Tutor, Admin")]
        public ActionResult AddMember(TeamMember teamMember, int id)
        {
            View();
            teamMember.FK_Team = id;
            _teamService.addTeamMember(teamMember);
            return RedirectToAction("Index", "Tutor");
        }

        // READ =====================================================================
        // Index : Returns list of teams that a particular student it a member of.
       [Authorize(Roles = "Student")] 
       public ActionResult Index(string id)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            ApplicationUser user = userManager.FindByIdAsync(User.Identity.GetUserId()).Result;
            var currentUser = userManager.FindById(User.Identity.GetUserId());
            return View(_teamService.getStudentTeams(currentUser.Id));
        }

        // Members : Returns an IList of all members that are part of a particular team.
       [Authorize(Roles = "Tutor, Admin")]
       public ActionResult Members(int id)
       {
           // declare local list of team members.
           IList<TeamMember> _teamMembers = _teamService.getTeamMembers(id);
           // MyTeam.Data.BEANS.TeamMemberBEAN _teamMemberBEAN = new MyTeam.Data.BEANS.TeamMemberBEAN();
           IList<MyTeam.Data.BEANS.TeamMemberBEAN> _teamMemberBEANs = new List<MyTeam.Data.BEANS.TeamMemberBEAN>();
           var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

           // loop through team member list and replace the UserID with the UserName.
           for (int i = 0; i < _teamMembers.Count; i++)
           {
               ApplicationUser user = userManager.FindById(_teamMembers[i].FK_Member);
               MyTeam.Data.BEANS.TeamMemberBEAN _teamMemberBEAN = new MyTeam.Data.BEANS.TeamMemberBEAN();
               _teamMembers[i].FK_Member = user.UserName;
               _teamMemberBEAN.Id = _teamMembers[i].Id;
               _teamMemberBEAN.userID = user.Id;
               _teamMemberBEAN.userName = user.UserName;
               _teamMemberBEANs.Add(_teamMemberBEAN);
           }

           for (int i = 0; i < _projectService.getProjects(id).Count; i++)
           {
               _teamMemberBEANs[i].projectList = _projectService.getProjects(id);

               var tet = _projectService.getProjects(id);

               //_teamMemberBEANs[i].projectList.Union(IEnumerable<Project>, _projectService.getProjects(id));
               //_teamMemberBEANs[i].projectList = _projectService.getProjects(id).ToList();
               //var projectList = _projectService.getProjects(id).Select(pl =>
               //    new SelectListItem { Value = pl.Id.ToString(), Text = pl.Title }).ToList();
               //_teamMemberBEANs[i].projectList = projectList;
           }


           var list = _projectService.getProjects(id).Select(x =>new SelectListItem{
                Text = x.Title,
                Value = x.Id.ToString()
           });

           ViewBag.ProjectList = list;

           // return the modified list to the view.
           return View(_teamMemberBEANs);
       }

        // UPDATE ===================================================================
        // Edit : Allows for updateding one Team.
        [HttpGet] [Authorize(Roles = "Tutor, Admin")]
        public ActionResult Edit(int id)
        {
            Team record = _teamService.getTeam(id);
            return View(record);
        }

        [HttpPost] [Authorize(Roles = "Tutor, Admin")]
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
        [HttpGet] [Authorize(Roles = "Tutor, Admin")]
        public ActionResult Delete(int id)
        {
            Team record = _teamService.getTeam(id);
            return View(record);
        }

        [HttpPost] [Authorize(Roles = "Tutor, Admin")]
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
