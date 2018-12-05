using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using System.Web.Security;
using System.Data.Entity.Validation;

namespace LoginKorisnika.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(Registration registration)
        {
            //if (ModelState.IsValid)  
            //{  
            if (IsValid(registration.Email, registration.Password))
            {
                FormsAuthentication.SetAuthCookie(registration.Email, false);
                AddLoging(registration.Email);
                return RedirectToAction("Index", "UserInfo");
            }
            else
            {
                ModelState.AddModelError("", "Login details are wrong.");
            }
            return View(registration);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Registration registration)
        {
            DataManager dataManager = new DataManager();
            try
            {
                if (ModelState.IsValid)
                {
                    
                    var crypto = new SimpleCrypto.PBKDF2();
                    var encrypPass = crypto.Compute(registration.Password);
                    var newRegistration = new Registration();
                    newRegistration.Email = registration.Email;
                    newRegistration.Password = encrypPass;
                    newRegistration.PasswordSalt = crypto.Salt;
                    newRegistration.FirstName = registration.FirstName;
                    newRegistration.LastName = registration.LastName;

                    dataManager.AddRegistration(newRegistration);
                        
                    return RedirectToAction("Index", "Registration");
                    
                }
                else
                {
                    ModelState.AddModelError("", "Data is not correct");
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Registration");
        }

        private bool IsValid(string email, string password)
        {
            var crypto = new SimpleCrypto.PBKDF2();
            bool IsValid = false;
            DataManager manager = new DataManager();

            var registration = manager.GetRegistration(email);
                if (registration != null)
                {
                    if (registration.Password == crypto.Compute(password, registration.PasswordSalt))
                    {
                        IsValid = true;
                    }
                }
            
            return IsValid;
        }

        private void AddLoging(string email)
        {
            DataManager manager = new DataManager();
            var registration = manager.GetRegistration(email);
            var userinfo = manager.GetUserByEmail(email);
            if (userinfo == null)
            {
                UserInfo user = new UserInfo();
                user.Email = registration.Email;
                user.FirstName = registration.FirstName;
                user.LastName = registration.LastName;
                user.RegistrationId = registration.Id;
                user.LoginCount = 1;
                manager.AddUser(user);
            }
            else
            {
                userinfo.LoginCount += 1;
                manager.UpdateUser(userinfo);
            }

            var userq = manager.GetUserByEmail(email);
            AddLogingInfo(userq);
        }

        private void AddLogingInfo(UserInfo user)
        {
            var browser = Request.Browser;
            DataManager dataManager = new DataManager();
            UserLogin login = new UserLogin();
            login.Browser = browser.Browser + ","+browser.Version + "," + browser.Type;
            login.FirstName = user.FirstName;
            login.LastName = user.LastName;
            login.LogonDate = DateTime.Now;
            login.UserId = user.Id;

            dataManager.AddUserLogin(login);
        }
        
    }
}