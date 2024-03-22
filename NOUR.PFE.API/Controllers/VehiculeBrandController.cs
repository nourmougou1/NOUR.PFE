using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace NOUR.PFE.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehiculeBrandController : Controller
    {

        private IConfiguration configuration;

        public VehiculeBrandController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }

        [HttpGet]
        [Route("GetVehiculeBrands")]
        public ApiResponse GetVehiculeBrands()
        {
            try
            {
                Entities.VehiculeBrands _Data = Repository.Vehicule.GetAllBrands();
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
        [Route("AddVehiculeBrand")]
        public ApiResponse AddVehiculeBrand(Entities.VehiculeBrand vehiculeBrand)
        {
            try
            {
                bool _Success = Repository.Vehicule.AddBrand(vehiculeBrand);

                return new ApiResponse
                {
                    Success = _Success,
                    Error = _Success ? -1 : 1,
                    Message = _Success ? "Success" : "User Add Failed!!!!!!",
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
        [Route("UpdateVehiculeBrand")]
        public ApiResponse UpdateVehiculeBrand(Entities.VehiculeBrand vehiculeBrand)
        {
            try
            {
                bool _Success = Repository.Vehicule.UpdateBrand(vehiculeBrand);

                return new ApiResponse
                {
                    Success = _Success,
                    Error = _Success ? -1 : 1,
                    Message = _Success ? "Success" : "VehiculeBrand Update Failed!!!",
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
        [Route("RemoveVehiculeBrand")]
        public ApiResponse RemoveVehiculeBrand(Entities.VehiculeBrand vehiculeBrand)
        {
            try
            {
                bool _Success = Repository.Vehicule.RemoveBrand(vehiculeBrand);

                return new ApiResponse
                {
                    Success = _Success,
                    Error = _Success ? -1 : 1,
                    Message = _Success ? "Success" : "VehiculeBrand Delete Failed!!!",
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
