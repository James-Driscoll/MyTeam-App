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

        // CREATE ===================================================================


        // READ =====================================================================
        // Index : Returns list of teams that a particular student it a member of.
        public ActionResult Index(string id)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            ApplicationUser user = userManager.FindByIdAsync(User.Identity.GetUserId()).Result;
            var currentUser = userManager.FindById(User.Identity.GetUserId());
            return View(_teamService.getStudentTeams(currentUser.Id));
        }

        // UPDATE ===================================================================


        // DELETE ===================================================================

    }

}
