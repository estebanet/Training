using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AppsUserRepository
    {
        public async Task<EntityFramework.User> FindUserAsync(string userIdentifier,
            bool getInfo = false)
        {
            EntityFramework.User User;

            try
            {
                using (EntityFramework.WebApp1EFMContainer DbContex =
                    new EntityFramework.WebApp1EFMContainer())
                {
                    User = await DbContex.Users.FindAsync(userIdentifier);
                    if (User == null)
                    {
                        User = new EntityFramework.User();
                    }

                    if (getInfo)
                    {
                        //Para forzar la recuperación de entidades de propiedades de navegación.
                        string TempString =
                            User.Profile.UserIdentifier.ToString();
                        TempString = string.Join(",", User.Roles.Select(Rol => Rol.Name));
                    }
                }
            }
            catch(Exception ex)
            {
                User = null;
                System.Diagnostics.Debug.WriteLine("Se ha generado una excepción durante la ejecución del método FindUserAsync;" +
                    $"Error: {ex.Message}");
            }

            return User;
        }

        public async Task<bool> ValidateUserAsync(string userIdentifier, string password)
        {
            var User = await FindUserAsync(userIdentifier);

            return string.Equals(User?.Password, password);
        }
    }
}
