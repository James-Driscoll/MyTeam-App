using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTeam.Data.IDAO;

namespace MyTeam.Data.DAO
{
    public class TaskDAO : ITaskDAO
    {

        private MyTeamDataEntities _context;

        public TaskDAO()
        {
            _context = new MyTeamDataEntities();
        }

        // CREATE ====================================================================
        // addTask
        public void addTask(Task task)
        {
            task.Status = "Not Started";
            task.PercentageCompleted = 0;

            task.StartDate = DateTime.Today;
            DateTime now = DateTime.Now;
            DateTime due = task.EndDate ?? DateTime.Now;
            TimeSpan ts = due - now;
            task.Duration = Math.Abs(ts.Days);

            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        // READ ======================================================================
        // getTasks
        public IList<Task> getTasks(int id)
        {
            IQueryable<Task> _tasks;
            _tasks = from task
                     in _context.Tasks
                     where task.FK_Project == id
                     select task;
            return _tasks.ToList<Task>();
        }

        // getCompletedTasks
        public IList<Task> getCompletedTasks(string student, int project)
        {
            IQueryable<Task> _tasks;
            _tasks = from task
                     in _context.Tasks
                     where task.FK_AssignedTo == student && task.FK_Project == project && task.Status == "Finished"
                     select task;
            return _tasks.ToList<Task>();
        }

        // getTask
        public Task getTask(int id)
        {
            IQueryable<Task> _task;
            _task = from task
                    in _context.Tasks
                    where task.Id == id
                    select task;
            return _task.ToList<Task>().First();
        }

        // UPDATE ====================================================================
        // editTask
        public void editTask(Task task)
        {
            Task record = (from rec
                               in _context.Tasks
                               where rec.Id == task.Id
                               select rec).ToList<Task>().First();
            record.FK_AssignedTo = task.FK_AssignedTo;
            record.FK_Project = task.FK_Project;
            record.Title = task.Title;
            record.Description = task.Description;
            record.Status = task.Status;
            record.PercentageCompleted = task.PercentageCompleted;
            record.EstimatedDuration = task.EstimatedDuration;
            record.EndDate = task.EndDate;

            DateTime start = record.StartDate;
            DateTime due = task.EndDate ?? DateTime.Now;
            TimeSpan ts = due - start;
            record.Duration = Math.Abs(ts.Days);

            _context.SaveChanges();
        }

        // DELETE ====================================================================
        // deleteTask
        public void deleteTask(Task task)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }

    }
}
