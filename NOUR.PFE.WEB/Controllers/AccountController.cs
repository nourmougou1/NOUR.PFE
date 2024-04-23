using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace NOUR.PFE.Web.Controllers
{
    public class AccountController : Controller
    {


        private IConfiguration _Config;
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger, IConfiguration iConfig)
        {
            _logger = logger;
            _Config = iConfig;
        }


        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("User") != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            try
            {
                if (username != null && password != null)
                {
                    Entities.User _User = Repository.User.GetOneByLogin(username);
                    if (_User != null)
                    {
                        if (!_User.Authenticate(username.Trim(), Utils.Crypto.Encrypt(password, Entities.Constant.CONST_CIPHER_PHRASE)))
                        {
                            return View("Login");
                        }

                        HttpContext.Session.SetString("User", JsonConvert.SerializeObject(_User));

                        if ((_User.UserRole.Id == (int)Entities.Enumeration.Enumeration.UserRole.ADMIN) 
                         || (_User.UserRole.Id == (int)Entities.Enumeration.Enumeration.UserRole.RESPO))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            return RedirectToAction("Create", "Request");
                        }
                    }
                    else
                    {
                        return View("Login");
                    }
                }
                else
                {
                    return View("Login");
                }
            }

            catch (Exception ex)
            {
                string strEx = ex.Message;
                throw;
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("User");
            return RedirectToAction("Login");
        }
    }
}
