using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTeam.Data.IDAO;

namespace MyTeam.Data.DAO
{
    public class TeamDAO : ITeamDAO
    {

        // Declare local data context.
        private MyTeamDataEntities _context;

        // CONSTRUCTOR ===============================================================
        public TeamDAO()
        {
            _context = new MyTeamDataEntities();
        }

        // CREATE ====================================================================
        // addTeam : Adds a new team record to the database.
        public void addTeam(Team team)
        {
            _context.Teams.Add(team);
            _context.SaveChanges();
        }

        // READ ======================================================================
        // getTeams : Rreturns a list of all registered teams.
        public IList<Team> getTeams()
        {
            IQueryable<Team> _teams;
            _teams = from team
                     in _context.Teams
                     select team;
            return _teams.ToList<Team>();
        }

        // getStudentTeams :  Returns list of teams that the signed in user is a member of.
        public IList<Team> getStudentTeams(string id)
        {
            IQueryable<Team> _teams;
            _teams = from teamMember in _context.TeamMembers
                           from team in _context.Teams
                           where teamMember.FK_Member == id
                           where team.Id == teamMember.FK_Team
                           select team;
            return _teams.ToList<Team>();
        }

        // getTeam : Returns a single team.
        public Team getTeam(int id)
        {
            IQueryable<Team> _team;
            _team = from team
                    in _context.Teams
                    where team.Id == id
                    select team;
            return _team.ToList<Team>().First();
        }

        // UPDATE ====================================================================
        // editTeam : Updates one team in the database.
        public void editTeam(Team team)
        {
            Team record = (from rec
                           in _context.Teams
                           where rec.Id == team.Id
                           select rec).ToList<Team>().First();
            record.Name = team.Name;
            _context.SaveChanges();
        }

        // DELETE ====================================================================
        // deleteTeam : Removed one team from the database.
        public void deleteTeam(Team team)
        {
            _context.Teams.Remove(team);
            _context.SaveChanges();
        }

    }

}
