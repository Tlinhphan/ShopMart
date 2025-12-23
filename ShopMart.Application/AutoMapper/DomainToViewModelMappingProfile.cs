using AutoMapper;
using ShopMart.Application.ViewModels.Product;
using ShopMart.Application.ViewModels.Sytsem;
using ShopMart.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMart.Application.AutoMapper
{
   public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ProductCategory, ProductCategoryViewModel>();

            CreateMap<Function, FunctionViewModel>();
        }
    }
}
