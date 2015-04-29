using System.Threading.Tasks;
using ContosoUniversity.Users.Models;
using Microsoft.AspNet.Identity;

namespace ContosoUniversity.Users.Infra
{
    public class CustomUserValidator : UserValidator<AppUser>
    {
        public CustomUserValidator(UserManager<AppUser, string> manager)
            : base(manager)
        {
            AllowOnlyAlphanumericUserNames = true;
        }

        public override Task<IdentityResult> ValidateAsync(AppUser item)
        {
            return base.ValidateAsync(item);
        }
    }
}