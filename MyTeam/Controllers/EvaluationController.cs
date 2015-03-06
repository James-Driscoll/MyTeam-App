using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using MyTeam.Models;

namespace MyTeam.Controllers
{
   
    public class EvaluationController : ApplicationController
    {

        // CREATE ===================================================================


        // READ =====================================================================
        // Index
        public ActionResult Index(int id)
        {
            return View(_evaluationService.getEvaluations(id));
        }

        // UPDATE ===================================================================


        // DELETE ===================================================================


    }

}
