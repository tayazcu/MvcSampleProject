namespace AlphaProject.Migrations
{
    using AlphaProject.Entity;
    using AlphaProject.Infrastrature;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Claims;
    using static AlphaProject.Entity.AppUser;

    internal sealed class Configuration : DbMigrationsConfiguration<AlphaProject.Data.AlphaDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AlphaProject.Data.AlphaDbContext context)
        {
            

            //if (!context.Products.Any())
            //{
            //    AppUserManager userMgr = new AppUserManager(new UserStore<AppUser>(context));
            //    AppRoleManager roleMgr = new AppRoleManager(new RoleStore<AppRole>(context));
            //    #region admin fill
            //    string userNameAdmin = "admin";
            //    string roleNameAdmin = "Admin";
            //    string passwordAdmin = "admin";
            //    #region fill user
            //    AppUser admin = new AppUser
            //    {
            //        FlName = "علی نقوی مدیر",
            //        Email = "mad.naghavi@gmail.com",
            //        UserName = userNameAdmin,
            //        type = TypeUser.Admin,
            //        status = StatusUser.Active,
            //        Mobile = "09131062435",
            //        MelliCode = "119004012",
            //    };
            //    #endregion
            //    IdentityResult resultIdentity_Admin = userMgr.Create(admin, passwordAdmin);
            //    if (resultIdentity_Admin.Succeeded)
            //    {
            //        #region add role and claim
            //        if (!roleMgr.RoleExists(roleNameAdmin))
            //        {
            //            roleMgr.Create(new AppRole(roleNameAdmin));
            //        }
            //        if (!userMgr.IsInRole(admin.Id, roleNameAdmin))
            //        {
            //            userMgr.AddToRole(admin.Id, roleNameAdmin);
            //        }
            //        #endregion
            //    }
            //    #endregion
            //    #region user fill
            //    string userNameUser = "user";
            //    string roleNameUser = "User";
            //    string passwordUser = "user";
            //    #region fill user
            //    AppUser user = new AppUser
            //    {
            //        FlName = "علی نقوی کاربر",
            //        Email = "mad.naghavi@gmail.com",
            //        UserName = userNameUser,
            //        type = TypeUser.User,
            //        status = StatusUser.Active,
            //        Mobile = "09131062435",
            //        MelliCode = "1190040188",
            //    };
            //    #endregion
            //    IdentityResult resultIdentity_User = userMgr.Create(user, passwordUser);
            //    if (resultIdentity_User.Succeeded)
            //    {
            //        #region add role and claim
            //        if (!roleMgr.RoleExists(roleNameUser))
            //        {
            //            roleMgr.Create(new AppRole(roleNameUser));
            //        }
            //        if (!userMgr.IsInRole(user.Id, roleNameUser))
            //        {
            //            userMgr.AddToRole(user.Id, roleNameUser);
            //        }

            //        string[] claims = new string[]
            //            {
            //            "Product",
            //            };
            //        foreach (string item in claims)
            //        {
            //            Claim claimToAdd = new Claim("OperatorClaim", item);
            //            IdentityResult result2 = userMgr.AddClaim(user.Id, claimToAdd);
            //        }
            //        #endregion
            //    }
            //    #endregion
            //    #region Fill Product
            //    // user
            //    for (int i = 0; i <= 10; i++)
            //    {
            //        context.Products.AddOrUpdate(a => a.id, new Product()
            //        {
            //            count = 10,
            //            name = $"محصول شماره {i}",
            //            price = 100000,
            //            status = Status.Active,
            //            UserID = user.Id,
            //            group = $"گروه شماره {i}"
            //        });
            //    }

            //    // admin
            //    for (int i = 0; i <= 10; i++)
            //    {
            //        context.Products.AddOrUpdate(a => a.id, new Product()
            //        {
            //            count = 10,
            //            name = $"محصول شماره {i}",
            //            price = 100000,
            //            status = Status.Active,
            //            UserID = admin.Id,
            //            group = $"گروه شماره {i}"
            //        });
            //    }
            //    #endregion
            //}



        }
    }
}
