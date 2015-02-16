using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTeam.Data;

namespace MyTeam.Services.IService
{
    
    interface ITeamService
    {
        
        // CREATE ===================================================================
        // addTeam
        void addTeam(Team team);

        // READ =====================================================================
        // getTeams
        IList<Team> getTeams();

        // getTeam
        Team getTeam(int id);

        // UPDATE ===================================================================
        // editTeam
        void editTeam(Team team);

        // DELETE ===================================================================
        // deleteTeam
        void deleteTeam(Team team);

    }

}
