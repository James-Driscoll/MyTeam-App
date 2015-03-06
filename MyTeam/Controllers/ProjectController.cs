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
        
        //// Declare local context and user manager services.
        //protected ApplicationDbContext ApplicationDbContext { get; set; }
        //protected UserManager<ApplicationUser> UserManager { get; set; }

        //// CONSTRUCTOR ==============================================================
        //public ProjectController()
        //{
        //    this.ApplicationDbContext = new ApplicationDbContext();
        //    this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
        //}

        // CREATE ===================================================================
        // addProject
        [HttpGet]
        public ActionResult addProject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addProject(Project project)
        {
            View();
            _projectService.addProject(project);
            return RedirectToAction("Projects", "Project");
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
        // editProject
        [HttpGet]
        public ActionResult editProject(int id)
        {
            Project record = _projectService.getProject(id);
            return View(record);
        }

        [HttpPost]
        public ActionResult editProject(Project project)
        {
            try
            {
                _projectService.editProject(project);
                return RedirectToAction("Projects", "Project");
            }
            catch
            {
                return View();
            }
        }


        // DELETE ===================================================================
        // deleteProject
        [HttpGet]
        public ActionResult deleteProject(int id)
        {
            Project project = _projectService.getProject(id);
            return View(project);
        }

        [HttpPost]
        public ActionResult deleteProject(Project project, int id)
        {
            try
            {
                Project _project = _projectService.getProject(id);
                _projectService.deleteProject(_project);
                return RedirectToAction("Projects", "Project");
            }
            catch
            {
                return View();
            }
        }

    }

}
