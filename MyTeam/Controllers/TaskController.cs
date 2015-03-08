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
    
    public class TaskController : ApplicationController
    {
        
        // Declare model.
        private MyTeam.Models.ApplicationDbContext _context;

        // CONSTRUCTOR ==============================================================
        public TaskController()
        {
            _context = new MyTeam.Models.ApplicationDbContext();
        }

        // CREATE ===================================================================
        // Add : Saves new task to the database.
        [HttpGet]
        public ActionResult Add(int team, int project)
        {
            // declare local list of team members.
            IList<TeamMember> _teamMembers = _teamService.getTeamMembers(team);

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            List<SelectListItem> teamMemberList = new List<SelectListItem>();

            // loop through team member list and replace the UserID with the UserName.
            for (int i = 0; i < _teamMembers.Count; i++)
            {
                ApplicationUser user = userManager.FindById(_teamMembers[i].FK_Member);
                _teamMembers[i].FK_Member = user.UserName;
                
                teamMemberList.Add(new SelectListItem() { Text = user.UserName, Value = user.Id });
            }

            ViewBag.teamMemberList = teamMemberList;
            return View();
        }

        [HttpPost]
        public ActionResult Add(Task task, int project)
        {
            View();
            task.FK_Project = project;
            _taskService.addTask(task);
            return RedirectToAction("Index", "Team");
        }

        // addEvaluation
        [HttpGet]
        public ActionResult addEvaluation(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult addEvaluation(Evaluation evaluation)
        {
            View();
            _evaluationService.addEvaluation(evaluation);
            return RedirectToAction("Projects", "Project");
        }


        // READ =====================================================================
        // Tasks
        public ActionResult Index(int id)
        {
            // declare local list of tasks.
            IList<Task> _taskList = _taskService.getTasks(id);

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            // loop through task list and replace the UserID with the UserName.
            for (int i = 0; i < _taskList.Count; i++)
            {
                ApplicationUser user = userManager.FindById(_taskList[i].FK_AssignedTo);
                _taskList[i].FK_AssignedTo = user.UserName;
            }

            // return the modified list to the view.
            return View(_taskList);
        }

        // getTask
        public ActionResult getTask(int id)
        {
            return View(_taskService.getTask(id));
        }

        // getEvaluations
        public ActionResult getEvaluations(int task)
        {
            return View(_evaluationService.getEvaluations(task));
        }


        // UPDATE ===================================================================
        // editTask
        [HttpGet]
        public ActionResult editTask(int id)
        {
            Task record = _taskService.getTask(id);
            return View(record);
        }

        [HttpPost]
        public ActionResult editTask(Task task)
        {
            try
            {
                _taskService.editTask(task);
                return RedirectToAction("Projects", "Project");
            }
            catch
            {
                return View();
            }
        }


        // DELETE ===================================================================
        // deleteTask
        [HttpGet]
        public ActionResult deleteTask(int id)
        {
            Task task = _taskService.getTask(id);
            return View(task);
        }

        [HttpPost]
        public ActionResult deleteTask(Task task, int id)
        {
            try
            {
                Task _task = _taskService.getTask(id);
                _taskService.deleteTask(_task);
                return RedirectToAction("Projects", "Project");
            }
            catch
            {
                return View();
            }
        }

    }

}
