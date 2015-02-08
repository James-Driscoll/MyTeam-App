using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyTeam.Models;

namespace MyTeam.Controllers
{
    public class WorkTasksController : Controller
    {
        private MyTeamDataEntities2 db = new MyTeamDataEntities2();

        // GET: WorkTasks
        public ActionResult Index()
        {
            var workTasks = db.WorkTasks.Include(w => w.Project).Include(w => w.User);
            return View(workTasks.ToList());
        }

        // GET: WorkTasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkTask workTask = db.WorkTasks.Find(id);
            if (workTask == null)
            {
                return HttpNotFound();
            }
            return View(workTask);
        }

        // GET: WorkTasks/Create
        public ActionResult Create()
        {
            ViewBag.FK_Project = new SelectList(db.Projects, "Id", "Title");
            ViewBag.FK_AssignedTo = new SelectList(db.Users, "Id", "FirstName");
            return View();
        }

        // POST: WorkTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FK_AssignedTo,FK_Project,Title,Description,Status,PercentageCompleted,EstimatedDuration,StartDate,EndDate,Duration")] WorkTask workTask)
        {
            if (ModelState.IsValid)
            {
                db.WorkTasks.Add(workTask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_Project = new SelectList(db.Projects, "Id", "Title", workTask.FK_Project);
            ViewBag.FK_AssignedTo = new SelectList(db.Users, "Id", "FirstName", workTask.FK_AssignedTo);
            return View(workTask);
        }

        // GET: WorkTasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkTask workTask = db.WorkTasks.Find(id);
            if (workTask == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_Project = new SelectList(db.Projects, "Id", "Title", workTask.FK_Project);
            ViewBag.FK_AssignedTo = new SelectList(db.Users, "Id", "FirstName", workTask.FK_AssignedTo);
            return View(workTask);
        }

        // POST: WorkTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FK_AssignedTo,FK_Project,Title,Description,Status,PercentageCompleted,EstimatedDuration,StartDate,EndDate,Duration")] WorkTask workTask)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workTask).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_Project = new SelectList(db.Projects, "Id", "Title", workTask.FK_Project);
            ViewBag.FK_AssignedTo = new SelectList(db.Users, "Id", "FirstName", workTask.FK_AssignedTo);
            return View(workTask);
        }

        // GET: WorkTasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkTask workTask = db.WorkTasks.Find(id);
            if (workTask == null)
            {
                return HttpNotFound();
            }
            return View(workTask);
        }

        // POST: WorkTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkTask workTask = db.WorkTasks.Find(id);
            db.WorkTasks.Remove(workTask);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
