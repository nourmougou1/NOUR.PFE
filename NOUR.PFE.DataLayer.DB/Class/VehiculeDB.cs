using NOUR.PFE.DataLayer.Class;
using NOUR.PFE.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static NOUR.PFE.Entities.Enumeration.Enumeration;

namespace NOUR.PFE.DataLayer.DB
{
    public class VehiculeDB : IVehicule
    {
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

        #region Vehicule
        public IEnumerable<Vehicule> GetAllVehicule()
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


        public bool Add(Vehicule vehicule)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_vehicule_insert", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure; 

                        command.Parameters.Add("@vehiculeImm", SqlDbType.VarChar);
                        command.Parameters["@vehiculeImm"].Value = vehicule.Imm;

                        command.Parameters.Add("@vehiculeTypeId", SqlDbType.Int);
                        command.Parameters["@vehiculeTypeId"].Value = vehicule.VehiculeType.Id;

                        command.Parameters.Add("@brandId", SqlDbType.Int);
                        command.Parameters["@brandId"].Value = vehicule.VehiculeBrand.Id; 

                        command.Parameters.Add("@vehiculeKilometrage", SqlDbType.VarChar);
                        command.Parameters["@vehiculeKilometrage"].Value = vehicule.Kilometrage;

                        command.Parameters.Add("@parcId", SqlDbType.Int);
                        command.Parameters["@parcId"].Value = vehicule.parc.Id;

                        command.Parameters.Add("@statusId", SqlDbType.Int);
                        command.Parameters["@statusId"].Value = vehicule.Status.Status_id;

                        command.Parameters.Add("@purschaseDate", SqlDbType.DateTime);
                        command.Parameters["@purschaseDate"].Value = vehicule.PurshaseDate;




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
        public bool Update(Vehicule vehicule)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_vehicule_update", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        command.Parameters.Add("@vehiculeId", SqlDbType.VarChar);
                        command.Parameters["@vehiculeId"].Value = vehicule.Id;
                         
                        command.Parameters.Add("@vehiculeImm", SqlDbType.VarChar);
                        command.Parameters["@vehiculeImm"].Value = vehicule.Imm;

                        command.Parameters.Add("@vehiculeTypeId", SqlDbType.Int);
                        command.Parameters["@vehiculeTypeId"].Value = vehicule.VehiculeType.Id;

                        command.Parameters.Add("@brandId", SqlDbType.Int);
                        command.Parameters["@brandId"].Value = vehicule.VehiculeBrand.Id;

                        command.Parameters.Add("@vehiculeKilometrage", SqlDbType.VarChar);
                        command.Parameters["@vehiculeKilometrage"].Value = vehicule.Kilometrage; 

                        command.Parameters.Add("@statusId", SqlDbType.Int);
                        command.Parameters["@statusId"].Value = vehicule.Status.Status_id;

                        command.Parameters.Add("@purschaseDate", SqlDbType.DateTime);
                        command.Parameters["@purschaseDate"].Value = vehicule.PurshaseDate;
                         

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
        public bool Remove(Vehicule vehicule)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_vehicule_delete", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@vehiculeId", SqlDbType.Int);
                        command.Parameters["@vehiculeId"].Value = vehicule.Id;


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

        public Vehicule GetOneByType(Type type)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region enumBrand
        private enum EnumQryBrandFields
        {
            Id = 0,
            brandName,
            brandLogo
        }
        #endregion


        #region Vehicule Brand
        public IEnumerable<Entities.VehiculeBrand> GetAllBrands()
        {
            Entities.VehiculeBrands Ret = new Entities.VehiculeBrands();
            SqlDataReader DR = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_vehicule_brand_get_all", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        DR = command.ExecuteReader();

                        while (DR.Read())
                        {
                            Ret.Add(new Entities.VehiculeBrand()
                            {

                                Id = (!DR.IsDBNull((int)EnumQryBrandFields.Id))
                                         ? Convert.ToInt32(DR[(int)EnumQryBrandFields.Id])
                                         : 0,
                                Name = (!DR.IsDBNull((int)EnumQryBrandFields.brandName))
                                           ? DR[(int)EnumQryBrandFields.brandName].ToString()
                                           : string.Empty,
                                Logo = (!DR.IsDBNull((int)EnumQryBrandFields.brandLogo))
                                           ? DR[(int)EnumQryBrandFields.brandLogo].ToString()
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
         
        public bool AddBrand(Entities.VehiculeBrand vehiculeBrand)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_vehicule_brand_insert", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@brandId", SqlDbType.Int);
                        command.Parameters["@brandId"].Value = vehiculeBrand.Id;


                        command.Parameters.Add("@brandName", SqlDbType.VarChar);
                        command.Parameters["@brandName"].Value = vehiculeBrand.Name;


                        command.Parameters.Add("@brandLogo", SqlDbType.VarChar);
                        command.Parameters["@brandLogo"].Value = vehiculeBrand.Logo;



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

        public bool UpdateBrand(Entities.VehiculeBrand vehiculeBrand)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_vehicule_brand_update", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@vehiculeBrandId", SqlDbType.Int);
                        command.Parameters["@vehiculeBrandId"].Value = vehiculeBrand.Id;

                        command.Parameters.Add("@vehiculeBrandName", SqlDbType.VarChar);
                        command.Parameters["@vehiculeBrandName"].Value = vehiculeBrand.Name;

                        command.Parameters.Add("@brandLogo", SqlDbType.VarChar);
                        command.Parameters["@brandLogo"].Value = vehiculeBrand.Logo;


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

        public bool RemoveBrand(Entities.VehiculeBrand vehiculeBrand)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_vehicule_brand_delete", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@vehiculeBrandId", SqlDbType.Int);
                        command.Parameters["@vehiculeBrandId"].Value = vehiculeBrand.Id;

                        



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


        #endregion


        #region Vehicule Type
        public bool AddType(VehiculeType vehiculeType)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_vehicule_type_insert", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@typeId", SqlDbType.Int);
                        command.Parameters["@typeId"].Value = vehiculeType.Id;

