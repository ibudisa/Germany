using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using AplikacijaNaselja.Models;
using AplikacijaNaselja.Mapper;

namespace AplikacijaNaselja.Controllers
{
    public class NaseljaController : Controller
    {
        // GET: Naselja
        public ActionResult Index()
        {
            var datamanager = new DataManager();
            var list = datamanager.GetNaselja();
            List<NaseljaViewModel> data = new List<NaseljaViewModel>();

            foreach(var item in list)
            {
                var result = MapperData.MapToView(item);
                data.Add(result);
            }
            ViewBag.BrojNaselja = datamanager.BrojNaselja();
            return View(data);
        }

        [HttpGet]
        public PartialViewResult Create()   //Insert PartialView  
        {
            var item = new NaseljaViewModel();
            DataManager manager = new DataManager();
            var list = manager.GetDrzave();
            ViewBag.Drzave = new SelectList(list, "Naziv", "Naziv");
            return PartialView(item);
        }
        [HttpPost]
        public JsonResult Create(NaseljaViewModel model) // Record Insert  
        {
            DataManager db = new DataManager();
            var naselje = MapperData.MapToDomain(model);
            db.AddNaselje(naselje);
            return Json(naselje, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public PartialViewResult Edit(Int32 id)  // Update PartialView  
        {
            DataManager db = new DataManager();
            Naselja naselja = db.GetNaselje(id);
            NaseljaViewModel model = MapperData.MapToView(naselja);
            var list = db.GetDrzave();
            ViewBag.Drzave = new SelectList(list, "Naziv", "Naziv");
            return PartialView(model);
        }

        [HttpPost]
        public JsonResult Edit(Naselja model)  // Record Update 
        {

            DataManager db = new DataManager();
            //var mapped = MapperData.MapToDomain(model);
            //var naselje = db.GetNaselje(model.Id);

            //naselje.Drzava = model.Drzava;
            //naselje.Naziv = model.Naziv;
            //naselje.PostanskiBroj = model.PostanskiBroj;


            db.UpdateNaselje(model);

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(Int32 id)
        {
            DataManager dataManager = new DataManager();
            dataManager.DeleteNaselje(id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}