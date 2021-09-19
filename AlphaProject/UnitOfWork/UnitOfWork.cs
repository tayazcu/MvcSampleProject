using AlphaProject.Infrastrature;
using AlphaProject.Repositories;
using AlphaProject.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AlphaProject.UnitOfWork
{
    public class UnitOfWork<TContext> : Disposable, IUnitOfWork<TContext> where TContext : DbContext, new()
    {
        #region Commit
        public virtual int Commit()
        {
            return _dataContext.SaveChanges();
        }
        public virtual Task<int> CommitAsync()
        {
            return _dataContext.SaveChangesAsync();
        }
        #endregion
        #region Consteractor
        private readonly DbContext _dataContext;
        public UnitOfWork()
        {
            _dataContext = new TContext();
        }
        protected override void DisposeCore()
        {
            if (_dataContext != null)
                _dataContext.Dispose();
        }
        #endregion
        #region ####################### Define Repositories Product #######################
        /// <summary>
        /// Define Variable Product
        /// </summary>
        private IProductRepository _productRepository;

        /// <summary>
        /// Define Repositories Product
        /// </summary>
        public IProductRepository ProductRepository
        {
            get { return _productRepository ?? (_productRepository = new ProductRepository(_dataContext)); }
        }
        #endregion
    }
}