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
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_vehicule_maintenance_insert", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        command.Parameters.Add("@vehiculeId", SqlDbType.Int);
                        command.Parameters["@vehiculeId"].Value = maintenance.VehiculeId;

                        command.Parameters.Add("@maintenanceTypeId", SqlDbType.Int);
                        command.Parameters["@maintenanceTypeId"].Value = maintenance.MaintenanceTypeId;

                        command.Parameters.Add("@maintenanceDate", SqlDbType.DateTime);
                        command.Parameters["@maintenanceDate"].Value = maintenance.DateDebut;

                        command.Parameters.Add("@maintenanceAddress", SqlDbType.VarChar);
                        command.Parameters["@maintenanceAddress"].Value = maintenance.Address;


                        conn.Open();
                        Ret = command.ExecuteNonQuery();
                    }
                }

                return Ret > -1;
            }
            catch (Exception ex)
            {
                string strEx = ex.Message;
                throw;
            }
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
        private enum enumQryMaintenanceTypesFields
        {
            typeId = 0,
            typeName,
            typeDescription
        }
        #endregion

        //public IEnumerable<Maintenance> GetAll() 
        //{
        //Entities.Maintenances Ret = new Entities.Maintenances();
        //SqlDataReader DR = null;

        //try
        //{
        //    using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
        //    {
        //        using (SqlCommand command = new SqlCommand("sp_vehicule_maintenance_get_all", conn))
        //        {
        //            command.CommandType = CommandType.StoredProcedure;
        //            conn.Open();
        //            DR = command.ExecuteReader();

        //            while (DR.Read())
        //            {
        //                Ret.Add(new Entities.Maintenance()
        //                {
        //                    Id = (!DR.IsDBNull((int)enumQryMaintenanceFields.id))
        //                             ? Convert.ToInt32(DR[(int)enumQryMaintenanceFields.id])
        //                             : 0,
        //                    Vehicule = new Vehicule()
        //                    {
        //                        Id = (!DR.IsDBNull((int)enumQryMaintenanceFields.vehiculeId))
        //                             ? Convert.ToInt32(DR[(int)enumQryMaintenanceFields.vehiculeId])
        //                             : 0,

        //                    },

        //                    DateDebut = (!DR.IsDBNull((int)enumQryMaintenanceFields.dateDebut))
        //                                   ? Convert.ToDateTime(DR[(int)enumQryMaintenanceFields.dateDebut].ToString())
        //                                   : new DateTime(1970, 1, 1),
        //                    MaintenanceType = new MaintenanceType()
        //                    {
        //                        Id = (!DR.IsDBNull((int)enumQryMaintenanceFields.typeId))
        //                             ? Convert.ToInt32(DR[(int)enumQryMaintenanceFields.typeId])
        //                             : 0,
        //                        Name = (!DR.IsDBNull((int)enumQryMaintenanceFields.typeName))
        //                               ? DR[(int)enumQryMaintenanceFields.typeName].ToString()
        //                               : string.Empty,
        //                        Description = (!DR.IsDBNull((int)enumQryMaintenanceFields.typeDescription))
        //                               ? DR[(int)enumQryMaintenanceFields.typeDescription].ToString()
        //                               : string.Empty,
        //                    },
        //                    Address = (!DR.IsDBNull((int)enumQryMaintenanceFields.address))
        //                               ? DR[(int)enumQryMaintenanceFields.address].ToString()
        //                               : string.Empty,

        //                });
        //            }
        //        }
        //    }
        //    return Ret;
        //}
        //catch (Exception ex)
        //{
        //    string strEx = ex.Message;
        //    throw;
        //}
        //finally
        //{
        //    if (DR != null)
        //    {
        //        DR.Close();
        //        DR = null;
        //    }

        //}
        //}

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


        IEnumerable<MaintenanceType> IMaintenance.GetAllMaintenanceTypes()
        {
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
                                Id = (!DR.IsDBNull((int)enumQryMaintenanceTypesFields.typeId))
                                         ? Convert.ToInt32(DR[(int)enumQryMaintenanceTypesFields.typeId])
                                         : 0,
                                Name = (!DR.IsDBNull((int)enumQryMaintenanceTypesFields.typeName))
                                           ? DR[(int)enumQryMaintenanceTypesFields.typeName].ToString()
                                           : string.Empty,
                                Description = (!DR.IsDBNull((int)enumQryMaintenanceTypesFields.typeDescription))
                                           ? DR[(int)enumQryMaintenanceTypesFields.typeDescription].ToString()
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
        public bool RemoveMaintenanceType(MaintenanceType maintenanceType)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_maintenance_type_delete", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@maintenanceTypeId", SqlDbType.Int);
                        command.Parameters["@maintenanceTypeId"].Value = maintenanceType.Id;

                        conn.Open();
                        Ret = command.ExecuteNonQuery();
                    }
                }

                return Ret > -1;
            }
            catch (Exception ex)
            {
                string strEx = ex.Message;
                throw;
            }
        }
        public bool UpdateMaintenanceType(MaintenanceType maintenanceType)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_maintenance_type_update", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@maintenanceTypeId", SqlDbType.Int);
                        command.Parameters["@maintenanceTypeId"].Value = maintenanceType.Id;

                        command.Parameters.Add("@maintenanceTypeName", SqlDbType.VarChar);
                        command.Parameters["@maintenanceTypeName"].Value = maintenanceType.Description;

                        command.Parameters.Add("@maintenanceTypeDescription", SqlDbType.VarChar);
                        command.Parameters["@maintenanceTypeDescription"].Value = maintenanceType.Description;


                        conn.Open();
                        Ret = command.ExecuteNonQuery();
                    }
                }

                return Ret > -1;
            }
            catch (Exception ex)
            {
                string strEx = ex.Message;
                throw;
            }
        }
        public bool AddMaintenanceType(MaintenanceType maintenanceType)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_maintenance_type_insert", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@maintenanceTypeId", SqlDbType.Int);
                        command.Parameters["@maintenanceTypeId"].Value = maintenanceType.Id;

                        command.Parameters.Add("@maintenanceTypeName", SqlDbType.VarChar);
                        command.Parameters["@maintenanceTypeName"].Value = maintenanceType.Description;

                        command.Parameters.Add("@maintenanceTypeDescription", SqlDbType.VarChar);
                        command.Parameters["@maintenanceTypeDescription"].Value = maintenanceType.Description;

                        conn.Open();
                        Ret = command.ExecuteNonQuery();
                    }
                }

                return Ret > -1;
            }
            catch (Exception ex)
            {
                string strEx = ex.Message;
                throw;
            }
        }
        public MaintenanceType GetMaintenanceTypeById(int maintenanceTypeId)
        {
            Entities.MaintenanceType Ret = null;
            SqlDataReader DR = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_maintenance_type_get_one_by_id", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@maintenanceTypeId", SqlDbType.Int);
                        command.Parameters["@maintenanceTypeId"].Value = maintenanceTypeId;

                        conn.Open();
                        DR = command.ExecuteReader();

                        if (DR.Read())
                        {
                            Ret = new Entities.MaintenanceType()
                            {
                                Id = Convert.ToInt32(DR[(int)enumQryMaintenanceTypeFields.id]),
                                Name = (!DR.IsDBNull((int)enumQryMaintenanceTypeFields.typeName))
                                            ? DR[(int)enumQryMaintenanceTypeFields.typeName].ToString()
                                            : string.Empty,
                                Description = (!DR.IsDBNull((int)enumQryMaintenanceTypeFields.description))
                                           ? DR[(int)enumQryMaintenanceTypeFields.description].ToString()
                                           : string.Empty,

                            };
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



        public bool Update(Maintenance maintenance)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Maintenance maintenance)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Maintenance> IMaintenance.GetAll()
        {
            Entities.Maintenances Ret = new Entities.Maintenances();
            SqlDataReader DR = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_vehicule_maintenance_get_all", conn))
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

                                DateDebut = (!DR.IsDBNull((int)enumQryMaintenanceFields.dateDebut))
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
                                Address = (!DR.IsDBNull((int)enumQryMaintenanceFields.address))
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
        #region EnumsVehicule
        private enum enumQryVehiculeFields
        {
            vehicule_id = 0,
            Imm,
            typeId,
            typeName,
            brandId,
            brandName,
            brandLogo,
            StatusId,
            StatusName,
            Kilometrage,
            parcId,
            parcName,
            parcAdress,
            PurshaseDate
        }
        #endregion

     

        IEnumerable<Vehicule> IMaintenance.GetAllVehicule()
        {
            Entities.Vehicules Ret = new Entities.Vehicules();
            SqlDataReader DR = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_vehicule_get_all", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        DR = command.ExecuteReader();

                        while (DR.Read())
                        {
                            Ret.Add(new Entities.Vehicule()
                            {
                                Id = (!DR.IsDBNull((int)enumQryVehiculeFields.vehicule_id))
                                         ? Convert.ToInt32(DR[(int)enumQryVehiculeFields.vehicule_id])
                                         : 0,


                                Imm = (!DR.IsDBNull((int)enumQryVehiculeFields.Imm))
                                           ? DR[(int)enumQryVehiculeFields.Imm].ToString()
                                           : string.Empty,

                                VehiculeType = new VehiculeType()
                                {
                                    Id = (!DR.IsDBNull((int)enumQryVehiculeFields.typeId))
                                            ? Convert.ToInt32(DR[(int)enumQryVehiculeFields.typeId])
                                            : 0,

                                    TypeName = (!DR.IsDBNull((int)enumQryVehiculeFields.typeName))
                                              ? DR[(int)enumQryVehiculeFields.typeName].ToString()
                                              : string.Empty,


                                },

                                VehiculeBrand = new Entities.VehiculeBrand()
                                {
                                    Id = (!DR.IsDBNull((int)enumQryVehiculeFields.brandId))
                                        ? Convert.ToInt32(DR[(int)enumQryVehiculeFields.brandId])
                                        : 0,
                                    Name = (!DR.IsDBNull((int)enumQryVehiculeFields.brandName))
                                          ? DR[(int)enumQryVehiculeFields.brandName].ToString()
                                          : string.Empty,
                                    Logo = (!DR.IsDBNull((int)enumQryVehiculeFields.brandLogo))
                                          ? DR[(int)enumQryVehiculeFields.brandLogo].ToString()
                                          : string.Empty,
                                },

                                Status = new VehiculeStatus()
                                {
                                    Status_id = (!DR.IsDBNull((int)enumQryVehiculeFields.StatusId))
                                            ? Convert.ToInt32(DR[(int)enumQryVehiculeFields.StatusId])
                                            : 0,
                                    Status_name = (!DR.IsDBNull((int)enumQryVehiculeFields.StatusName))
                                              ? DR[(int)enumQryVehiculeFields.StatusName].ToString()
                                              : string.Empty,
                                },

                                Kilometrage = (!DR.IsDBNull((int)enumQryVehiculeFields.Kilometrage))
                                           ? DR[(int)enumQryVehiculeFields.Kilometrage].ToString()
                                           : string.Empty,

                                parc = new Parc()
                                {
                                    Id = (!DR.IsDBNull((int)enumQryVehiculeFields.parcId))
                                            ? Convert.ToInt32(DR[(int)enumQryVehiculeFields.parcId])
                                            : 0,
                                    Name = (!DR.IsDBNull((int)enumQryVehiculeFields.parcName))
                                              ? DR[(int)enumQryVehiculeFields.parcName].ToString()
                                              : string.Empty,
                                    Adress = (!DR.IsDBNull((int)enumQryVehiculeFields.parcAdress))
                                              ? DR[(int)enumQryVehiculeFields.parcAdress].ToString()
                                              : string.Empty,

                                },

                                PurshaseDate = (!DR.IsDBNull((int)enumQryVehiculeFields.PurshaseDate))
                                               ? Convert.ToDateTime(DR[(int)enumQryVehiculeFields.PurshaseDate].ToString())
                                               : new DateTime(1970, 1, 1),


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
    }
}