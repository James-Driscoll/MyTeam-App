using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeam.Data.IDAO
{
    
    interface IProjectDAO
    {

        // CREATE ====================================================================
        // addProject
        void addProject(Project project);

        // READ ======================================================================
        // getProjects
        IList<Project> getProjects();

        // getProject
        Project getProject(int id);

        // UPDATE ====================================================================
        // editProject
        void editProject(Project project);

        // DELETE ====================================================================
        // deleteProject
        void deleteProject(Project project);

    }

}
