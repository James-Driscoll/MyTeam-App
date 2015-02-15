using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeam.Data.IDAO
{
    
    interface IWorkTaskDAO
    {

        // CREATE ====================================================================
        // addWorkTask
        void addWorkTask(WorkTask worktask);

        // READ ======================================================================
        // getWorkTasks
        IList<WorkTask> getWorkTasks();

        // getWorkTask
        WorkTask getWorkTask(int id);

        // UPDATE ====================================================================
        // editWorkTask
        void editWorkTask(WorkTask worktask);

        // DELETE ====================================================================
        // deleteWorkTask
        void deleteWorkTask(WorkTask worktask);

    }

}

