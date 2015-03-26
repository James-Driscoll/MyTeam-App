using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyTeam.Data;
using MyTeam.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace MyTeam.Controllers
{

    [Authorize(Roles = "Tutor, Admin")]
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

        // Projects
        public ActionResult Projects(int id)
        {
            return View(_projectService.getProjects(id));
        }
        
        // Tasks
        public ActionResult Tasks(int id)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            IList<Task> _tasks = _taskService.getTasks(id);

            for (int i = 0; i < _tasks.Count; i++)
            {
                ApplicationUser user = userManager.FindById(_tasks[i].FK_AssignedTo);
                _tasks[i].FK_AssignedTo = user.UserName;
            }

            return View(_tasks);
        }

        // Evaluations
        public ActionResult Evaluations(int id)
        {
            IList<Evaluation> _evaluations = _evaluationService.getEvaluations(id);
            int markTotal = 0;
            int lowestMark = 101;
            int highestMark = 0;
            
            if (_evaluations.Count > 0)
            {
                for (int i = 0; i < _evaluations.Count; i++)
                {
                    markTotal = markTotal + _evaluations[i].Mark;

                    if (_evaluations[i].Mark > highestMark)
                    {
                        highestMark = _evaluations[i].Mark;
                    }

                    if (_evaluations[i].Mark < lowestMark)
                    {
                        lowestMark = _evaluations[i].Mark;
                    }

                }

                float averageMark = markTotal / _evaluations.Count;

                ViewBag.averageMark = averageMark;
                ViewBag.highestMark = highestMark;
                ViewBag.lowestMark = lowestMark;
            };

            return View(_evaluationService.getEvaluations(id));
        }

        // StudentStats
        public ActionResult StudentStats(string student, string project)
        {
            int projectID = -1;
            try
            {
                projectID = Int32.Parse(project);
            }
            catch
            {
                
            }
            

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            MyTeam.Data.BEANS.EvaluationBEAN evaluationBEAN = new MyTeam.Data.BEANS.EvaluationBEAN();
            ApplicationUser user = userManager.FindById(student);

            IList<Evaluation> _evaluations = _evaluationService.getCompletedEvaluations(user.Id, projectID);
            int markTotal = 0;
            int lowestMark = 101;
            int highestMark = 0;

            if (_evaluations.Count > 0)
            {
                for (int i = 0; i < _evaluations.Count; i++)
                {
                    markTotal = markTotal + _evaluations[i].Mark;

                    if (_evaluations[i].Mark > highestMark)
                    {
                        highestMark = _evaluations[i].Mark;
                    }

                    if (_evaluations[i].Mark < lowestMark)
                    {
                        lowestMark = _evaluations[i].Mark;
                    }

                }

                float averageMark = markTotal / _evaluations.Count;
                
                //IList<Task> _tasks = _taskService.getTasks()


                evaluationBEAN.Student = user.UserName;
                evaluationBEAN.AverageMark = averageMark;
                evaluationBEAN.HighestMark = highestMark;
                evaluationBEAN.LowestMark = lowestMark;
                evaluationBEAN.TasksCompleted = _taskService.getCompletedTasks(user.Id, projectID).Count;
            };

            return View(evaluationBEAN);
        }

        public ActionResult ProjectStats(string student, int team)
        {
            ViewBag.TeamID = team;
            return View(_projectService.getProjects(team));
        }

        // UPDATE ===================================================================


        // DELETE ===================================================================
    

    }

}
