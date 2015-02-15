using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeam.Data.IDAO
{

    interface IUserDAO
    {

        // CREATE ====================================================================
        // addUser
        void addUser(User user);

        // READ ======================================================================
        // getUsers
        IList<User> getUsers();

        // getUser
        User getUser(int id);

        // UPDATE ====================================================================
        // editUser
        void editUser(User user);

        // DELETE ====================================================================
        // deleteUser
        void deleteUser(User user);

    }

}
