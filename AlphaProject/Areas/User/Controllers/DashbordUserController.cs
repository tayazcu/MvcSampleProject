using AlphaProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using static AlphaProject.Models.RolesCheckExtensions;

namespace AlphaProject.Areas.User.Controllers
{
    [AuthorizeRoles(Role.User)]
    [ClaimsAccess(Issuer = "OperatorClaim", ClaimType = ClaimTypes.PostalCode, Value = "Product")]
    public class DashbordUserController : Controller
    {
        // GET: User/DashbordUser
        public ActionResult Index()
        {
            return View();
        }
    }
}