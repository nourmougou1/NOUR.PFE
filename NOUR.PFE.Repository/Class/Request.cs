using NOUR.PFE.DataLayer;
using NOUR.PFE.DataLayer.Class;
using NOUR.PFE.DataLayer.DB;
using NOUR.PFE.DataLayer.DB.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOUR.PFE.Repository
{
    public static class Request
    {
        private static IRequest Request_DL;
        static Request()
        {
            Request_DL = new RequestDB();
        }

        public static Entities.Requests GetAll(int UserID = -1)
        {
            return (Request_DL != null) 
                ? new Entities.Requests(Request_DL.GetAll(UserID))
                : null;

        }
        
 

        public static bool Add(Entities.Request request)
        {
            return (Request_DL != null)
                   ? Request_DL.Add(request)
                   : false;
        }

        public static bool Update(Entities.Request request)
        {
            return (Request_DL != null)
                   ? Request_DL.Update(request)
                   : false;
        }
        public static bool Remove(Entities.Request request)
        {
            return (Request_DL != null)
                   ? Request_DL.Remove(request)
                   : false;
        }
        public static Entities.Request GetOneById(int ID)
        {
            return (Request_DL != null)
                   ? Request_DL.GetOneById(ID)
                   : null;
        }

    }
}