                        command.Parameters.Add("@typeName", SqlDbType.VarChar);
                        command.Parameters["@typeName"].Value = vehiculeType.TypeName;


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

        public bool DeleteType(VehiculeType vehiculeType)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_vehicule_type_delete", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@vehiculeTypeId", SqlDbType.Int);
                        command.Parameters["@vehiculeTypeId"].Value = vehiculeType.Id;


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

        public bool UpdateType(VehiculeType vehiculeType)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_vehicule_type_update", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@typeId", SqlDbType.Int);
                        command.Parameters["@typeId"].Value = vehiculeType.Id;

                        command.Parameters.Add("@typeName", SqlDbType.VarChar);
                        command.Parameters["@typeName"].Value = vehiculeType.TypeName;


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

        #region enumsTypes
        private enum EnumQryTypeFields
        {
            Id = 0,
            typeName,

        }

        #endregion

        public IEnumerable<VehiculeType> GetAllTypes()
        {
            Entities.VehiculeTypes Ret = new Entities.VehiculeTypes();
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
                            Ret.Add(new Entities.VehiculeType()
                            {
                                Id = (!DR.IsDBNull((int)EnumQryTypeFields.Id))
                                         ? Convert.ToInt32(DR[(int)EnumQryTypeFields.Id])
                                         : 0,
                                TypeName = (!DR.IsDBNull((int)EnumQryTypeFields.typeName))
                                           ? DR[(int)EnumQryTypeFields.typeName].ToString()
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

        #endregion

        #region enumsPaths
        private enum EnumQryPathFields
        {
            id = 0,
            lat,
            lng 
        }


        #endregion

        #region vehiculePath
        public IEnumerable<VehiculePath> GetAllPaths()
        {
            Entities.VehiculePaths Ret = new Entities.VehiculePaths();
            SqlDataReader DR = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_vehicule_path_get_all", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        DR = command.ExecuteReader();

                        while (DR.Read())
                        {
                            Ret.Add(new Entities.VehiculePath()
                            {
                                Id = (!DR.IsDBNull((int)EnumQryPathFields.id))
                                         ? Convert.ToInt32(DR[(int)EnumQryPathFields.id])
                                         : 0,
                                Lat = (!DR.IsDBNull((int)EnumQryPathFields.lat))
                                           ? DR[(int)EnumQryPathFields.lat].ToString()
                                           : string.Empty,
                                Lng = (!DR.IsDBNull((int)EnumQryPathFields.lng))
                                         ? DR[(int)EnumQryPathFields.lng].ToString()
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

        public bool AddPath(VehiculePath vehiculePath)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_vehicule_path_insert", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;  

                        command.Parameters.Add("@pathLat", SqlDbType.VarChar);
                        command.Parameters["@pathLat"].Value = vehiculePath.Lat;
                         
                        command.Parameters.Add("@pathLng", SqlDbType.VarChar);
                        command.Parameters["@pathLng"].Value = vehiculePath.Lng;
                         
                        command.Parameters.Add("@vehiculeId", SqlDbType.Int);
                        command.Parameters["@vehiculeId"].Value = vehiculePath.VehiculeId;


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

        public bool DeletePath(VehiculePath vehiculePath)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_vehicule_path_delete", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@vehiculePathId", SqlDbType.Int);
                        command.Parameters["@vehiculePathId"].Value = vehiculePath.Id;

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

        public bool UpdatePath(VehiculePath vehiculePath)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region enumsStatus
        private enum EnumQryStatusFields
        {
            id = 0,
            name

        }


        #endregion
        public IEnumerable<VehiculeStatus> GetAllStatus()
        {
            Entities.VehiculeStatuss Ret = new Entities.VehiculeStatuss();
            SqlDataReader DR = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_vehicule_status_get_all", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        DR = command.ExecuteReader();

                        while (DR.Read())
                        {
                            Ret.Add(new Entities.VehiculeStatus()
                            {
                                Status_id = (!DR.IsDBNull((int)EnumQryStatusFields.id))
                                         ? Convert.ToInt32(DR[(int)EnumQryPathFields.id])
                                         : 0,
                                Status_name = (!DR.IsDBNull((int)EnumQryStatusFields.name))
                                           ? DR[(int)EnumQryStatusFields.name].ToString()
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

        public bool AddStatus(VehiculeStatus vehiculeStatus)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_vehicule_status_insert", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@statusId", SqlDbType.Int);
                        command.Parameters["@statusId"].Value = vehiculeStatus.Status_id;

                        command.Parameters.Add("@statusName", SqlDbType.VarChar);
                        command.Parameters["@statusName"].Value = vehiculeStatus.Status_name;

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

        public bool UpdateStatus(VehiculeStatus vehiculeStatus)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_vehicule_status_update", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@statusId", SqlDbType.Int);
                        command.Parameters["@statusId"].Value = vehiculeStatus.Status_id;

                        command.Parameters.Add("@statusName", SqlDbType.VarChar);
                        command.Parameters["@statusName"].Value = vehiculeStatus.Status_name;


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

        public bool DeleteStatus(VehiculeStatus vehiculeStatus)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_vehicule_status_delete", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@statusId", SqlDbType.Int);
                        command.Parameters["@statusId"].Value = vehiculeStatus.Status_id;


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



        

        

    }

}
