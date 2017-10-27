using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Newtonsoft.Json;
using System.IO;

namespace DataBase
{
    public class RequestDataBase
    {
        private List<Request> requests;

        public RequestDataBase()
        {
            requests = new List<Request>();
            FileStream fs = new FileStream(@"requests.txt", FileMode.OpenOrCreate);
            using (StreamReader sw = new StreamReader(fs, Encoding.Default))
            {
                JsonSerializer serializer = new JsonSerializer();
                requests = (List<Request>)serializer.Deserialize(sw, typeof(List<Request>));
            }
            if (requests == null)
            {
                requests = new List<Request>();
            }
        }

        public void SaveRequest(Request request)
        {
            requests.Add(request);

            JsonSerializer serializer = new JsonSerializer();
            FileStream fs = new FileStream(@"requests.txt", FileMode.OpenOrCreate);
            using (StreamWriter sw = new StreamWriter(fs, Encoding.Default))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, requests);
            }

        }

        public int Count()
        {
            if (requests != null)
            {
                return requests.Count;
            }
            return 0;
        }

        //public bool CheckLogin(string login)
        //{
        //    if (requests != null)
        //    {
        //        foreach (Request Request in requests)
        //        {
        //            if (Request.Login == login)
        //            {
        //                return false;
        //            }
        //        }
        //    }
        //    return true;
        //}

        //public bool CheckEmail(string email)
        //{
        //    if (requests != null)
        //    {
        //        foreach (Request request in requests)
        //        {
        //            if (request.Email == email)
        //            {
        //                return false;
        //            }
        //        }
        //    }
        //    return true;
        //}

        //public bool CheckAutorization(string login, string password)
        //{
        //    if (requests != null)
        //    {
        //        foreach (Request request in requests)
        //        {
        //            if (request.Login == login && request.Password == password)
        //            {
        //                return true;
        //            }
        //        }
        //    }
        //    return false;
        //}
    }
}
