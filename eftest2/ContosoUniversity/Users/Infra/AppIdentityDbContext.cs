using System.Data.Entity;
using ContosoUniversity.Users.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ContosoUniversity.Users.Infra
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext()
            : base("IdentityDb")
        {
        }

        static AppIdentityDbContext()
        {
            Database.SetInitializer(new IdentityDbInit());
        }

        public static AppIdentityDbContext Create()
        {
            return new AppIdentityDbContext();
        }
    }
}