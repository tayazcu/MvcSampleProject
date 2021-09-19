using AlphaProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using static AlphaProject.Models.RolesCheckExtensions;

namespace AlphaProject.Areas.Admin.Controllers
{
    [AuthorizeRoles(Role.Admin)]
    public class DashbordAdminController : Controller
    {
        // GET: Admin/Dashbord
        public ActionResult Index()
        {
            return View();
        }
    }
}