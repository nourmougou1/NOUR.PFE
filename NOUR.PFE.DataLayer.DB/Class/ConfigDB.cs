using NOUR.PFE.DataLayer.Class;
using NOUR.PFE.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace NOUR.PFE.DataLayer.DB
{
    public class ConfigDB : IConfig
    {
        #region EnumsUserRole
        private enum enumQryUserRoleFields
        {
            role_id = 0,
            role_code,
            role_name
        }
        #endregion

        public IEnumerable<UserRole> GetUserRoles()
        {
            Entities.UserRoles Ret = new Entities.UserRoles();
            SqlDataReader DR = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_user_role_get_all", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        DR = command.ExecuteReader();

                        while (DR.Read())
                        {
                            Ret.Add(new Entities.UserRole()
                            {
                                Id = (!DR.IsDBNull((int)enumQryUserRoleFields.role_id))
                                         ? Convert.ToInt32(DR[(int)enumQryUserRoleFields.role_id])
                                         : 0,
                                Code = (!DR.IsDBNull((int)enumQryUserRoleFields.role_code))
                                           ? DR[(int)enumQryUserRoleFields.role_code].ToString()
                                           : string.Empty,
                                Name = (!DR.IsDBNull((int)enumQryUserRoleFields.role_name))
                                           ? DR[(int)enumQryUserRoleFields.role_name].ToString()
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

        public UserRole GetUserRoleByCode(string code)
        {
            throw new NotImplementedException();
        }

        public UserRole GetUserRoleByID(int roleId)
        {
            Entities.UserRole Ret = null;
            SqlDataReader DR = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_user_role_get_one_by_id", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@RoleId", SqlDbType.Int);
                        command.Parameters["@RoleId"].Value = roleId;

                        conn.Open();
                        DR = command.ExecuteReader();

                        if (DR.Read())
                        {
                            Ret = new Entities.UserRole()
                            {
                                Id = (!DR.IsDBNull((int)enumQryUserRoleFields.role_id))
                                         ? Convert.ToInt32(DR[(int)enumQryUserRoleFields.role_id])
                                         : 0,
                                Code = (!DR.IsDBNull((int)enumQryUserRoleFields.role_code))
                                           ? DR[(int)enumQryUserRoleFields.role_code].ToString()
                                           : string.Empty,
                                Name = (!DR.IsDBNull((int)enumQryUserRoleFields.role_name))
                                           ? DR[(int)enumQryUserRoleFields.role_name].ToString()
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

        public bool AddUserRole(UserRole UserRole)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_user_role_insert", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;  

                        command.Parameters.Add("@roleName", SqlDbType.VarChar);
                        command.Parameters["@roleName"].Value = UserRole.Name; 

                        command.Parameters.Add("@roleCode", SqlDbType.VarChar);
                        command.Parameters["@roleCode"].Value = UserRole.Code;

                       

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

        public bool UpdateUserRole(UserRole UserRole)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_user_role_update", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@roleId", SqlDbType.Int);
                        command.Parameters["@roleId"].Value = UserRole.Id;

                        command.Parameters.Add("@roleName", SqlDbType.VarChar);
                        command.Parameters["@roleName"].Value = UserRole.Name;

                        command.Parameters.Add("@roleCode", SqlDbType.VarChar);
                        command.Parameters["@roleCode"].Value = UserRole.Code;

                       
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

        public bool DeleteUserRole(UserRole UserRole)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_user_role_delete", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@roleId", SqlDbType.Int);
                        command.Parameters["@roleId"].Value = UserRole.Id;

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
