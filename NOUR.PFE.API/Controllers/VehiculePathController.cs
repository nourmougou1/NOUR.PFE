using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace NOUR.PFE.API.Controllers
{

    [ApiController]
    [Route("[controller]")]


    public class VehiculePathController : Controller
    {

        private IConfiguration configuration;

        public VehiculePathController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }


        [HttpGet]
        [Route("GetPaths")]
        public ApiResponse GetAllPaths()
        {
            try
            {
                Entities.VehiculePaths _Data = Repository.Vehicule.GetAllPaths();
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
        [Route("DeletePath")]
        public ApiResponse DeletePath(Entities.VehiculePath vehiculePath)
        {
            try
            {
                bool _Success = Repository.Vehicule.DeletePath(vehiculePath);

                return new ApiResponse
                {
                    Success = _Success,
                    Error = _Success ? -1 : 1,
                    Message = _Success ? "Success" : "Path Delete Failed!!!",
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
        [Route("AddPath")]
        public ApiResponse AddPath(Entities.VehiculePath vehiculePath) 
        {
            try
            {
                bool _Success = Repository.Vehicule.AddPath(vehiculePath);

                return new ApiResponse
                {
                    Success = _Success,
                    Error = _Success ? -1 : 1,
                    Message = _Success ? "Success" : "Path Add Failed!!!!!!",
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
        [Route("UpdatePath")]
        public ApiResponse UpdatePath(Entities.VehiculePath vehiculePath)
        {
            try
            {
                bool _Success = Repository.Vehicule.UpdatePath(vehiculePath);

                return new ApiResponse
                {
                    Success = _Success,
                    Error = _Success ? -1 : 1,
                    Message = _Success ? "Success" : "Path Update Failed!!!",
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
