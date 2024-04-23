﻿using NOUR.PFE.DataLayer.Class;
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
            missionDate,
            missionAsdress,
            status,
            aparovalDate,
            vehiculeTypeId

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

                        command.Parameters.Add("@requestId", SqlDbType.Int);
                        command.Parameters["@requestId"].Value = request.Id;

                        command.Parameters.Add("@vehiculeId", SqlDbType.Int);
                        command.Parameters["@vehiculeId"].Value = request.Vehicule.Id;

                        command.Parameters.Add("@missionDescription", SqlDbType.VarChar);
                        command.Parameters["@missionDescription"].Value = request.Description;

                        command.Parameters.Add("@userId", SqlDbType.Int);
                        command.Parameters["@userId"].Value = request.User.Id;

                        command.Parameters.Add("@missionDate", SqlDbType.DateTime);
                        command.Parameters["@missionDate"].Value = request.MissionDate;

                        command.Parameters.Add("@missionAddress", SqlDbType.VarChar);
                        command.Parameters["@missionAddress"].Value = request.MissionAddress;

                        command.Parameters.Add("@status", SqlDbType.Bit);
                        command.Parameters["@status"].Value = request.Status;

                        command.Parameters.Add("@approvalDate", SqlDbType.DateTime);
                        command.Parameters["@approvalDate"].Value = request.ApprovalDate;

                        command.Parameters.Add("@approvalDate", SqlDbType.DateTime);
                        command.Parameters["@approvalDate"].Value = request.ApprovalDate;

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

                                Id = (!DR.IsDBNull((int)EnumQryRequestFields.id))
                                         ? Convert.ToInt32(DR[(int)EnumQryRequestFields.id])
                                         : 0,

                                Vehicule = new Vehicule()
                                {
                                    Id = (!DR.IsDBNull((int)EnumQryRequestFields.vehiculeId))
                                            ? Convert.ToInt32(DR[(int)EnumQryRequestFields.vehiculeId])
                                            : 0,

                                    VehiculeType = new VehiculeType()
                                    {
                                        Id = (!DR.IsDBNull((int)EnumQryRequestFields.vehiculeTypeId))
                                            ? Convert.ToInt32(DR[(int)EnumQryRequestFields.vehiculeTypeId])
                                            : 0,
                                    },
                                },

                                Description = (!DR.IsDBNull((int)EnumQryRequestFields.missionDescription))
                                           ? DR[(int)EnumQryRequestFields.missionDescription].ToString()
                                           : string.Empty,

                                User = new User()
                                {
                                    Id = (!DR.IsDBNull((int)EnumQryRequestFields.UserId))
                                            ? Convert.ToInt32(DR[(int)EnumQryRequestFields.UserId])
                                            : 0,
                                },

                                MissionDate = (!DR.IsDBNull((int)EnumQryRequestFields.missionDate))
                                               ? Convert.ToDateTime(DR[(int)EnumQryRequestFields.missionDate].ToString())
                                               : new DateTime(1970, 1, 1),

                                MissionAddress = (!DR.IsDBNull((int)EnumQryRequestFields.missionAsdress))
                                           ? DR[(int)EnumQryRequestFields.missionAsdress].ToString()
                                           : string.Empty,
                                Status = (!DR.IsDBNull((int)EnumQryRequestFields.status))
                                              ? Convert.ToBoolean(DR[(int)EnumQryRequestFields.status].ToString())
                                              : false,
                                ApprovalDate = (!DR.IsDBNull((int)EnumQryRequestFields.aparovalDate))
                                               ? Convert.ToDateTime(DR[(int)EnumQryRequestFields.aparovalDate].ToString())
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

        public Request GetOneyId(int Id)
        {
            //Entities.Request Ret = null;
            //SqlDataReader DR = null;

            //try
            //{
            //    using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
            //    {
            //        using (SqlCommand command = new SqlCommand("sp_request_get_one_by_id", conn))
            //        {
            //            command.CommandType = CommandType.StoredProcedure;

            //            command.Parameters.Add("@userId", SqlDbType.Int);
            //            command.Parameters["@userId"].Value = userId;

            //            conn.Open();
            //            DR = command.ExecuteReader();

            //            if (DR.Read())
            //            {
            //                Ret = new Entities.User()
            //                {
            //                    Id = Convert.ToInt32(DR[(int)enumQryUserFields.id]),
            //                    FirstName = (!DR.IsDBNull((int)enumQryUserFields.firstName))
            //                                ? DR[(int)enumQryUserFields.firstName].ToString()
            //                                : string.Empty,
            //                    LastName = (!DR.IsDBNull((int)enumQryUserFields.lastName))
            //                               ? DR[(int)enumQryUserFields.lastName].ToString()
            //                               : string.Empty,
            //                    Login = (!DR.IsDBNull((int)enumQryUserFields.login))
            //                            ? DR[(int)enumQryUserFields.login].ToString()
            //                            : string.Empty,
            //                    Password = (!DR.IsDBNull((int)enumQryUserFields.password))
            //                               ? DR[(int)enumQryUserFields.password].ToString()
            //                               : string.Empty,
            //                    Email = (!DR.IsDBNull((int)enumQryUserFields.email))
            //                            ? DR[(int)enumQryUserFields.email].ToString()
            //                            : string.Empty,
            //                    UserPhone = (!DR.IsDBNull((int)enumQryUserFields.phone))
            //                            ? DR[(int)enumQryUserFields.phone].ToString()
            //                            : string.Empty,
            //                    IsActive = (!DR.IsDBNull((int)enumQryUserFields.isActive))
            //                               ? Convert.ToBoolean(DR[(int)enumQryUserFields.isActive].ToString())
            //                               : false,
            //                    Birthday = (!DR.IsDBNull((int)enumQryUserFields.birthdate))
            //                                ? Convert.ToDateTime(DR[(int)enumQryUserFields.birthdate].ToString())
            //                                : new DateTime(1970, 1, 1),
            //                    CreationDate = (!DR.IsDBNull((int)enumQryUserFields.creationDate))
            //                                   ? Convert.ToDateTime(DR[(int)enumQryUserFields.creationDate].ToString())
            //                                   : new DateTime(1970, 1, 1),
            //                    UserRole = new UserRole()
            //                    {
            //                        Id = (!DR.IsDBNull((int)enumQryUserFields.roleId))
            //                             ? Convert.ToInt32(DR[(int)enumQryUserFields.roleId])
            //                             : 0,
            //                        Code = (!DR.IsDBNull((int)enumQryUserFields.roleCode))
            //                               ? DR[(int)enumQryUserFields.roleCode].ToString()
            //                               : string.Empty,
            //                        Name = (!DR.IsDBNull((int)enumQryUserFields.roleName))
            //                               ? DR[(int)enumQryUserFields.roleName].ToString()
            //                               : string.Empty,
            //                    },
            //                };
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
            throw new NotImplementedException();
        }
    }
}
