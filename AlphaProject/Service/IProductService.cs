using AlphaProject.Entity;
using AlphaProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace AlphaProject.Service
{
    public interface IProductService
    {
        int Insert(Product_VM entity);
        Product_VM Get(int id);
    }
}