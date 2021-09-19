using AlphaProject.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AlphaProject.UnitOfWork
{
    public interface IUnitOfWork<U> where U : DbContext, IDisposable
    {
        int Commit();
        Task<int> CommitAsync();

        // <summary>
        // Repository intefaces
        // </summary>

        IProductRepository ProductRepository { get; }
    }
}