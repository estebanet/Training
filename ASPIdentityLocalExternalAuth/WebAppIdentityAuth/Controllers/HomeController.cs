using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace WebAppIdentityAuth.Controllers
{
    [Models.Filters.Auth(Roles = "Admin")]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ClaimsPrincipal Principal =
                //System.Threading.Thread.CurrentPrincipal as ClaimsPrincipal;
                //HttpContext.User as ClaimsPrincipal;
                this.User as ClaimsPrincipal;

            return View();
        }

        public ActionResult AuthenticatedUsers()
        {
            return View();
        }
    }
}