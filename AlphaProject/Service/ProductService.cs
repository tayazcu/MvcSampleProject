using AlphaProject.Data;
using AlphaProject.Entity;
using AlphaProject.UnitOfWork;
using AlphaProject.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace AlphaProject.Service
{
    public class ProductService: IProductService
    {
        private readonly IUnitOfWork<AlphaDbContext> _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork<AlphaDbContext> unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Product_VM Get(int id)
        {
            Product model = _unitOfWork.ProductRepository.GetById(id);

            if (model != null)
            {
                Product_VM viewModel = _mapper.Map<Product, Product_VM>(model);
                return viewModel;
            }

            return null;
        }
        public int Insert(Product_VM entity)
        {
            int result = 0;
            if (entity == null) throw new ArgumentNullException("entity");
            Product model = _mapper.Map<Product_VM, Product>(entity);
            _unitOfWork.ProductRepository.Insert(model);
            int success =  _unitOfWork.Commit();
            if (success > 0)
            {
                result = 1;
            }
            else
            {
                result = -1;
            }
            return result;
        }
    }
}