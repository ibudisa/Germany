using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using System.Net;
using System.Data.Entity.Infrastructure;

namespace LoginKorisnika.Controllers
{
    public class UserInfoController : Controller
    {
        // GET: UserInfo
        public ActionResult Index()
        {
            DataManager dataManager = new DataManager();
            var list = dataManager.GetUsers();
            return View(list);
        }

        public ActionResult Create()
        {
            var user = new UserInfo();

            return View(user);
        }

        [HttpPost]
        public ActionResult Create(UserInfo user)
        {
            DataManager data = new DataManager();

            if (ModelState.IsValid)
            {
                data.AddUser(user);

            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {

            DataManager manager = new DataManager();
           
            var user = manager.GetUser(id);

            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(UserInfo user)
        {
            DataManager manager = new DataManager();
            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {

                manager.UpdateUser(user);

            }
            catch (RetryLimitExceededException ec/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }

            return RedirectToAction("Index");
        }

     

        [HttpGet]
        public ActionResult Delete(int id)
        {
            DataManager manager = new DataManager();

            var user = manager.GetUser(id);

            try
            {
                var userid = user.Id;
                var logins = manager.GetLoginsByUser(userid);
                manager.DeleteUserLogins(logins);
                manager.DeleteUser(id);

                return Json(true, JsonRequestBehavior.AllowGet); ;
            }
            catch(Exception ec)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}