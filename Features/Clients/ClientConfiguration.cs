using System.Data.Entity.Migrations;
using AspNetIdentityServerGettingStarted.Data;

namespace AspNetIdentityServerGettingStarted.Features.Clients
{
    public class ClientConfiguration
    {
        public static void Seed(AspNetIdentityServerGettingStartedDataContext context) {

            context.SaveChanges();
        }
    }
}
