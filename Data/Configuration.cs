using AspNetIdentityServerGettingStarted.Data;
using AspNetIdentityServerGettingStarted.Features.Users;
using System.Data.Entity.Migrations;

namespace AspNetIdentityServerGettingStarted.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<AspNetIdentityServerGettingStartedDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AspNetIdentityServerGettingStartedDataContext context)
        {
            UserConfiguration.Seed(context);
        }
    }

}