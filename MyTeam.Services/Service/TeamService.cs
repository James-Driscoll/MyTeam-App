﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTeam.Services.IService;
using MyTeam.Data;
using MyTeam.Data.DAO;

namespace MyTeam.Services.Service
{
    
    public class TeamService : ITeamService
    {
        
        private TeamDAO _teamDAO;
        public TeamService()
        {
            _teamDAO = new TeamDAO();
        }

        // CREATE ===================================================================
        // addTeam
        public void addTeam(Team team)
        {
            _teamDAO.addTeam(team);
        }

        // READ =====================================================================
        // getTeames
        public IList<Team> getTeames()
        {
            return _teamDAO.getTeams();
        }

        // getTeam
        public Team getTeam(int id)
        {
            return _teamDAO.getTeam(id);
        }

        // UPDATE ===================================================================
        // editTeam
        public void editTeam(Team team)
        {
            _teamDAO.editTeam(team);
        }

        // DELETE ===================================================================
        // deleteTeam
        public void deleteTeam(Team team)
        {
            _teamDAO.deleteTeam(team);
        }

    }

}