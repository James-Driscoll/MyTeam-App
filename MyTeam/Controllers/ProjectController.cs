using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyTeam.Data;

namespace MyTeam.Controllers
{
    
    public class ProjectController : ApplicationController
    {

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
            return RedirectToAction("getProjects", "Project");
        }

        // READ =====================================================================
        // getProjects
        public ActionResult getProjects()
        {
            return View(_projectService.getProjects());
        }

        // getProject
        public ActionResult getProject(int id)
        {
            return View(_projectService.getProject(id));
        }

        // Projects
        public ActionResult Projects()
        {
            return View(_projectService.getProjects());
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
                return RedirectToAction("getProjects", "Project");
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
                return RedirectToAction("getProjects", "Project");
            }
            catch
            {
                return View();
            }
        }

    }

}
