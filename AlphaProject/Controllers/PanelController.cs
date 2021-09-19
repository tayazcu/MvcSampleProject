using AlphaProject.Entity;
using AlphaProject.Infrastrature;
using AlphaProject.Models;
using AlphaProject.Service.AppUserService;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AlphaProject.Controllers
{
    public class PanelController : Controller
    {
        #region ################################# Const And Values #################################
        private readonly IAppUserService _appUserService;
        private AppUserManager UserManager => HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
        private IAuthenticationManager AuthManager => HttpContext.GetOwinContext().Authentication;

        public PanelController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        #endregion

        #region ###################################### Index #######################################
        public ActionResult Index(string msg = "")
        {
            if (msg != "")
            {
                if (msg == "-1")
                    ViewBag.ErrorMSG = "نام کاربری یا کلمه عبور صحیح نمیباشد";
                ViewBag.ErrorType = "0";
            }
            return View();
        }
        #endregion

        #region #################################### Operation ##################################### 

        [HttpPost]
        public async Task<ActionResult> Login(AccountModel model)
        {
            try
            {
                AppUser userIdentity = _appUserService.GetUserAccessByUserAndPass(model.Username, model.Password);
                if (userIdentity == null && userIdentity.status == AppUser.StatusUser.Active && userIdentity.type == AppUser.TypeUser.Admin)
                {
                    ClaimsIdentity ident = await UserManager.CreateIdentityAsync(userIdentity, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthManager.SignOut();
                    AuthManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = false
                    }, ident);
                    return RedirectToAction("Index", "DashbordAdmin", new { area = "Admin" });
                }
                else if (userIdentity == null && userIdentity.status == AppUser.StatusUser.Active && userIdentity.type == AppUser.TypeUser.User)
                {
                    ClaimsIdentity ident = await UserManager.CreateIdentityAsync(userIdentity, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthManager.SignOut();
                    AuthManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = false
                    }, ident);
                    return RedirectToAction("Index", "DashbordUser", new { area = "User" });
                }
                else if (true)
                {
                    return RedirectToAction("Index", new { msg = "-1" });
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", new { msg = "-1" });
            }
        }

        #endregion
    }
}