using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace AlphaProject.Entity
{
    public class AppUser : IdentityUser
    {
        public AppUser()
            : base()
        {
           
        }

        public string MelliCode { get; set; }
        public string Mobile { get; set; }
        public string FlName { get; set; }
        public TypeUser type { get; set; }
        public StatusUser status { get; set; }
        public virtual Product Products { get; set; }

        public class AppUserConfiguration : EntityTypeConfiguration<AppUser>
        {
            public AppUserConfiguration()
            {

            }
        }
        public enum TypeUser
        {
            Admin = 1,
            User = 2,
        }
        public enum StatusUser
        {
            [Display(Name = "تایید شده")]
            Active = 1,

            [Display(Name = "تایید نشده")]
            Inactive = 2,

            [Display(Name = "در حال بررسی")]
            Pending = 3
        }
    }
}