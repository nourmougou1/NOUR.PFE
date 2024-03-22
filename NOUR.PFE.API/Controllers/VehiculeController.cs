using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace NOUR.PFE.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehiculeController : Controller
    {
        private IConfiguration configuration;

        public VehiculeController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }


        [HttpGet]
        [Route("GetVehicules")]
        public ApiResponse GetVehicules()
        {
            try
            {
                Entities.Vehicules _Data = Repository.Vehicule.GetAll();
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
        [Route("AddVehicule")]
        public ApiResponse AddVehicule(Entities.Vehicule vehicule)
        {
            try
            {
                bool _Success = Repository.Vehicule.Add(vehicule);

                return new ApiResponse
                {
                    Success = _Success,
                    Error = _Success ? -1 : 1,
                    Message = _Success ? "Success" : "Vehicule Add Failed!!!!!!",
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
        [Route("UpdateVehicule")]
        public ApiResponse UpdateVehicule(Entities.Vehicule vehicule)
        {
            try
            {
                bool _Success = Repository.Vehicule.Update(vehicule);

                return new ApiResponse
                {
                    Success = _Success,
                    Error = _Success ? -1 : 1,
                    Message = _Success ? "Success" : "Vehicule Update Failed!!!",
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
        [Route("RemoveVehicule")]
        public ApiResponse RemoveVehicule(Entities.Vehicule vehicule)
        {
            try
            {
                bool _Success = Repository.Vehicule.Remove(vehicule);

                return new ApiResponse
                {
                    Success = _Success,
                    Error = _Success ? -1 : 1,
                    Message = _Success ? "Success" : "Vehicule Delete Failed!!!",
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





      

