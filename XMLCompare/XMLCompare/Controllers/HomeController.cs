using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using DAL;

namespace XMLCompare.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           

            return View();
        }

        public ActionResult Edit()
        {
            string[] files = Directory.GetFiles(@"C:\drivers\XML");
            int j=0;
            DataObject d = new DataObject();
            //d.DeleteNodes();
            //d.DeleteFileData();
            for (int i = 0; i < files.Length; i++)
            {
                j++;
                if (i < files.Length - 1)
                {
                    CompareFile c = new CompareFile(@files[i], @files[files.Length-1]);
                     c.Compare();
                             
                }
            }

            return RedirectToAction("Display");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Display()
        {
            DataObject d = new DataObject();
        
            IEnumerable<Node> report = d.GetNodes();
       
            return View(report);
        }
        
    }
}
