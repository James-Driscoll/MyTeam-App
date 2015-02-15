using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeam.Data.IDAO
{
    interface ITeamDAO
    {

        // CREATE ====================================================================
        // addTeam
        void addTeam(Team team);

        // READ ======================================================================
        // getTeams
        IList<Team> getTeams();

        // getTeam
        Team getTeam(int id);

        // UPDATE ====================================================================
        // editTeam
        void editTeam(Team team);

        // DELETE ====================================================================
        // deleteTeam
        void deleteTeam(Team team);

    }

}
