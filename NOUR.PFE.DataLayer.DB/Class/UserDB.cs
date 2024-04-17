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
    public class UserDB : IUser
    {
       
    

        #region getAllUserRoles
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
                                Id = (!DR.IsDBNull((int)enumQryUserFields.roleId))
                                         ? Convert.ToInt32(DR[(int)enumQryUserFields.roleId])
                                         : 0,
                                Code = (!DR.IsDBNull((int)enumQryUserFields.roleCode))
                                           ? DR[(int)enumQryUserFields.roleCode].ToString()
                                           : string.Empty,
                                Name = (!DR.IsDBNull((int)enumQryUserFields.roleName))
                                           ? DR[(int)enumQryUserFields.roleName].ToString()
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

        #region EnumsUser
        private enum enumQryUserFields
        {
            id = 0,
            roleId,
            roleCode,
            roleName,
            firstName,
            lastName,
            login,
            password,
            email,
            phone,
            isActive,
            image,
            birthdate,
            creationDate
        }
        #endregion

        #region getAllUser
        public IEnumerable<User> GetAllUser()
        {
            Entities.Users Ret = new Entities.Users();
            SqlDataReader DR = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_user_get_all", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        DR = command.ExecuteReader();

                        while (DR.Read())
                        {
                            Ret.Add(new Entities.User()
                            {
                                Id = (!DR.IsDBNull((int)enumQryUserFields.id))
                                         ? Convert.ToInt32(DR[(int)enumQryUserFields.id])
                                         : 0,
                                UserRole = new UserRole()
                                {
                                    Id = (!DR.IsDBNull((int)enumQryUserFields.roleId))
                                             ? Convert.ToInt32(DR[(int)enumQryUserFields.roleId])
                                             : 0,
                                    Code = (!DR.IsDBNull((int)enumQryUserFields.roleCode))
                                               ? DR[(int)enumQryUserFields.roleCode].ToString()
                                               : string.Empty,
                                    Name = (!DR.IsDBNull((int)enumQryUserFields.roleName))
                                               ? DR[(int)enumQryUserFields.roleName].ToString()
                                               : string.Empty,
                                },

                                FirstName = (!DR.IsDBNull((int)enumQryUserFields.firstName))
                                           ? DR[(int)enumQryUserFields.firstName].ToString()
                                           : string.Empty,


                                LastName = (!DR.IsDBNull((int)enumQryUserFields.lastName))
                                           ? DR[(int)enumQryUserFields.lastName].ToString()
                                           : string.Empty,


                                Login = (!DR.IsDBNull((int)enumQryUserFields.login))
                                           ? DR[(int)enumQryUserFields.login].ToString()
                                           : string.Empty,


                                Password = (!DR.IsDBNull((int)enumQryUserFields.password))
                                           ? DR[(int)enumQryUserFields.password].ToString()
                                           : string.Empty,


                                Email = (!DR.IsDBNull((int)enumQryUserFields.email))
                                            ? DR[(int)enumQryUserFields.email].ToString()
                                            : string.Empty,


                                UserPhone = (!DR.IsDBNull((int)enumQryUserFields.phone))
                                            ? DR[(int)enumQryUserFields.phone].ToString()
                                            : string.Empty,


                                IsActive = (!DR.IsDBNull((int)enumQryUserFields.isActive))
                                               ? Convert.ToBoolean(DR[(int)enumQryUserFields.isActive].ToString())
                                               : false,


                                Birthday = (!DR.IsDBNull((int)enumQryUserFields.birthdate))
                                                ? Convert.ToDateTime(DR[(int)enumQryUserFields.birthdate].ToString())
                                                : new DateTime(1970, 1, 1),

                                CreationDate = (!DR.IsDBNull((int)enumQryUserFields.creationDate))
                                                   ? Convert.ToDateTime(DR[(int)enumQryUserFields.creationDate].ToString())
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
        #endregion
         
        public User GetOne(int userId)
        {
            Entities.User Ret = null;
            SqlDataReader DR = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_user_get_one_by_id", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@userId", SqlDbType.Int);
                        command.Parameters["@userId"].Value = userId;

                        conn.Open();
                        DR = command.ExecuteReader();

                        if (DR.Read())
                        {
                            Ret = new Entities.User()
                            {
                                Id = Convert.ToInt32(DR[(int)enumQryUserFields.id]),
                                FirstName = (!DR.IsDBNull((int)enumQryUserFields.firstName))
                                            ? DR[(int)enumQryUserFields.firstName].ToString()
                                            : string.Empty,
                                LastName = (!DR.IsDBNull((int)enumQryUserFields.lastName))
                                           ? DR[(int)enumQryUserFields.lastName].ToString()
                                           : string.Empty,
                                Login = (!DR.IsDBNull((int)enumQryUserFields.login))
                                        ? DR[(int)enumQryUserFields.login].ToString()
                                        : string.Empty,
                                Password = (!DR.IsDBNull((int)enumQryUserFields.password))
                                           ? DR[(int)enumQryUserFields.password].ToString()
                                           : string.Empty,
                                Email = (!DR.IsDBNull((int)enumQryUserFields.email))
                                        ? DR[(int)enumQryUserFields.email].ToString()
                                        : string.Empty,
                                UserPhone = (!DR.IsDBNull((int)enumQryUserFields.phone))
                                        ? DR[(int)enumQryUserFields.phone].ToString()
                                        : string.Empty,
                                IsActive = (!DR.IsDBNull((int)enumQryUserFields.isActive))
                                           ? Convert.ToBoolean(DR[(int)enumQryUserFields.isActive].ToString())
                                           : false,
                                Birthday = (!DR.IsDBNull((int)enumQryUserFields.birthdate))
                                            ? Convert.ToDateTime(DR[(int)enumQryUserFields.birthdate].ToString())
                                            : new DateTime(1970, 1, 1),
                                CreationDate = (!DR.IsDBNull((int)enumQryUserFields.creationDate))
                                               ? Convert.ToDateTime(DR[(int)enumQryUserFields.creationDate].ToString())
                                               : new DateTime(1970, 1, 1),
                                UserRole = new UserRole()
                                {
                                    Id = (!DR.IsDBNull((int)enumQryUserFields.roleId))
                                         ? Convert.ToInt32(DR[(int)enumQryUserFields.roleId])
                                         : 0,
                                    Code = (!DR.IsDBNull((int)enumQryUserFields.roleCode))
                                           ? DR[(int)enumQryUserFields.roleCode].ToString()
                                           : string.Empty,
                                    Name = (!DR.IsDBNull((int)enumQryUserFields.roleName))
                                           ? DR[(int)enumQryUserFields.roleName].ToString()
                                           : string.Empty,
                                },
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

        //public User GetOneByLogin(string userLogin)
        //{
        //    Entities.User Ret = null;
        //    SqlDataReader DR = null;

        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
        //        {
        //            using (SqlCommand command = new SqlCommand("sp_user_get_one_by_login", conn))
        //            {
        //                command.CommandType = CommandType.StoredProcedure;

        //                command.Parameters.Add("@userLogin", SqlDbType.VarChar);
        //                command.Parameters["@userLogin"].Value = userLogin;

        //                conn.Open();
        //                DR = command.ExecuteReader();

        //                while (DR.Read())
        //                {
        //                    Ret = new Entities.User()
        //                    {
        //                        Id = Convert.ToInt32(DR[(int)enumQryUserFields.id]),
        //                        FirstName = (!DR.IsDBNull((int)enumQryUserFields.firstName))
        //                                    ? DR[(int)enumQryUserFields.firstName].ToString()
        //                                    : string.Empty,
        //                        LastName = (!DR.IsDBNull((int)enumQryUserFields.lastName))
        //                                   ? DR[(int)enumQryUserFields.lastName].ToString()
        //                                   : string.Empty,
        //                        Login = (!DR.IsDBNull((int)enumQryUserFields.login))
        //                                ? DR[(int)enumQryUserFields.login].ToString()
        //                                : string.Empty,
        //                        Password = (!DR.IsDBNull((int)enumQryUserFields.password))
        //                                   ? DR[(int)enumQryUserFields.password].ToString()
        //                                   : string.Empty,
        //                        Email = (!DR.IsDBNull((int)enumQryUserFields.email))
        //                                ? DR[(int)enumQryUserFields.email].ToString()
        //                                : string.Empty,
        //                        UserPhone = (!DR.IsDBNull((int)enumQryUserFields.phone))
        //                                ? DR[(int)enumQryUserFields.phone].ToString()
        //                                : string.Empty,
        //                        IsActive = (!DR.IsDBNull((int)enumQryUserFields.isActive))
        //                                   ? Convert.ToBoolean(DR[(int)enumQryUserFields.isActive].ToString())
        //                                   : false,
        //                        Image = (!DR.IsDBNull((int)enumQryUserFields.image))
        //                                ? DR[(int)enumQryUserFields.image].ToString()
        //                                : string.Empty,
        //                        Birthday = (!DR.IsDBNull((int)enumQryUserFields.birthdate))
        //                                    ? Convert.ToDateTime(DR[(int)enumQryUserFields.birthdate].ToString())
        //                                    : new DateTime(1970, 1, 1),
        //                        CreationDate = (!DR.IsDBNull((int)enumQryUserFields.creationDate))
        //                                       ? Convert.ToDateTime(DR[(int)enumQryUserFields.creationDate].ToString())
        //                                       : new DateTime(1970, 1, 1),
        //                        UserRole = new UserRole()
        //                        {
        //                            Id = (!DR.IsDBNull((int)enumQryUserFields.roleId))
        //                                 ? Convert.ToInt32(DR[(int)enumQryUserFields.roleId])
        //                                 : 0,
        //                            Code = (!DR.IsDBNull((int)enumQryUserFields.roleCode))
        //                                   ? DR[(int)enumQryUserFields.roleCode].ToString()
        //                                   : string.Empty,
        //                            Name = (!DR.IsDBNull((int)enumQryUserFields.roleName))
        //                                   ? DR[(int)enumQryUserFields.roleName].ToString()
        //                                   : string.Empty,
        //                        },
        //                    };
        //                }
        //            }
        //        }

        //        return Ret;
        //    }
        //    catch (Exception ex)
        //    {
        //        string strEx = ex.Message;
        //        throw;
        //    }
        //    finally
        //    {
        //        if (DR != null)
        //        {
        //            DR.Close();
        //            DR = null;
        //        }
        //    }
        //}

        public User GetOneByLogin(string userLogin)
        {
            Entities.User Ret = null;
            SqlDataReader DR = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_user_get_one_by_login", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@userLogin", SqlDbType.VarChar);
                        command.Parameters["@userLogin"].Value = userLogin;

                        conn.Open();
                        DR = command.ExecuteReader();

                        while (DR.Read())
                        {
                            Ret = new Entities.User()
                            {
                                Id = Convert.ToInt32(DR[(int)enumQryUserFields.id]),
                                FirstName = (!DR.IsDBNull((int)enumQryUserFields.firstName))
                                            ? DR[(int)enumQryUserFields.firstName].ToString()
                                            : string.Empty,
                                LastName = (!DR.IsDBNull((int)enumQryUserFields.lastName))
                                            ? DR[(int)enumQryUserFields.lastName].ToString()
                                            : string.Empty,

                                Login = (!DR.IsDBNull((int)enumQryUserFields.login))
                                        ? DR[(int)enumQryUserFields.login].ToString()
                                        : string.Empty,
                                Password = (!DR.IsDBNull((int)enumQryUserFields.password))
                                           ? DR[(int)enumQryUserFields.password].ToString()
                                           : string.Empty,
                                Email = (!DR.IsDBNull((int)enumQryUserFields.email))
                                        ? DR[(int)enumQryUserFields.email].ToString()
                                        : string.Empty,
                                UserPhone = (!DR.IsDBNull((int)enumQryUserFields.phone))
                                        ? DR[(int)enumQryUserFields.phone].ToString()
                                        : string.Empty,
                                IsActive = (!DR.IsDBNull((int)enumQryUserFields.isActive))
                                           ? Convert.ToBoolean(DR[(int)enumQryUserFields.isActive].ToString())
                                           : false,

                                Image = (!DR.IsDBNull((int)enumQryUserFields.image))
                                           ? DR[(int)enumQryUserFields.image].ToString()
                                           : string.Empty,
                                Birthday = (!DR.IsDBNull((int)enumQryUserFields.birthdate))
                                            ? Convert.ToDateTime(DR[(int)enumQryUserFields.birthdate].ToString())
                                            : new DateTime(1970, 1, 1),
                                CreationDate = (!DR.IsDBNull((int)enumQryUserFields.creationDate))
                                               ? Convert.ToDateTime(DR[(int)enumQryUserFields.creationDate].ToString())
                                               : new DateTime(1970, 1, 1),
                                UserRole = new UserRole()
                                {
                                    Id = (!DR.IsDBNull((int)enumQryUserFields.roleId))
                                         ? Convert.ToInt32(DR[(int)enumQryUserFields.roleId])
                                         : 0,
                                    Code = (!DR.IsDBNull((int)enumQryUserFields.roleCode))
                                           ? DR[(int)enumQryUserFields.roleCode].ToString()
                                           : string.Empty,
                                    Name = (!DR.IsDBNull((int)enumQryUserFields.roleName))
                                           ? DR[(int)enumQryUserFields.roleName].ToString()
                                           : string.Empty,
                                },
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


        public bool Add(User user)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_user_insert", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@roleId", SqlDbType.Int);
                        command.Parameters["@roleId"].Value = user.UserRole.Id;

                        command.Parameters.Add("@firstName", SqlDbType.VarChar);
                        command.Parameters["@firstName"].Value = user.FirstName;

                        command.Parameters.Add("@lastName", SqlDbType.VarChar);
                        command.Parameters["@lastName"].Value = user.LastName;

                        command.Parameters.Add("@login", SqlDbType.VarChar);
                        command.Parameters["@login"].Value = user.Login;

                        command.Parameters.Add("@password", SqlDbType.VarChar);
                        command.Parameters["@password"].Value = Utils.Crypto.Encrypt(user.Password, Entities.Constant.CONST_CIPHER_PHRASE);

                        command.Parameters.Add("@email", SqlDbType.VarChar);
                        command.Parameters["@email"].Value = user.Email;

                        command.Parameters.Add("@phone", SqlDbType.VarChar);
                        command.Parameters["@phone"].Value = user.UserPhone;

                        command.Parameters.Add("@birthDate", SqlDbType.DateTime);
                        command.Parameters["@birthDate"].Value = user.Birthday;

                        command.Parameters.Add("@img", SqlDbType.VarChar);
                        command.Parameters["@img"].Value = user.Image;

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

        public bool Remove(User user)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_user_delete", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@userId", SqlDbType.Int);
                        command.Parameters["@userId"].Value = user.Id;


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

        public bool Update(User user)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_user_update", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@userId", SqlDbType.Int);
                        command.Parameters["@userId"].Value = user.Id;

                        command.Parameters.Add("@roleId", SqlDbType.Int);
                        command.Parameters["@roleId"].Value = user.UserRole.Id;

                        command.Parameters.Add("@firstName", SqlDbType.VarChar);
                        command.Parameters["@firstName"].Value = user.FirstName;

                        command.Parameters.Add("@lastName", SqlDbType.VarChar);
                        command.Parameters["@lastName"].Value = user.LastName;

                        command.Parameters.Add("@login", SqlDbType.VarChar);
                        command.Parameters["@login"].Value = user.Login;

                        command.Parameters.Add("@password", SqlDbType.VarChar);
                        command.Parameters["@password"].Value = Utils.Crypto.Encrypt(user.Password, Entities.Constant.CONST_CIPHER_PHRASE);

                        command.Parameters.Add("@email", SqlDbType.VarChar);
                        command.Parameters["@email"].Value = user.Email;

                        command.Parameters.Add("@phone", SqlDbType.VarChar);
                        command.Parameters["@phone"].Value = user.UserPhone;

                        command.Parameters.Add("@isActive", SqlDbType.Bit);
                        command.Parameters["@isActive"].Value = user.IsActive;

                        command.Parameters.Add("@birthDate", SqlDbType.DateTime);
                        command.Parameters["@birthDate"].Value = user.Birthday;

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
