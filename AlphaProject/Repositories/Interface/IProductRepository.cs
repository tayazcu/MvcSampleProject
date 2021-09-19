using AlphaProject.Entity;
using AlphaProject.Infrastrature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlphaProject.Repositories.Interface
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetWithLinqSample(int id);
        IEnumerable<Product> GeAllWithLinqSample(string userId, int pageNumber, int pageSize);
    }
}