using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyTeam.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyTeam.Models;

namespace MyTeam.Controllers
{
    
    //[Authorize]
    //[Authorize(Roles= "Student")]
    public class ProjectController : ApplicationController
    {

        // Declare model.
        private MyTeam.Models.ApplicationDbContext _context;
        protected UserManager<ApplicationUser> UserManager { get; set; }

        // CONSTRUCTOR ==============================================================
        public ProjectController()
        {
            _context = new MyTeam.Models.ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this._context));
        }

        // CREATE ===================================================================
        // Create
        [HttpGet]
        public ActionResult Create()
        {
            // get the current user.
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            ApplicationUser user = userManager.FindByIdAsync(User.Identity.GetUserId()).Result;
            var currentUser = userManager.FindById(User.Identity.GetUserId());

            // construct list of team names.
            List<SelectListItem> teamList = new List<SelectListItem>();
            foreach (var item in _teamService.getStudentTeams(currentUser.Id))
            {
                teamList.Add(
                    new SelectListItem()
                    {
                        Text = item.Name,
                        Value = item.Id.ToString()
                    });
            }
            ViewBag.teamList = teamList;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Project project)
        {
            View();
            _projectService.addProject(project);
            return RedirectToAction("Index", "Team");
        }
        
        // READ =====================================================================
        // Index
        public ActionResult Index(int id)
        {
            return View(_projectService.getProjects(id));
        }
        
        // getProject
        public ActionResult getProject(int id)
        {
            return View(_projectService.getProject(id));
        }

        // UPDATE ===================================================================
        // Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            // get the current user.
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            ApplicationUser user = userManager.FindByIdAsync(User.Identity.GetUserId()).Result;
            var currentUser = userManager.FindById(User.Identity.GetUserId());

            // construct list of team names.
            List<SelectListItem> teamList = new List<SelectListItem>();
            foreach (var item in _teamService.getStudentTeams(currentUser.Id))
            {
                teamList.Add(
                    new SelectListItem()
                    {
                        Text = item.Name,
                        Value = item.Id.ToString()
                    });
            }
            ViewBag.teamList = teamList;
            
            Project record = _projectService.getProject(id);
            return View(record);
        }

        [HttpPost]
        public ActionResult Edit(Project project)
        {
            try
            {
                _projectService.editProject(project);
                return RedirectToAction("Index", "Team");
            }
            catch
            {
                return View();
            }
        }


        // DELETE ===================================================================
        // Delete
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Project project = _projectService.getProject(id);
            return View(project);
        }

        [HttpPost]
        public ActionResult Delete(Project project, int id)
        {
            try
            {
                Project _project = _projectService.getProject(id);
                _projectService.deleteProject(_project);
                return RedirectToAction("Index", "Team");
            }
            catch
            {
                return View();
            }
        }

    }

}
