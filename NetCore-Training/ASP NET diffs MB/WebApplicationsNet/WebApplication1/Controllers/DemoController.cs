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
        public ActionResult Index(int id, Shared.Dtos.User user, Shared.DTOs.Product products)
        { 
            ViewBag.Title = "Index Page";

            return View();
        }
    }
}