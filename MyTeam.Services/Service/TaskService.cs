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
    
    public class TaskService : ITaskService
    {
        
        private TaskDAO _taskDAO;

        // CONSTRUCTOR ==============================================================
        public TaskService()
        {
            _taskDAO = new TaskDAO();
        }

        // CREATE ===================================================================
        // addTask
        public void addTask(MyTeam.Data.Task task)
        {
            _taskDAO.addTask(task);
        }

        // READ =====================================================================
        // getTasks
        public IList<MyTeam.Data.Task> getTasks(int id)
        {
            return _taskDAO.getTasks(id);
        }

        // getTask
        public MyTeam.Data.Task getTask(int id)
        {
            return _taskDAO.getTask(id);
        }

        // UPDATE ===================================================================
        // editTask
        public void editTask(MyTeam.Data.Task task)
        {
            _taskDAO.editTask(task);
        }

        // DELETE ===================================================================
        // deleteTask
        public void deleteTask(MyTeam.Data.Task task)
        {
            _taskDAO.deleteTask(task);
        }

    }

}
