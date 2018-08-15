using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace WebAppIdentityAuth.Models.Filters
{
    public class AuthAttribute: System.Web.Mvc.AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool Auth = base.AuthorizeCore(httpContext);

            ClaimsPrincipal Principal = httpContext.User as ClaimsPrincipal;
            string url = string.Join("", httpContext.Request.Path.Skip(1));
            string[] urlSegments = url.Split(new char[] { '/' }, StringSplitOptions.None);
            string controller = urlSegments[0], 
                action = urlSegments.Length > 1? 
                    urlSegments[1].Substring(0, urlSegments[1].IndexOf('?') > -1? urlSegments[1].IndexOf('?'): urlSegments[1].Length): string.Empty;

            return Auth && AuthorizePerActionController(action, controller, Principal);
        }

        private bool AuthorizePerActionController(string action, string controller,
            ClaimsPrincipal principal)
        {
            bool validate = true;

            if (string.IsNullOrEmpty(controller))
            {
                controller = "Home";
            }

            if (string.IsNullOrEmpty(action))
            {
                action = "Index";
            }

            if (controller.ToLower() == "home")
            {
                if (action.ToLower() == "authenticatedusers")
                {
                    validate = principal.IsInRole("Admin");
                }
            }

            return validate;
        }
    }
}