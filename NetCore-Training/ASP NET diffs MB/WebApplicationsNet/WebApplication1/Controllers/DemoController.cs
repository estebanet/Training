using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class DemoController : Controller
    {
        public ActionResult PostData()
        {
            return View(viewName: "Formulario");
        }
        // GET: Demo/Index
        public ActionResult Index(int id, User user, Product products)
        { 
            ViewBag.Title = "Index Page";

            return View();
        }
    }
}