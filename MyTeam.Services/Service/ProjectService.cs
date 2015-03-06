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

        private ProjectDAO _projectDAO;
        public ProjectService()
        {
            _projectDAO = new ProjectDAO();
        }

        // CREATE ===================================================================
        // addProject
        public void addProject(Project project)
        {
            _projectDAO.addProject(project);
        }

        // READ =====================================================================
        // getProjectes
        public IList<Project> getProjects(int id)
        {
            return _projectDAO.getProjects(id);
        }

        // getProject
        public Project getProject(int id)
        {
            return _projectDAO.getProject(id);
        }

        // UPDATE ===================================================================
        // editProject
        public void editProject(Project project)
        {
            _projectDAO.editProject(project);
        }

        // DELETE ===================================================================
        // deleteProject
        public void deleteProject(Project project)
        {
            _projectDAO.deleteProject(project);
        }

    }

}
