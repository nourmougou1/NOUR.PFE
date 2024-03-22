using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NOUR.PFE.Entities;
using System;
using static NOUR.PFE.Entities.Enumeration.Enumeration;

namespace NOUR.PFE.API.Controllers
{
    public class VehiculeStatusController : Controller
    {
        [HttpGet]
        [Route("GetVehiculeStatus")]
        public ApiResponse GetVehiculeStatus()
        {
            try
            {
                Entities.VehiculeStatuss _Data = Repository.Vehicule.GetAllStatus();
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
        [Route("AddVehiculeStatus")]
        public ApiResponse AddVehiculeStatus(Entities.VehiculeStatus vehiculeStatus)
        {
            try
            {
                bool _Success = Repository.Vehicule.AddStatus(vehiculeStatus);

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
        [Route("UpdateVehiculeStatus")]
        public ApiResponse UpdateVehiculeStatus(Entities.VehiculeStatus vehiculeStatus)
        {
            try
            {
                bool _Success = Repository.Vehicule.UpdateStatus(vehiculeStatus);

                return new ApiResponse
                {
                    Success = _Success,
                    Error = _Success ? -1 : 1,
                    Message = _Success ? "Success" : "VehiculeStatus Update Failed!!!",
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
        [Route("DeleteVehiculeStatus")]
        public ApiResponse DeleteVehiculeStatus(Entities.VehiculeStatus vehiculeStatus)
        {
            try
            {
                bool _Success = Repository.Vehicule.DeleteStatus(vehiculeStatus);

                return new ApiResponse
                {
                    Success = _Success,
                    Error = _Success ? -1 : 1,
                    Message = _Success ? "Success" : "VehiculeStatus Delete Failed!!!",
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

