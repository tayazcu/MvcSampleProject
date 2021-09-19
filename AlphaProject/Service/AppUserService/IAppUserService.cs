using AlphaProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlphaProject.Service.AppUserService
{
    public interface IAppUserService
    {
        AppUser GetUserAccessByUserAndPass(string username, string password);
    }
}