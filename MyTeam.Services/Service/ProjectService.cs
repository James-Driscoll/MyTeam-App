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
    
    public class ProjectService : IProjectService
    {

        private ProjectDAO _ProjectDAO;
        public ProjectService()
        {
            _ProjectDAO = new ProjectDAO();
        }

        // CREATE ===================================================================
        // addProject
        public void addProject(Project project)
        {
            _ProjectDAO.addProject(project);
        }

        // READ =====================================================================
        // getProjectes
        public IList<Project> getProjects()
        {
            return _ProjectDAO.getProjects();
        }

        // getProject
        public Project getProject(int id)
        {
            return _ProjectDAO.getProject(id);
        }

        // UPDATE ===================================================================
        // editProject
        public void editProject(Project project)
        {
            _ProjectDAO.editProject(project);
        }

        // DELETE ===================================================================
        // deleteProject
        public void deleteProject(Project project)
        {
            _ProjectDAO.deleteProject(project);
        }

    }

}
