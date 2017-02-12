using System.Collections.Generic;

namespace AspNetIdentityServerGettingStarted.Data.Model
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
