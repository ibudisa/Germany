using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

namespace FarmeronAplikacija.Controllers
{
    public class FarmeriController : Controller
    {
        //
        // GET: /Farmeri/

        public ActionResult Index()
        {
            var d = new BLL.BFarmeri().GetFarmeri();
            return View(d);

        }
        /*
        public string WelcomeMessage(string name)
        {
            string st = new BLL.BFarmeri().GetSurname(name);
            if (!(String.IsNullOrEmpty(name)))
            {
                return st;
            }
            else
            {
                return "Please enter name";
            }
        }*/

        public ActionResult Display(int id)
        {
            var c = new BLL.BFarmeri().GetFarmer(id);

            return View("Display", c);

        }

        public ActionResult Create()
        {
            var g = new BLL.BFarmeri().Add();

            return View("Create", g);
        }

        [HttpPost]
        public JsonResult Create(DAL.Farmeri d)
        {
            String s = new BLL.BFarmeri().Add1(d);
            ClRes c = new ClRes(d, s);

            return Json(c, "json");
        }

        public ActionResult Edit(int id)
        {
            var b = new BLL.BFarmeri().Update(id);

            return View("Edit", b);
        }
        [HttpPost]
        public JsonResult Edit(DAL.Farmeri g)
        {
            String s = new BLL.BFarmeri().Update1(g);
            ClRes c = new ClRes(g, s);

            return Json(c, "json");


        }

        public void Delete(int id)
        {
            DAL.Farmeri m = new BLL.BFarmeri().Delete(id);

            //return View("Delete", m);
        }


        [HttpPost]
        [ActionName("Delete")]
        public JsonResult DeleteConfirmed(int id)
        {
            String st = new BLL.BFarmeri().Delete1(id);

            return Json(st, "json");

        }
   /*
        [HttpPost]
        public string Add(int oib, string ime, string prezime)
        {
            if (!String.IsNullOrEmpty(oib.ToString()) && !String.IsNullOrEmpty(ime) && (!String.IsNullOrEmpty(prezime)))
                //TODO: Save the data in database
                return "Thank you " + ime + ". Record Saved.";
            else
                return "Please complete the form.";
        }
        */



    }
}
