using NOUR.PFE.DataLayer.Class;
using NOUR.PFE.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

        public bool AddMaintenanceType(MaintenanceType maintenanceType)
        {
            throw new NotImplementedException();
        }

        #region enumsMaintenance
        private enum enumQryMaintenanceFields
        {
            id = 0,
            vehiculeId,
            dateDebut,
            typeId,
            typeName,
            typeDescription,
            address
        }
        #endregion

        public IEnumerable<Maintenance> GetAll() 
        {
            Entities.Maintenances Ret = new Entities.Maintenances();
            SqlDataReader DR = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_vehicule_type_get_all", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        DR = command.ExecuteReader();

                        while (DR.Read())
                        {
                            Ret.Add(new Entities.Maintenance()
                            {
                                Id = (!DR.IsDBNull((int)enumQryMaintenanceFields.id))
                                         ? Convert.ToInt32(DR[(int)enumQryMaintenanceFields.id])
                                         : 0,
                                Vehicule = new Vehicule()
                                {
                                    Id = (!DR.IsDBNull((int)enumQryMaintenanceFields.vehiculeId))
                                         ? Convert.ToInt32(DR[(int)enumQryMaintenanceFields.vehiculeId])
                                         : 0,

                                },


                                dateDebut = (!DR.IsDBNull((int)enumQryMaintenanceFields.dateDebut))
                                               ? Convert.ToDateTime(DR[(int)enumQryMaintenanceFields.dateDebut].ToString())
                                               : new DateTime(1970, 1, 1),
                                MaintenanceType = new MaintenanceType()
                                {
                                    Id = (!DR.IsDBNull((int)enumQryMaintenanceFields.typeId))
                                         ? Convert.ToInt32(DR[(int)enumQryMaintenanceFields.typeId])
                                         : 0,
                                    Name = (!DR.IsDBNull((int)enumQryMaintenanceFields.typeName))
                                           ? DR[(int)enumQryMaintenanceFields.typeName].ToString()
                                           : string.Empty,
                                    Description = (!DR.IsDBNull((int)enumQryMaintenanceFields.typeDescription))
                                           ? DR[(int)enumQryMaintenanceFields.typeDescription].ToString()
                                           : string.Empty,
                                },
                                address = (!DR.IsDBNull((int)enumQryMaintenanceFields.address))
                                           ? DR[(int)enumQryMaintenanceFields.address].ToString()
                                           : string.Empty,

                            });
                        }
                    }
                }
                return Ret;
            }
            catch (Exception ex)
            {
                string strEx = ex.Message;
                throw;
            }
            finally
            {
                if (DR != null)
                {
                    DR.Close();
                    DR = null;
                }

            }
        }

        #region enumMaintenanceType
        private enum enumQryMaintenanceTypeFields
        {
            id = 0,
            typeName,
            description
        }
        #endregion
        public IEnumerable<MaintenanceType> GetAllMaintenanceTypes()
        {
            //throw new NotImplementedException();
            Entities.MaintenanceTypes Ret = new Entities.MaintenanceTypes();
            SqlDataReader DR = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_maintenance_type_get_all", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        DR = command.ExecuteReader();

                        while (DR.Read())
                        {
                            Ret.Add(new Entities.MaintenanceType()
                            {
                                Id = (!DR.IsDBNull((int)enumQryMaintenanceTypeFields.id))
                                        ? Convert.ToInt32(DR[(int)enumQryMaintenanceTypeFields.id])
                                         : 0,
                                Description = (!DR.IsDBNull((int)enumQryMaintenanceTypeFields.description))
                                           ? DR[(int)enumQryMaintenanceTypeFields.description].ToString()
                                           : string.Empty,
                                Name = (!DR.IsDBNull((int)enumQryMaintenanceTypeFields.typeName))
                                           ? DR[(int)enumQryMaintenanceTypeFields.typeName].ToString()
                                           : string.Empty,
                                

                          
                            }); 
                        }
                    }
                }
                return Ret;
            }
            catch (Exception ex)
            {
                string strEx = ex.Message;
                throw;
            }
            finally
            {
                if (DR != null)
                {
                    DR.Close();
                    DR = null;
                }
            }
        }

        public Maintenance GetOneByVehiculeId(int VehiculeId)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Maintenance maintenance)
        {
            throw new NotImplementedException();
        }

        public bool RemoveMaintenanceType(MaintenanceType maintenanceType)
        {
            throw new NotImplementedException();
        }

        public bool Update(Maintenance maintenance)
        {
            throw new NotImplementedException();
        }

        public bool UpdateMaintenanceType(MaintenanceType maintenanceType)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Maintenance> IMaintenance.GetAll()
        {
            throw new NotImplementedException();
        }

        IEnumerable<MaintenanceType> IMaintenance.GetAllMaintenanceTypes()
        {
            throw new NotImplementedException();
        }
    }
}
