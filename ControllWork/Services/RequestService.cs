using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using Model;

namespace Services
{
    public class RequestService
    {
        RequestDataBase dataBase;

        public RequestService()
        {
            dataBase = new RequestDataBase();
        }
        public void AddRequest(Request request)
        {
            dataBase.SaveRequest(request);
        }

        //public bool CheckLogin(string login)
        //{
        //    if (dataBase.CheckLogin(login))
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //public bool CheckEmail(string email)
        //{
        //    if (dataBase.CheckEmail(email))
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //public bool CheckAutorization(string login, string password)
        //{
        //    if (dataBase.CheckAutorization(login, password))
        //    {
        //        return true;
        //    }
        //    return false;
        //}
    }
}
