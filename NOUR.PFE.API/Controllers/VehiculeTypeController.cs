using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace NOUR.PFE.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehiculeTypeController : Controller
    {
        private IConfiguration configuration;

        public VehiculeTypeController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }
        [HttpGet]
        [Route("GetVehiculeTypes")]
        public ApiResponse GetVehiculeTypes()
        {
            try
            {
                Entities.VehiculeTypes _Data = Repository.Vehicule.GetAllTypes();
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
        [Route("AddVehiculeType")]
        public ApiResponse AddVehiculeType(Entities.VehiculeType vehiculeType)
        {
            try
            {
                bool _Success = Repository.Vehicule.AddType(vehiculeType);

                return new ApiResponse
                {
                    Success = _Success,
                    Error = _Success ? -1 : 1,
                    Message = _Success ? "Success" : "Vehicule Type Add Failed!!!!!!",
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
        [Route("DeleteVehiculeType")]
        public ApiResponse DeleteVehiculeType(Entities.VehiculeType vehiculeType) 
             
        {
            try
            {
                bool _Success = Repository.Vehicule.DeleteType(vehiculeType);

                return new ApiResponse
                {
                    Success = _Success,
                    Error = _Success ? -1 : 1,
                    Message = _Success ? "Success" : "Vehicule Type Delete Failed!!!",
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
        [Route("UpdateVehiculeType")]
        public ApiResponse UpdateType (Entities.VehiculeType vehiculeType)
        {
            try
            {
                bool _Success = Repository.Vehicule.UpdateType(vehiculeType);

                return new ApiResponse
                {
                    Success = _Success,
                    Error = _Success ? -1 : 1,
                    Message = _Success ? "Success" : "Vehicule Type Update Failed!!!",
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
