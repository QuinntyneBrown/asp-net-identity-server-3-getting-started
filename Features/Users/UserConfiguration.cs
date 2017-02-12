using System.Data.Entity.Migrations;
using AspNetIdentityServerGettingStarted.Data.Model;
using AspNetIdentityServerGettingStarted.Data;

namespace AspNetIdentityServerGettingStarted.Features.Users
{
    public class UserConfiguration
    {
        public static void Seed(AspNetIdentityServerGettingStartedDataContext context) {

            context.SaveChanges();
        }
    }
}
