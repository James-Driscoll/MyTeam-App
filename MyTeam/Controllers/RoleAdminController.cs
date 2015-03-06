using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyTeam.Data;
using MyTeam.Services;
using MyTeam.Services.Service;
using MyTeam.Models;

namespace MyTeam.Controllers
{

    public class RoleAdminController : Controller
    {

        private MyTeam.Models.ApplicationDbContext _context;

        // CONSTRUCTOR ========================================================
        public RoleAdminController()
        {
            _context = new MyTeam.Models.ApplicationDbContext();

        }

        // CREATE =============================================================
        // CreateRole : Adds a new system role to the database.
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                _context.Roles.Add(new IdentityRole() { Name = collection["RoleName"] });
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // READ ===============================================================
        // Roles : Returns list of system roles.
        public ActionResult Index()
        {
            return View(_context.Roles.ToList());
        }

        // UPDATE =============================================================
        // EditRole : Edits the name of an existing system role.
        [HttpGet]
        public ActionResult Edit(string id)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));
            var role = roleManager.FindById(id);
            return View(role);
        }

        [HttpPost]
        public ActionResult Edit(IdentityRole role)
        {
            try
            {
                _context.Entry(role).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // DELETE =============================================================
        // DeleteRole : Deletes a system role from the database.
        [HttpGet]
        public ActionResult Delete(string id)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));
            var role = roleManager.FindById(id);
            return View(role);
        }
        [HttpPost]
        public ActionResult Delete(IdentityRole role, string id)
        {
            try
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));
                var _role = roleManager.FindById(id);
                roleManager.Delete(_role);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }

}