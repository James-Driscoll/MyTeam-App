using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTeam.Data;

namespace MyTeam.Services.IService
{
    
    interface IProjectService
    {

        // CREATE ===================================================================
        // addProject
        void addProject(Project project);

        // READ =====================================================================
        // getProjectes
        IList<Project> getProjects(int id);

        // getProject
        Project getProject(int id);

        // UPDATE ===================================================================
        // editProject
        void editProject(Project project);

        // DELETE ===================================================================
        // deleteProject
        void deleteProject(Project project);

    }

}
