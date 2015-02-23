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
        // addTeam : Adds a new team record to the database.
        void addTeam(Team team);

        // READ ======================================================================
        // getTeams : Rreturns a list of all registered teams.
        IList<Team> getTeams();

        // getStudentTeams : Returns list of teams that the signed in user is a member of.
        IList<Team> getStudentTeams(int studentId);

        // getTeam : Returns a single team.
        Team getTeam(int id);

        // UPDATE ====================================================================
        // editTeam : Updates one team in the database.
        void editTeam(Team team);

        // DELETE ====================================================================
        // deleteTeam : Removed one team from the database.
        void deleteTeam(Team team);

    }

}
