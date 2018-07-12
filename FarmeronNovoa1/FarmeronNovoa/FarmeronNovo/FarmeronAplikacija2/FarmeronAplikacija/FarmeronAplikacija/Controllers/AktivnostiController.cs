using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

namespace FarmeronAplikacija.Controllers
{
    public class AktivnostiController : Controller
    {
        //
        // GET: /Aktivnosti/



        public ActionResult Index(int id)
        {
            var d = new BLL.BAktivnosti().GetAktivnosti(id);

            return View(d);
        }

        public ActionResult Display(int id)
        {
            var c = new BLL.BAktivnosti().GetOne(id);

            return View("Display", c);
        }

        public ActionResult Create()
        {
            var m = new BLL.BAktivnosti().Add();

            return View("Create", m);

        }
        [HttpPost]
        public JsonResult Create(DAL.Aktivnosti a)
        {

            new BLL.BAktivnosti().Add1(a);

            return Json(a, "json");
        }

        public ActionResult Edit(int id)
        {
            var d = new BLL.BAktivnosti().Update(id);

            return View("Edit", d);
        }

        [HttpPost]
        public JsonResult Edit(DAL.Aktivnosti m)
        {
            new BLL.BAktivnosti().Update1(m);

            return Json(m, "json");
        }

        public void Delete(int id)
        {
            var b = new BLL.BAktivnosti().Delete(id);

            //return View("Delete", b);
        }

        [HttpPost]
        [ActionName("Delete")]

        public void DeleteConfirmed(int id)
        {
            new BLL.BAktivnosti().Delete1(id);

            //return RedirectToAction("Index", new { id = id });
        }


    }
}
