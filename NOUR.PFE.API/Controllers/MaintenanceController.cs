using Microsoft.AspNetCore.Mvc;
using System;

namespace NOUR.PFE.API.Controllers
{
    public class MaintenanceController : Controller
    {
        [HttpGet]
        [Route("GetAllMaintenance")]

        public ApiResponse GetAll()
        {
            try
            {
                Entities.Maintenances _Data = Repository.Maintenance.GetAll();
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
        [Route("AddMaintenance")]
        public ApiResponse Add(Entities.Maintenance maintenance)
        {
            try
            {
                bool _Success = Repository.Maintenance.Add(maintenance);

                return new ApiResponse
                {
                    Success = _Success,
                    Error = _Success ? -1 : 1,
                    Message = _Success ? "Success" : "Maintenance Add Failed!!!!!!",
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
