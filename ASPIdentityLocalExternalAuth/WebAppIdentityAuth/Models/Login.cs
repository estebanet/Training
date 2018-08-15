using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppIdentityAuth.Models
{
    public class Login
    {
        public string UserIdentifier { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}