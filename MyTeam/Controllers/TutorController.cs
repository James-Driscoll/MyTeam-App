using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyTeam.Models;

namespace MyTeam.Controllers
{
    
    public class TutorController : ApplicationController
    {

        // CREATE ===================================================================


        // READ =====================================================================
        // Teams : Returns list of student teams.
        public ActionResult Teams()
        {
            return View(_teamService.getTeams());
        }

        // UPDATE ===================================================================


        // DELETE ===================================================================
    
    }

}
