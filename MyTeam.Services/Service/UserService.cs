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
    
    public class UserService : IUserService
    {

        private UserDAO _userDAO;
        public UserService()
        {
            _userDAO = new UserDAO();
        }

        // CREATE ===================================================================
        // addUser
        public void addUser(User user)
        {
            _userDAO.addUser(user);
        }

        // READ =====================================================================
        // getUseres
        public IList<User> getUsers()
        {
            return _userDAO.getUsers();
        }

        // getUser
        public User getUser(int id)
        {
            return _userDAO.getUser(id);
        }

        // UPDATE ===================================================================
        // editUser
        public void editUser(User user)
        {
            _userDAO.editUser(user);
        }

        // DELETE ===================================================================
        // deleteUser
        public void deleteUser(User user)
        {
            _userDAO.deleteUser(user);
        }

    }

}
