using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTeam.Data;

namespace MyTeam.Services.IService
{
    
    interface IWorkTaskService
    {

        // CREATE ===================================================================
        // addWorkTask
        void addWorkTask(WorkTask worktask);

        // READ =====================================================================
        // getWorkTaskes
        IList<WorkTask> getWorkTasks();

        // getWorkTask
        WorkTask getWorkTask(int id);

        // UPDATE ===================================================================
        // editWorkTask
        void editWorkTask(WorkTask worktask);

        // DELETE ===================================================================
        // deleteWorkTask
        void deleteWorkTask(WorkTask worktask);

    }

}
