using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace phoneser.Controllers
{
    public class CategoryController : Controller
    {

        public CategoryController()
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddCategory()
        {
            return View();
        }

        // GET: Category
        public ActionResult List()
        {
            return View();
        }



        public ActionResult CreateSpecs()
        {
            return View();
        }

        public ActionResult createTmple()
        {

            return View();
        }

    }
}