using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyTeam.Data;

namespace MyTeam.Controllers
{
    
    public class TaskController : ApplicationController
    {
        
        // CREATE ===================================================================
        // addTask
        [HttpGet]
        public ActionResult addTask(string FK_Project)
        {
            return View();
        }

        [HttpPost]
        public ActionResult addTask(Task task)
        {
            View();
            _taskService.addTask(task);
            return RedirectToAction("Projects", "Project");
        }

        // addEvaluation
        [HttpGet]
        public ActionResult addEvaluation(int FK_Task)
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
        // getTasks
        public ActionResult getTasks(int project)
        {
            return View(_taskService.getTasks(project));
        }

        // Tasks
        public ActionResult Index(int id)
        {
            return View(_taskService.getTasks(id));
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
