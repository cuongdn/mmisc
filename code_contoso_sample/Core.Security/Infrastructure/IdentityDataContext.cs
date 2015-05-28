using System.Data.Entity;
using Core.Security.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Core.Security.Infrastructure
{
    public class IdentityDataContext : IdentityDbContext<AppUser>
    {
        public IdentityDataContext()
            : base("IdentityDb")
        {
        }

        static IdentityDataContext()
        {
            Database.SetInitializer(new NullDatabaseInitializer<IdentityDataContext>());
        }

        public static IdentityDataContext Create()
        {
            return new IdentityDataContext();
        }
    }
}