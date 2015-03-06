using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTeam.Data;

namespace MyTeam.Services.IService
{
    
    interface ITaskService
    {

        // CREATE ===================================================================
        // addTask
        void addTask(MyTeam.Data.Task task);

        // READ =====================================================================
        // getTaskes
        IList<MyTeam.Data.Task> getTasks(int project);

        // getTask
        MyTeam.Data.Task getTask(int id);

        // UPDATE ===================================================================
        // editTask
        void editTask(MyTeam.Data.Task task);

        // DELETE ===================================================================
        // deleteTask
        void deleteTask(MyTeam.Data.Task task);

    }

}
