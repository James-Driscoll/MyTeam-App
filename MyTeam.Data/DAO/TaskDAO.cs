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
            record.StartDate = task.StartDate;
            record.EndDate = task.EndDate;
            record.Duration = task.Duration;
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
