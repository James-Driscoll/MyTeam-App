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

        private MyTeamDataEntities _context;

        public TeamDAO()
        {
            _context = new MyTeamDataEntities();
        }

        // CREATE ====================================================================
        // addTeam
        public void addTeam(Team team)
        {
            _context.Teams.Add(team);
            _context.SaveChanges();
        }

        // READ ======================================================================
        // getTeams
        public IList<Team> getTeams()
        {
            IQueryable<Team> _teams;
            _teams = from team
                     in _context.Teams
                     select team;
            return _teams.ToList<Team>();
        }

        // getTeam
        public Team getTeam(int id)
        {
            IQueryable<Team> _team;
            _team = from team
                    in _context.Teams
                    where team.PK_TeamID == id
                    select team;
            return _team.ToList<Team>().First();
        }

        // UPDATE ====================================================================
        // editTeam
        public void editTeam(Team team)
        {
            Team record = (from rec
                           in _context.Teams
                           where rec.PK_TeamID == team.PK_TeamID
                           select rec).ToList<Team>().First();
            record.Name = team.Name;
            record.FK_Member1 = team.FK_Member1;
            record.FK_Member2 = team.FK_Member2;
            record.FK_Member3 = team.FK_Member3;
            record.FK_Member4 = team.FK_Member4;
            record.FK_Member5 = team.FK_Member5;
            record.FK_Member6 = team.FK_Member6;
            record.FK_Member7 = team.FK_Member7;
            record.FK_Member8 = team.FK_Member8;
            record.FK_Member9 = team.FK_Member9;
            record.FK_Member10 = team.FK_Member10;
            _context.SaveChanges();
        }

        // DELETE ====================================================================
        // deleteTeam
        public void deleteTeam(Team team)
        {
            _context.Teams.Remove(team);
            _context.SaveChanges();
        }

    }

}
