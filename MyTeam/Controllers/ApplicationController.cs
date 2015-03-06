using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyTeam.Data;
using MyTeam.Services;

namespace MyTeam.Controllers
{
    
    public abstract class ApplicationController : Controller
    {

        // Declare custom services.
        public MyTeam.Services.Service.EvaluationService _evaluationService;
        public MyTeam.Services.Service.ProjectService _projectService;
        public MyTeam.Services.Service.TeamService _teamService;
        public MyTeam.Services.Service.TaskService _taskService;

        // Declare dictionaries.
        public Dictionary<int, string> _teamDictionary;

        // CONSTRUCTOR ==============================================================
        public ApplicationController()
        {
            _evaluationService = new MyTeam.Services.Service.EvaluationService();
            _projectService = new MyTeam.Services.Service.ProjectService();
            _teamService = new MyTeam.Services.Service.TeamService();
            _taskService = new MyTeam.Services.Service.TaskService();

            var statusList = new SelectList(new[] 
            {
                new { ID = "Not Started", Name = "Not Started" },
                new { ID = "Started", Name = "Started" },
                new { ID = "Getting There", Name = "Getting There" },
                new { ID = "Nealy Done", Name = "Nealy Done" },
                new { ID = "Finished", Name = "Finished" }
            },
            "ID", "Name", 1);
            ViewData["statusList"] = statusList;

        }

    }

}
