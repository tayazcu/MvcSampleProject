using AlphaProject.Entity;
using AlphaProject.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlphaProject
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, Product_VM>();
            CreateMap<Product_VM, Product>();
        }
    }
}