using System.Threading.Tasks;
using System.Web;
using Core.Security.Entities;
using Core.Security.Infrastructure;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Core.Security.Models
{
    public class AppUserEdit
    {
        private AppUserManager UserManager
        {
            get { return HttpContext.Current.GetOwinContext().GetUserManager<AppUserManager>(); }
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public async Task<IdentityResult> Upsert(bool forceUpdate = false)
        {
            var user = new AppUser { UserName = Name, Email = Email };
            return await UserManager.CreateAsync(user, Password);
        }
    }
}
