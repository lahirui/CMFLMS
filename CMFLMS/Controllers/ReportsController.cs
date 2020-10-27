using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMFLMS.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }
        [AuthorizeUsers]
        public ActionResult SupplierView()
        {
            return View();
        }
        [AuthorizeUsers]
        public ActionResult FabricView()
        {
            return View();
        }
        public ActionResult FabricReport()
        {
            return View();
        }
        public ActionResult FabricWebReport()
        {
            return View();
        }

        public ActionResult FabricSticker()
        {
            return View();
        }
    }
}