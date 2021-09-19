using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace AlphaProject.Models
{
    public class ClaimsAccessAttribute : AuthorizeAttribute
    {
        public string Issuer { get; set; }
        public string ClaimType { get; set; }
        public string Value { get; set; }
        protected override bool AuthorizeCore(HttpContextBase context)
        {
            bool IsAdmin = HttpContext.Current.GetOwinContext().Authentication.User.IsInRole("Admin");
            if (IsAdmin)
                return true;

            bool result = context.User.Identity.IsAuthenticated && context.User.Identity is ClaimsIdentity &&
                ((ClaimsIdentity)context.User.Identity).HasClaim(x => x.Type == Issuer && x.Value == Value);

            return result;
        }
    }

    public class ClaimsAccessManyClaimAttribute : AuthorizeAttribute
    {
        public string Issuer { get; set; }
        public string ClaimType { get; set; }
        public string[] Values { get; set; }
        protected override bool AuthorizeCore(HttpContextBase context)
        {
            bool IsAdmin = HttpContext.Current.GetOwinContext().Authentication.User.IsInRole("Admin");
            if (IsAdmin)
                return true;

            bool result = false;

            foreach (string item in Values)
            {
                //if (item.IsNullOrEmpty())
                //{
                    bool resultOneClaim = context.User.Identity.IsAuthenticated && context.User.Identity is ClaimsIdentity &&
                     ((ClaimsIdentity)context.User.Identity).HasClaim(x => x.Type == Issuer && x.Value == item);
                    if (resultOneClaim)
                    {
                        result = true;
                        break;
                    }
                //}
            }

            return result;
        }
    }
}