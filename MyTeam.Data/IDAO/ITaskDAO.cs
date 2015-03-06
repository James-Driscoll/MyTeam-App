﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeam.Data.IDAO
{
    
    interface ITaskDAO
    {

        // CREATE ====================================================================
        // addTask
        void addTask(Task task);

        // READ ======================================================================
        // getTasks
        IList<Task> getTasks(int id);

        // getTask
        Task getTask(int id);

        // UPDATE ====================================================================
        // editTask
        void editTask(Task task);

        // DELETE ====================================================================
        // deleteTask
        void deleteTask(Task task);

    }

}

