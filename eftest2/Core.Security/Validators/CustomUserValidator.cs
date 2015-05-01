using Core.Security.Entities;
using Microsoft.AspNet.Identity;

namespace Core.Security.Validators
{
    public class CustomUserValidator : UserValidator<AppUser>
    {
        public CustomUserValidator(UserManager<AppUser, string> manager)
            : base(manager)
        {
            AllowOnlyAlphanumericUserNames = true;
        }
    }
}