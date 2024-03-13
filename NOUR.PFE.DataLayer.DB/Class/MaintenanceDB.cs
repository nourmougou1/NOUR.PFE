using NOUR.PFE.DataLayer.Class;
using NOUR.PFE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOUR.PFE.DataLayer.DB
{
    public class MaintenanceDB : IMaintenance
    {
        public bool Add(Maintenance maintenance)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Maintenances> GetAll()
        {
            throw new NotImplementedException();
        }

        public Maintenance GetOneByVehiculeId(int VehiculeId)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Maintenance maintenance)
        {
            throw new NotImplementedException();
        }

        public bool Update(Maintenance maintenance)
        {
            throw new NotImplementedException();
        }
    }
}
