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

        // addTeamMember : Adds a new TeamMember record.
        void addTeamMember(TeamMember teamMember);

        // READ =====================================================================
        // getTeams
        IList<Team> getTeams();

        // getStudentTeams : Returns list of teams that the signed in user is a member of.
        IList<Team> getStudentTeams(string id);

        // getTeamMembers : Returns an IList of all members that are part of a particular team.
        IList<TeamMember> getTeamMembers(int id);

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
