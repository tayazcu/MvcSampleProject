using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlphaProject.Models
{
    public static class RolesCheckExtensions
    {
        public static class Role
        {
            public const string Admin = "Admin";
            public const string User = "User";
        }
        public class AuthorizeRolesAttribute : AuthorizeAttribute
        {
            public AuthorizeRolesAttribute(params string[] roles) : base()
            {
                Roles = string.Join(",", roles);
            }
        }
    }
}