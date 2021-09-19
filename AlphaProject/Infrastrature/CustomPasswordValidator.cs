﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AlphaProject.Infrastrature
{
    public class CustomPasswordValidator : PasswordValidator
    {
        public override async Task<IdentityResult> ValidateAsync(string pass)
        {
            IdentityResult result = await base.ValidateAsync(pass);

            //if (pass.Contains("123456"))
            //{
            //    var errors = result.Errors.ToList();
            //    errors.Add("password cannot contains 123456");
            //    result = new IdentityResult(errors);
            //}
            return result;

        }
    }
}