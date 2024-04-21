using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NOUR.PFE.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RequestController : Controller
    {
        
        private IConfiguration configuration;
        public RequestController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }
        [HttpGet]
        [Route("GetAllRequests")]
        public ApiResponse GetAllRequests()
        {
            try
            {
                Entities.Requests _Data = Repository.Request.GetAll();
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
        [Route("AddRequest")]
        public ApiResponse AddRequest(Entities.Request request)
        {
            try
            {
                bool _Success = Repository.Request.Add(request);
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
    }
}
