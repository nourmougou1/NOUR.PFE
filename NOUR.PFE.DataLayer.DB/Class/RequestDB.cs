using NOUR.PFE.DataLayer.Class;
using NOUR.PFE.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices.ComTypes;
using static NOUR.PFE.Entities.Enumeration.Enumeration;
using NOUR.PFE.Entities.Class;

namespace NOUR.PFE.DataLayer.DB.Class
{
    public class RequestDB : IRequest
    {
        public bool Add(Request request)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_request_insert", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@userId", SqlDbType.Int);
                        command.Parameters["@userId"].Value = request.User.Id;

                        command.Parameters.Add("@VehiculeTypeId", SqlDbType.Int);
                        command.Parameters["@VehiculeTypeId"].Value = request.VehiculeType.Id;

                        command.Parameters.Add("@missionDescription", SqlDbType.VarChar);
                        command.Parameters["@missionDescription"].Value = request.Description;

                        command.Parameters.Add("@missionDate", SqlDbType.DateTime);
                        command.Parameters["@missionDate"].Value = request.MissionDate;

                        command.Parameters.Add("@missionLocation", SqlDbType.VarChar);
                        command.Parameters["@missionLocation"].Value = request.MissionAddress;


                       




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

        #region enumRequest
        private enum EnumQryRequestFields
        {
            id = 0,
            vehiculeId,
            missionDescription,
            UserId,
            UserLogin,
            missionDate,
            missionAddress,
            status,
            aparovalDate,
            vehiculeTypeId,
            vehiculeTypeName,
            requestDate

        }
        private enum EnumQryRequestGetOneById
        {
            id = 0,
            vehiculeTypeId,
            vehiculeTypeName,
            UserId,
            UserLogin,
            missionDate,
            missionAddress,
            aparovalDate,
            missionDescription,
            statusId,
            statusName,
            requestDate,
            vehichuleId

        }
        private enum EnumQryRequestGetAll
        {
            id = 0,
            missionDescription,
            UserId,
            UserLogin,
            missionDate,
            missionAddress,
            RequeststatusId,
            RequestStatusName,
            aparovalDate,
            vehiculeTypeId,
            vehiculeTypeName,
            requestDate,
            vehiculeId
           

        }
        #endregion

