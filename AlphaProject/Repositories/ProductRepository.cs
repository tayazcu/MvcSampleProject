using AlphaProject.Data;
using AlphaProject.Entity;
using AlphaProject.Infrastrature;
using AlphaProject.Repositories.Interface;
using AlphaProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AlphaProject.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        private readonly AlphaDbContext _dbContext;
        public ProductRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = (_dbContext ?? (AlphaDbContext)dbContext);
        }

        public Product GetWithLinqSample(int id)
        {
            IQueryable<Product> product = (from p in _dbContext.Products
                                           where p.id == id
                                           select p);

            return product.SingleOrDefault();
        }
        public IEnumerable<Product> GeAllWithLinqSample(string userId , int pageNumber , int pageSize)
        {
            IQueryable<Product> product = (from p in _dbContext.Products
                                           where p.UserID == userId
                                           select p);

            return product.
                OrderByDescending(b => b.id).
                Skip((pageNumber - 1) * pageSize).
                Take(pageSize).ToList();
        }

    }
}