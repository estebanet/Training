using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppIdentityAuth.Models.Helpers
{
    public class ChallengeResult: HttpUnauthorizedResult
    {
        private string UserId { get; set; }
        private string RedirectUri { get; set; }
        private string ExternalProvider { get; set; }
        public static string CsrfKey { get; } = "XsrfId";

        public ChallengeResult(string userId, string redirectUri, string provider)
        {
            ExternalProvider = provider;
            UserId = userId;
            RedirectUri = redirectUri;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            AuthenticationProperties AuthProperties = new AuthenticationProperties();

            AuthProperties.Dictionary[CsrfKey] = UserId;
            AuthProperties.RedirectUri = RedirectUri;

            context.HttpContext.GetOwinContext().Authentication
                .Challenge(AuthProperties, ExternalProvider);
        }
    }
}