        public bool Remove(Request request)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_request_delete", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@requestId", SqlDbType.Int);
                        command.Parameters["@requestId"].Value = request.Id;


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

        public bool Update(Request request)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_request_update", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        

                        command.Parameters.Add("@vehiculeTypeId", SqlDbType.Int);
                        command.Parameters["@vehiculeTypeId"].Value = request.VehiculeType.Id;

                        command.Parameters.Add("@missionDescription", SqlDbType.VarChar);
                        command.Parameters["@missionDescription"].Value = request.Description;

                        command.Parameters.Add("@userId", SqlDbType.Int);
                        command.Parameters["@userId"].Value = request.User.Id;

                        command.Parameters.Add("@missionDate", SqlDbType.DateTime);
                        command.Parameters["@missionDate"].Value = request.MissionDate;

                        command.Parameters.Add("@missionAddress", SqlDbType.VarChar);
                        command.Parameters["@missionAddress"].Value = request.MissionAddress;

                        command.Parameters.Add("@statusId", SqlDbType.Int);
                        command.Parameters["@statusId"].Value = request.status.Id;

                        command.Parameters.Add("@vehiculeId", SqlDbType.Int);
                        command.Parameters["@vehiculeId"].Value = request.vehiculeId;

                        command.Parameters.Add("@requestId", SqlDbType.Int);
                        command.Parameters["@requestId"].Value = request.Id;


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

        IEnumerable<Request> IRequest.GetAll()
        {
            Entities.Requests Ret = new Entities.Requests();
            SqlDataReader DR = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_request_get_all", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        DR = command.ExecuteReader();

                        while (DR.Read())
                        {
                            Ret.Add(new Entities.Request()
                            {

                                Id = (!DR.IsDBNull((int)EnumQryRequestGetAll.id))
                                         ? Convert.ToInt32(DR[(int)EnumQryRequestGetAll.id])
                                         : 0,

                                Description = (!DR.IsDBNull((int)EnumQryRequestGetAll.missionDescription))
                                           ? DR[(int)EnumQryRequestGetAll.missionDescription].ToString()
                                           : string.Empty,

                                User = new User()
                                {
                                    Id = (!DR.IsDBNull((int)EnumQryRequestGetAll.UserId))
                                            ? Convert.ToInt32(DR[(int)EnumQryRequestGetAll.UserId])
                                            : 0,
                                    Login = (!DR.IsDBNull((int)EnumQryRequestGetAll.UserLogin))
                                           ? DR[(int)EnumQryRequestGetAll.UserLogin].ToString()
                                           : string.Empty,
                                },

                                MissionDate = (!DR.IsDBNull((int)EnumQryRequestGetAll.missionDate))
                                               ? Convert.ToDateTime(DR[(int)EnumQryRequestGetAll.missionDate].ToString())
                                               : new DateTime(1970, 1, 1),

                                MissionAddress = (!DR.IsDBNull((int)EnumQryRequestGetAll.missionAddress))
                                           ? DR[(int)EnumQryRequestGetAll.missionAddress].ToString()
                                           : string.Empty,
                                status = new RequestStatus()
                                {
                                    Id = (!DR.IsDBNull((int)EnumQryRequestGetAll.RequeststatusId))
                                            ? Convert.ToInt32(DR[(int)EnumQryRequestGetAll.RequeststatusId])
                                            : 0,
                                    Name  = (!DR.IsDBNull((int)EnumQryRequestGetAll.RequestStatusName))
                                           ? DR[(int)EnumQryRequestGetAll.RequestStatusName].ToString()
                                           : string.Empty,

                                },
                               
                                VehiculeType = new VehiculeType()
                                {
                                    Id = (!DR.IsDBNull((int)EnumQryRequestGetAll.vehiculeTypeId))
                                            ? Convert.ToInt32(DR[(int)EnumQryRequestGetAll.vehiculeTypeId])
                                            : 0,
                                    TypeName = (!DR.IsDBNull((int)EnumQryRequestGetAll.vehiculeTypeName))
                                           ? DR[(int)EnumQryRequestGetAll.vehiculeTypeName].ToString()
                                           : string.Empty,
                                },
                                ApprovalDate = (!DR.IsDBNull((int)EnumQryRequestGetAll.aparovalDate))
                                               ? Convert.ToDateTime(DR[(int)EnumQryRequestGetAll.aparovalDate].ToString())
                                               : new DateTime(1970, 1, 1),

                                //Vehicule = new Vehicule()
                                //{
                                //    Id = (!DR.IsDBNull((int)EnumQryRequestGetAll.vehiculeId))
                                //            ? Convert.ToInt32(DR[(int)EnumQryRequestGetAll.vehiculeId])
                                //            : 0,
                                //}
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

        public Request GetOneById(int Id)
        {
            Entities.Request Ret = null;
            SqlDataReader DR = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_request_get_one_by_id", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@requestId", SqlDbType.Int);
                        command.Parameters["@requestId"].Value = Id;

                        conn.Open();
                        DR = command.ExecuteReader();

                        if (DR.Read())
                        {
                            Ret = new Entities.Request()
                            {
                                Id = Convert.ToInt32(DR[(int)EnumQryRequestGetOneById.id]),

                                VehiculeType = new VehiculeType()
                                {
                                    Id = (!DR.IsDBNull((int)EnumQryRequestGetOneById.vehiculeTypeId))
                                         ? Convert.ToInt32(DR[(int)EnumQryRequestGetOneById.vehiculeTypeId])
                                         : 0,
                                    TypeName = (!DR.IsDBNull((int)EnumQryRequestGetOneById.vehiculeTypeName))
                                           ? DR[(int)EnumQryRequestGetOneById.vehiculeTypeName].ToString()
                                           : string.Empty,

                                },
                                User = new User()
                                {
                                    Id = (!DR.IsDBNull((int)EnumQryRequestGetOneById.UserId))
                                         ? Convert.ToInt32(DR[(int)EnumQryRequestGetOneById.UserId])
                                         : 0,

                                    Login = (!DR.IsDBNull((int)EnumQryRequestGetOneById.UserLogin))
                                           ? DR[(int)EnumQryRequestGetOneById.UserLogin].ToString()
                                           : string.Empty,
                                },
                                MissionDate = (!DR.IsDBNull((int)EnumQryRequestGetOneById.missionDate))
                                               ? Convert.ToDateTime(DR[(int)EnumQryRequestGetOneById.missionDate].ToString())
                                               : new DateTime(1970, 1, 1),

                                MissionAddress = (!DR.IsDBNull((int)EnumQryRequestGetOneById.missionAddress))
                                        ? DR[(int)EnumQryRequestGetOneById.missionAddress].ToString()
                                        : string.Empty,

                                ApprovalDate = (!DR.IsDBNull((int)EnumQryRequestGetOneById.aparovalDate))
                                               ? Convert.ToDateTime(DR[(int)EnumQryRequestGetOneById.aparovalDate].ToString())
                                               : new DateTime(1970, 1, 1),

                                Description = (!DR.IsDBNull((int)EnumQryRequestGetOneById.missionDescription))
                                                ? DR[(int)EnumQryRequestGetOneById.missionDescription].ToString()
                                                : string.Empty,

                                status = new RequestStatus()
                                {
                                    Id = (!DR.IsDBNull((int)EnumQryRequestGetOneById.statusId))
                                            ? Convert.ToInt32(DR[(int)EnumQryRequestGetOneById.statusId])
                                            : 0,
                                    Name = (!DR.IsDBNull((int)EnumQryRequestGetAll.RequestStatusName))
                                           ? DR[(int)EnumQryRequestGetAll.RequestStatusName].ToString()
                                           : string.Empty,
                                },
                                RequestDate = (!DR.IsDBNull((int)EnumQryRequestGetOneById.requestDate))
                                               ? Convert.ToDateTime(DR[(int)EnumQryRequestGetOneById.requestDate].ToString())
                                               : new DateTime(1970, 1, 1),
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
            throw new NotImplementedException();
        }
    }
}
