using AlphaProject.Data;
using AlphaProject.Entity;
using AlphaProject.Infrastrature;
using AlphaProject.UnitOfWork;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlphaProject.Service.AppUserService
{
    public class AppUserService : IAppUserService
    {
        private AppUserManager _userManager => HttpContext.Current.GetOwinContext().GetUserManager<AppUserManager>();
        private AppRoleManager _roleManager => HttpContext.Current.GetOwinContext().GetUserManager<AppRoleManager>();
        private IAuthenticationManager _authManager => HttpContext.Current.GetOwinContext().Authentication;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<AlphaDbContext> _unitOfWork;
        public AppUserService(IMapper mapper, IUnitOfWork<AlphaDbContext> unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public AppUser GetUserAccessByUserAndPass(string username, string password)
        {
            AppUser user = _userManager.Find(username.ToLower(), password.ToLower());
            return user;
        }
    }
}