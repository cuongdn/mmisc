using Core.Security.Entities;
using Core.Security.Validators;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Core.Security.Infrastructure
{
    public class AppUserManager : UserManager<AppUser>
    {
        public AppUserManager(IUserStore<AppUser> store)
            : base(store)
        {

        }

        public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
        {
            var db = context.Get<IdentityDataContext>();
            var manager = new AppUserManager(new UserStore<AppUser>(db));
            manager.UserValidator = new CustomUserValidator(manager);
            return manager;
        }
    }
}