using AlphaProject.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using static AlphaProject.Entity.AppUser;

namespace AlphaProject.Data
{
    public class AlphaDbContext : IdentityDbContext<AppUser>
    {
        public AlphaDbContext() : base("AlphaConStr")
        {
            Configuration.LazyLoadingEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            MapEntities(modelBuilder);

            base.OnModelCreating(modelBuilder);

        }
        private static void MapEntities(DbModelBuilder modelBuilder)
        {
             modelBuilder.Configurations.Add(new AppUserConfiguration());
             modelBuilder.Configurations.Add(new ProductConfiguration());
        }
        public static AlphaDbContext Create()
        {
            return new AlphaDbContext();

        }

        public IDbSet<Product> Products { get; set; }
    }
}