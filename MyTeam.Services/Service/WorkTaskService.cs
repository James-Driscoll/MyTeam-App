using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTeam.Services.IService;
using MyTeam.Data;
using MyTeam.Data.DAO;

namespace MyTeam.Services.Service
{
    
    public class WorkTaskService : IWorkTaskService
    {
        
        private WorkTaskDAO _worktaskDAO;
        public WorkTaskService()
        {
            _worktaskDAO = new WorkTaskDAO();
        }

        // CREATE ===================================================================
        // addWorkTask
        public void addWorkTask(WorkTask worktask)
        {
            _worktaskDAO.addWorkTask(worktask);
        }

        // READ =====================================================================
        // getWorkTaskes
        public IList<WorkTask> getWorkTasks()
        {
            return _worktaskDAO.getWorkTasks();
        }

        // getWorkTask
        public WorkTask getWorkTask(int id)
        {
            return _worktaskDAO.getWorkTask(id);
        }

        // UPDATE ===================================================================
        // editWorkTask
        public void editWorkTask(WorkTask worktask)
        {
            _worktaskDAO.editWorkTask(worktask);
        }

        // DELETE ===================================================================
        // deleteWorkTask
        public void deleteWorkTask(WorkTask worktask)
        {
            _worktaskDAO.deleteWorkTask(worktask);
        }

    }

}
