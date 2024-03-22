using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace NOUR.PFE.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserRoleController : ControllerBase
    {

        private IConfiguration configuration;

        public UserRoleController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }

        [HttpGet]
        [Route("GetUserRoles")]
        public ApiResponse GetUserRoles()
        {
            try
            {
                Entities.UserRoles _Data = Repository.Config.GetUserRoles();
                if (_Data != null)
                {
                    return new ApiResponse
                    {
                        Success = true,
                        Error = -1,
                        Message = "Success",
                        Data = _Data
                    };
                }
                else
                {
                    return new ApiResponse
                    {
                        Success = false,
                        Error = 2,
                        Message = "No Data Found!!!",
                        Data = null
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    Success = false,
                    Error = 0,
                    Message = ex.Message,
                    Data = null
                };
            }
        }


        [HttpPost]
        [Route("AddUserRole")]
        public ApiResponse AddUserRole(Entities.UserRole userRole)
        {
            try
            {
                bool _Success = Repository.Config.AddUserRole(userRole);

                return new ApiResponse
                {
                    Success = _Success,
                    Error = _Success ? -1 : 1,
                    Message = _Success ? "Success" : "UserRole Add Failed!!!!!!",
                    Data = null
                };

            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    Success = false,
                    Error = 0,
                    Message = ex.Message,
                    Data = null
                };
            }
        }


        [HttpPost]
        [Route("RemoveUserRole")] //delete user role doesn't work yet !!!!!
        public ApiResponse RemoveUserRole(Entities.UserRole userRole)
        {
            try
            {
                bool _Success = Repository.Config.DeleteUserRole(userRole);

                return new ApiResponse
                {
                    Success = _Success,
                    Error = _Success ? -1 : 1,
                    Message = _Success ? "Success" : "UserRole Delete Failed!!!",
                    Data = null
                };

            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    Success = false,
                    Error = 0,
                    Message = ex.Message,
                    Data = null
                };
            }
            /* [HttpGet]
             [Route("GetUserById")]
             public ApiResponse GetUserById(int UserID)
             {
                 try
                 {
                     Entities.User _Data = Repository.User.GetOne(UserID);
                     if (_Data != null)
                     {
                         return new ApiResponse
                         {
                             Success = true,
                             Error = -1,
                             Message = "Success",
                             Data = _Data
                         };
                     }
                     else
                     {
                         return new ApiResponse
                         {
                             Success = false,
                             Error = 2,
                             Message = "No Data Found!!!",
                             Data = null
                         };
                     }
                 }
                 catch (Exception ex)
                 {
                     return new ApiResponse
                     {
                         Success = false,
                         Error = 0,
                         Message = ex.Message,
                         Data = null
                     };
                 }
             }
            */
            /*  [HttpGet]
              [Route("GetUserByLogin")]
              public ApiResponse GetUserByLogin(string Login)
              {
                  try
                  {
                      Entities.User _Data = Repository.User.GetOneByLogin(Login);
                      if (_Data != null)
                      {
                          return new ApiResponse
                          {
                              Success = true,
                              Error = -1,
                              Message = "Success",
                              Data = _Data
                          };
                      }
                      else
                      {
                          return new ApiResponse
                          {
                              Success = false,
                              Error = 2,
                              Message = "No Data Found!!!",
                              Data = null
                          };
                      }
                  }
                  catch (Exception ex)
                  {
                      return new ApiResponse
                      {
                          Success = false,
                          Error = 0,
                          Message = ex.Message,
                          Data = null
                      };
                  }
              }



              [HttpPost]
              [Route("UpdateUser")]
              public ApiResponse UpdateUser(Entities.User user)
              {
                  try
                  {
                      bool _Success = Repository.User.Update(user);

                      return new ApiResponse
                      {
                          Success = _Success,
                          Error = _Success ? -1 : 1,
                          Message = _Success ? "Success" : "User Update Failed!!!",
                          Data = null
                      };

                  }
                  catch (Exception ex)
                  {
                      return new ApiResponse
                      {
                          Success = false,
                          Error = 0,
                          Message = ex.Message,
                          Data = null
                      };
                  }
              }



              }*/

        }

        [HttpPost]
        [Route("UpdateUserRole")]
        public ApiResponse UpdateUserRole(Entities.UserRole userRole) 
        {
            try
            {
                bool _Success = Repository.Config.UpdateUserRole(userRole);

                return new ApiResponse
                {
                    Success = _Success,
                    Error = _Success ? -1 : 1,
                    Message = _Success ? "Success" : "UserRole Update Failed!!!",
                    Data = null
                };

            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    Success = false,
                    Error = 0,
                    Message = ex.Message,
                    Data = null
                };
            }

        }

    }
}
