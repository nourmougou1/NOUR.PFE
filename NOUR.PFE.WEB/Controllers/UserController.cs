using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NOUR.PFE.DataLayer.Class;
using NOUR.PFE.WEB.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NOUR.PFE.WEB.Controller

{
    public class UserController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IWebHostEnvironment hostEnvironment;
        public UserController(IWebHostEnvironment hostEnvironment)
        {

            this.hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            UserViewModel _Model = new UserViewModel();
            _Model.Users = Repository.User.GetAll();
            return View("Index", _Model);
        }

        public ActionResult Create()
        {

            Models.UserViewModel _Model = new Models.UserViewModel
            {
                UserRoles = Repository.Config.GetUserRoles()
            };

            return View(_Model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Models.UserViewModel _Model)
        {
            if (ModelState.IsValid)
            {
                Entities.Users _Users = Repository.User.GetAll();

                if (_Users.FirstOrDefault(u => u.Login.Trim().Equals(_Model.Login.Trim())) != null)
                {
                    ModelState.AddModelError("Login", "login invalide!");
                    _Model.UserRoles = Repository.Config.GetUserRoles();

                    return View(_Model);
                }

                if (_Users.FirstOrDefault(u => u.Email.Trim().Equals(_Model.Email.Trim())) != null)
                {
                    ModelState.AddModelError("Email", "email invalide!");
                    _Model.UserRoles = Repository.Config.GetUserRoles();

                    return View(_Model);
                }

                var userRole = new Entities.UserRole() { Id = _Model.UserRoleId };

                //ToDo Nawara
                var UserRole = Repository.Config.GetUserRoleByID(_Model.UserRoleId);

                string fileName = "user3.png";
                if (_Model.File != null)
                {
                    string img = Path.Combine(hostEnvironment.WebRootPath, "img");
                    fileName = _Model.File.FileName;
                    string fullPath = Path.Combine(img, fileName);
                    _Model.File.CopyTo(new FileStream(fullPath, FileMode.Create));
                }

                var user = new Entities.User
                {
                    FirstName = _Model.FirstName,
                    LastName = _Model.LastName,
                    Login = _Model.Login,
                    Password = _Model.Password,
                    Email = _Model.Email,
                    UserPhone = _Model.UserPhone,
                    //IsActive = _Model.IsActive,
                    IsActive = true,
                    Birthday = _Model.Birthday,
                    //Birthday = DateTime.Now,
                    CreationDate = DateTime.Now,
                    UserRole = userRole,
                    Image = fileName

                };

                if (Repository.User.Add(user))
                {
                    //Entities.MailData _Data = new Entities.MailData()
                    //{
                    //    ReceiverName = user.Login,
                    //    EmailTo = user.Email,
                    //    SenderName = "developpement@hotixsoft.com",
                    //    EmailSubject = "Compte Utilisateur",
                    //    EmailBody = string.Concat("Félicitations", " votre compte d'utilisateur a été créé avec succès.Voici les informations nécessaires à votre identification:Login: " + user.Login + " " + "votre mot de passe: " + user.Password),
                    //    EmailFrom = "developpement@hotixsoft.com",
                    //    EmailPass = "Dev@2021",
                    //    SmtpServer = "mail.bmail.tn",
                    //    SmtpPort = 465,
                    //    UseSsl = true,
                    //    IsHTML = true
                    //};

                    Utils.Mailing.sendMailHtml("NAWARA", user.Email, "HOTIX",
                                                     "Your Account has been created successfully", $"Your account was created successfully,\n your login is : {user.Login}\n Your password is : {user.Password}  ", "developpement@hotixsoft.com",
                                                     "hD@123456", "mail.bmail.tn", 465, true, false);

                    TempData["SuccessMessage"] = "User created successfully";
                    return RedirectToAction(nameof(Index));

                }
            }

            _Model.UserRoles = Repository.Config.GetUserRoles();
            return View(_Model);
        }

        public IActionResult Details(int id)
        {
            var User = Repository.User.GetOne(id);
            return View(User);
        }


        public IActionResult Edit(int id)
        {
            var user = Repository.User.GetOne(id);
            //string uniqueFileName = UploadedFile(user);
            try
            {
                Models.UserViewModel _Model = new Models.UserViewModel
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Login = user.Login,
                    Password = Utils.Crypto.Decrypt(user.Password.Trim(), Entities.Constant.CONST_CIPHER_PHRASE),
                    Email = user.Email,
                    UserPhone = user.UserPhone,
                    Image = user.Image,
                    IsActive = user.IsActive,
                    Birthday = user.Birthday,
                    CreationDate = user.CreationDate,
                    UserRoleId = user.UserRole.Id,
                    UserRoles = Repository.Config.GetUserRoles(),
                };

                return View(_Model);
            }
            catch (Exception ex)
            {
                ErrorViewModel _EModel = new ErrorViewModel() { RequestId = String.Concat("User.Edit ", Environment.NewLine, ex.Message) };
                return RedirectToAction("Error", "Errors", _EModel);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Models.UserViewModel _Model)
        {
            var user = Repository.User.GetOne(id);
            if (ModelState.IsValid)
            {
                string fileName = user.Image;
                if (_Model.Image != null)
                {
                    string img = Path.Combine(hostEnvironment.WebRootPath, "img");
                    fileName = _Model.Image;
                    string fullPath = Path.Combine(img, fileName);
                    //Delete the old file
                    string oldFileName = Repository.User.GetOne(_Model.Id).Image;
                    string fullOldPath = Path.Combine(img, oldFileName);
                    if (fullPath != fullOldPath)
                    {
                        if (fullPath != fullOldPath)
                        {
                            //System.IO.File.Delete(fullOldPath);
                        }
                        //Save the new File
                        _Model.File.CopyTo(new FileStream(fullPath, FileMode.Create));
                    }
                }
                var userRole = Repository.Config.GetUserRoleByID(_Model.UserRoleId);
                //string uniqueFileName = UploadedFile(_Model);

                var editeUser = new Entities.User
                {
                    Id = _Model.Id,
                    FirstName = _Model.FirstName,
                    LastName = _Model.LastName,
                    Login = _Model.Login,
                    Password = _Model.Password,
                    Email = _Model.Email,
                    UserPhone = _Model.UserPhone,
                    IsActive = _Model.IsActive,
                    Birthday = _Model.Birthday,
                    CreationDate = _Model.CreationDate,
                    // ImageUrl = fileName,
                    UserRole = userRole
                };

                Repository.User.Update(editeUser);

                return RedirectToAction(nameof(Index));


            }
            _Model.UserRoles = Repository.Config.GetUserRoles();
            _Model.Image = user.Image;

            return View(_Model);

        }

        public ActionResult Delete(int id)
        {
            var user = Repository.User.GetOne(id);
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Entities.User user)
        {

            try
            {

                Repository.User.Remove(user);
                return RedirectToAction(nameof(Index));
            }

            catch
            {
                return View();
            }
        }


    }


}
