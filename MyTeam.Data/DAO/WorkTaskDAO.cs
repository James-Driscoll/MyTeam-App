using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTeam.Data.IDAO;

namespace MyTeam.Data.DAO
{
    public class WorkTaskDAO : IWorkTaskDAO
    {

        private MyTeamDataEntities _context;

        public WorkTaskDAO()
        {
            _context = new MyTeamDataEntities();
        }

        // CREATE ====================================================================
        // addWorkTask
        public void addWorkTask(WorkTask worktask)
        {
            _context.WorkTasks.Add(worktask);
            _context.SaveChanges();
        }

        // READ ======================================================================
        // getWorkTasks
        public IList<WorkTask> getWorkTasks(int project)
        {
            IQueryable<WorkTask> _worktasks;
            _worktasks = from worktask
                         in _context.WorkTasks
                         where worktask.FK_Project == project
                         select worktask;
            return _worktasks.ToList<WorkTask>();
        }

        // getWorkTask
        public WorkTask getWorkTask(int id)
        {
            IQueryable<WorkTask> _worktask;
            _worktask = from worktask
                        in _context.WorkTasks
                        where worktask.PK_WorkTaskID == id
                        select worktask;
            return _worktask.ToList<WorkTask>().First();
        }

        // UPDATE ====================================================================
        // editWorkTask
        public void editWorkTask(WorkTask worktask)
        {
            WorkTask record = (from rec
                               in _context.WorkTasks
                               where rec.PK_WorkTaskID == worktask.PK_WorkTaskID
                               select rec).ToList<WorkTask>().First();
            record.FK_AssignedTo = worktask.FK_AssignedTo;
            record.FK_Project = worktask.FK_Project;
            record.Title = worktask.Title;
            record.Description = worktask.Description;
            record.Status = worktask.Status;
            record.PercentageCompleted = worktask.PercentageCompleted;
            record.EstimatedDuration = worktask.EstimatedDuration;
            record.StartDate = worktask.StartDate;
            record.EndDate = worktask.EndDate;
            record.Duration = worktask.Duration;
            _context.SaveChanges();
        }

        // DELETE ====================================================================
        // deleteWorkTask
        public void deleteWorkTask(WorkTask worktask)
        {
            _context.WorkTasks.Remove(worktask);
            _context.SaveChanges();
        }

    }
}
