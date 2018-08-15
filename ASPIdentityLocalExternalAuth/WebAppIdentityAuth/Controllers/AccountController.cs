using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebAppIdentityAuth.Controllers
{
    public class AccountController : Controller
    {
        public IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(Models.Login login, string urlPrev)
        {
            ActionResult Result;
            Authentication.AppsUserManager UsersManager = new Authentication.AppsUserManager();

            bool UserAuth = await UsersManager.ValidateUserAsync(login.UserIdentifier, login.Password);

            if (UserAuth)
            {
                Result = SignInUser(await UsersManager.GetUserByIdentifierAsync(login.UserIdentifier),
                    login.RememberMe, urlPrev);
            }
            else
            {
                ViewBag.IsFailValidation = "true";
                Result = View(login);
            }

            return Result;
        }

        [HttpGet]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            return RedirectToAction("Login", controllerName: "Account");
        }

        private ActionResult SignInUser(User login, bool remember, string returnUrl)
        {
            ActionResult Result;
            List<Claim> UserClaims = new List<Claim>();
            ClaimsIdentity UserClaimsIdentity;

            UserClaims.Add(new Claim(ClaimTypes.NameIdentifier, login.UserIdentifier));
            UserClaims.Add(new Claim(ClaimTypes.Name, login.Profile.Name));
            UserClaims.Add(new Claim("FullName", $"{login.Profile.Name} {login.Profile.FirstName}"));
            UserClaims.Add(new Claim(ClaimTypes.StreetAddress, login.Profile.Address));

            if(login.Roles.Count > 0)
            {
                UserClaims.AddRange(
                    login.Roles.Select(role => new Claim(ClaimTypes.Role, role.Name)));
            }

            UserClaimsIdentity = new ClaimsIdentity(UserClaims, DefaultAuthenticationTypes.ApplicationCookie);
            Microsoft.Owin.Security.IAuthenticationManager AuthManager = AuthenticationManager;
            AuthManager.SignIn(new Microsoft.Owin.Security.AuthenticationProperties
            {
                IsPersistent = remember
            }, UserClaimsIdentity);

            if (!string.IsNullOrEmpty(returnUrl))
            {
                Result = Redirect(returnUrl);
            }
            else
            {
                Result = RedirectToAction(actionName: "Index", controllerName: "Home");
            }

            return Result;
        }
    }
}