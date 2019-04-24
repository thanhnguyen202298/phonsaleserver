using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace phoneser.Controllers
{
    public class ProductionController : Controller
    {
        public ProductionController()
        {
        }
        // GET: Production
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PostNewProduction()
        {
            //if (SignedAdmin())
            return View();
            //return RedirectToAction("Errorn");

        }

        public ActionResult Errorn()
        {

            return View();
        }
    }
}