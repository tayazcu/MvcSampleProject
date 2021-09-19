using AlphaProject.Entity;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AlphaProject.Infrastrature
{
    public class CustomUserValidator : UserValidator<AppUser>
    {
        public CustomUserValidator(AppUserManager mgr) : base(mgr)
        {

        }
        public override async Task<IdentityResult> ValidateAsync(AppUser user)
        {
            IdentityResult result = await base.ValidateAsync(user);
            //if (!user.Email.ToLower().EndsWith("@a.com"))
            //{
            //    var errors = result.Errors.ToList();
            //    errors.Add("error user name");
            //    result = new IdentityResult(errors);
            //}
            return result;
        }
    }
}