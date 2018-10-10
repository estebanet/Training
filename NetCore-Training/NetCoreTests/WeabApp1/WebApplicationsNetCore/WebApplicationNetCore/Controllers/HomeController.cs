using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationNetCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int? identifier)
        {
            ViewBag.Title = "ASP .NET Core MVC Test!";

            return View();
        }
    }
}