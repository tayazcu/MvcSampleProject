using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace AlphaProject.Entity
{
    public class Product 
    {
        public int id { get; set; }
        public string name { get; set; }
        public int count { get; set; }
        public int price { get; set; }
        public string group { get; set; }
        public Status status { get; set; }

        public string UserID { get; set; }
        public virtual ICollection<AppUser> AppUsers { get; set; }
    }
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            Property(field => field.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasKey(field => field.id);

            Property(field => field.name).
                         HasMaxLength(3900).
                         IsRequired().
                         HasColumnType("nvarchar").
                         IsUnicode();

        }
    }
    public enum Status
    {
        [Display(Name = "تایید شده")]
        Active = 1,

        [Display(Name = "تایید نشده")]
        Inactive = 2,

        [Display(Name = "در حال بررسی")]
        Pending = 3
    }
}