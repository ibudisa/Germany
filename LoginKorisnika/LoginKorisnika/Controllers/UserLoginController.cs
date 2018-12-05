using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace LoginKorisnika.Controllers
{
    public class UserLoginController : Controller
    {
        // GET: UserLogin
        public ActionResult Index()
        {
            DataManager manager = new DataManager();
            var logins = manager.GetLogins();
            return View(logins);
        }
    }
}