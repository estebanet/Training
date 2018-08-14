using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication
{
    public class AppsUserManager
    {
        private Models.AppsUserRepository Repository
        {
            get
            {
                return new Models.AppsUserRepository();
            }
        }

        public async Task<bool> ValidateUserAsync(string userIdentifier, string password)
        {   
            return await Repository.ValidateUserAsync(userIdentifier, password);
        }

        public async Task<Models.EntityFramework.User> GetUserByIdentifierAsync(string userIndetifier)
        {
            return await Repository.FindUserAsync(userIndetifier, true);
        }
    }
}
