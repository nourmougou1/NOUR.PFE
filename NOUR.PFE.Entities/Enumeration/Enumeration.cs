using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOUR.PFE.Entities.Enumeration
{
    public static class Enumeration
    {
        public enum Langue
        {
            AR = 1,
            FR,
            EN
        }

        public enum UserRole
        {
            ADMIN = 1,
            USER,
            RESPO
        }

        #region VehiculeBrand
        public enum VehiculeBrand
        {
            Honda = 1,
            AlfaRomeo,
            Audi,
            Bestune,
            Bmw,
            BYD,
            Changan,
            Chery,
            Chevrolet,
            Cupra,
            Ford,
            Fiat,
            Faw,
            Desk,
            Gacmotor,
            Geely,
            GWM,
            Haval,
            Jeep,
            Jaguar,
            LandRover,
            Kia,
            Mahindra,
            MercedesBenz,
            MG,
            Nissan,
            Opel,
            MitsubishiMotors,
            Peugeot,
            Porsches,
            Renault,
            Skoda,
            Soueast,
            Suzuki,
            Tata,
            Vokswagen,
            Volvo,
            Wallys,
            Citroen,
            Passat,
            Lamburguini,
            Corvette,
            Camaro,
            Viper,
            Ferrari,
            Shelpi


        }
        #endregion

        #region VehiculeType
        public enum VehiculeTypes
        {
            Van = 1,
            PickupTruck,
            Truck,
            Bus,
            Limousine,
            Minivan,
            Motorcycle

        }
        #endregion

        #region VehiculeStatus
        public enum VehiculeStat
        {
            Reserved = 1,
            Available,
            Maintenance

        }
        #endregion

        #region VehiculeStatus
        public enum enumReqStat
        {
            Confirmed = 1,
            Pending,
            Refused

        }
        #endregion

        #region Maintenance
        public enum MaintenanceType
        {
            MaintenancePreventive,
            MaintenanceCorrectice,
            MaintenancePredictive
        }


        #endregion

    }
}