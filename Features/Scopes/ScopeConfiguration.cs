using System.Data.Entity.Migrations;
using AspNetIdentityServerGettingStarted.Data;

namespace AspNetIdentityServerGettingStarted.Features.Scopes
{
    public class ScopeConfiguration
    {
        public static void Seed(AspNetIdentityServerGettingStartedDataContext context) {

            context.SaveChanges();
        }
    }
}
