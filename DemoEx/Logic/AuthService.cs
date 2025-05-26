using System.Data.Entity;
using System.Linq;
using DemoEx.DBmodel;
using DemoEx.Services;

namespace DemoEx.Logic
{
    public class AuthService : IAuthService
    {
        private readonly DEMOdemoEntities dbContext;

        public AuthService()
        {
            dbContext = new DEMOdemoEntities();
        }

        public Users Authenticate(string login, string pass)
        {
            return dbContext.Users.Include("Roles")
                                  .FirstOrDefault(u => u.Login == login && u.Pass == pass);
        }
    }
}
