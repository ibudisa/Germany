using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace XMLCompare.Controllers
{
    public class FileController : Controller
    {
        //
        // GET: /File/

        public ActionResult Index(int id)
        {
            DataObject d = new DataObject();
            IEnumerable<FileData> data = d.GetFilesByID(id);
            return View(data);
        }

    }
}
