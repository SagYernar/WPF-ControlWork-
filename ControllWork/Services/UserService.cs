using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using Model;

namespace Services
{
    public class UserService
    {
        UserDataBase dataBase;
        User activeUser;
        public UserService()
        {
            dataBase = new UserDataBase();
            activeUser = new User();
        }
        public void AddUser(User user)
        {
            dataBase.SaveUser(user);
        }

        public bool CheckLogin(long login)
        {
            if (dataBase.CheckLogin(login))
            {
                return true;
            }
            return false;
        }

        public bool CheckEmail(string email)
        {
            if (dataBase.CheckEmail(email))
            {
                return true;
            }
            return false;
        }

        public bool CheckAutorization(long login, string password)
        {
            if (dataBase.CheckAutorization(login, password))
            {
                return true;
            }
            return false;
        }
        public void GetUser(long login)
        {
           activeUser = dataBase.GetUser(login);
        }
        public User GetActiveUser()
        {
            return activeUser;
        }
    }
}
