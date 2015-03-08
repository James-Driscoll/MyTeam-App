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
        private MyTeam.Models.ApplicationDbContext _userService;

        // CONSTRUCTOR ==============================================================
        public ApplicationController()
        {
            
            // Construct services.
            _evaluationService = new MyTeam.Services.Service.EvaluationService();
            _projectService = new MyTeam.Services.Service.ProjectService();
            _teamService = new MyTeam.Services.Service.TeamService();
            _taskService = new MyTeam.Services.Service.TaskService();
            _userService = new MyTeam.Models.ApplicationDbContext();

            // Construct lists of statuses.
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

            // Construct list of User names.
            List<SelectListItem> userList = new List<SelectListItem>();
            foreach (var item in _userService.Users.ToList())
            {
                userList.Add(
                    new SelectListItem()
                    {
                        Text = item.FirstName + " " + item.LastName + " | " + item.UserName,
                        Value = item.Id.ToString()
                    });
            }
            ViewBag.userList = userList;

        }

    }

}
