using AspNetIdentityServerGettingStarted.Data.Model;
using System.Data.Entity;

namespace AspNetIdentityServerGettingStarted.Data
{
    public interface IAspNetIdentityServerGettingStartedDataContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Scope> Scopes { get; set; }
        DbSet<Client> Clients { get; set; }
        int SaveChanges();
    }

    public class AspNetIdentityServerGettingStartedDataContext: DbContext, IAspNetIdentityServerGettingStartedDataContext
    {
        public AspNetIdentityServerGettingStartedDataContext()
            :base(nameOrConnectionString: "AspNetIdentityServerGettingStartedDataContext")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.AutoDetectChangesEnabled = true;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Scope> Scopes { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}