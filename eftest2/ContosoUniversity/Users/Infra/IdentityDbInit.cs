using System.Data.Entity;

namespace ContosoUniversity.Users.Infra
{
    public class IdentityDbInit : DropCreateDatabaseIfModelChanges<AppIdentityDbContext>
    {
        protected override void Seed(AppIdentityDbContext context)
        {

            base.Seed(context);
        }
    }
}