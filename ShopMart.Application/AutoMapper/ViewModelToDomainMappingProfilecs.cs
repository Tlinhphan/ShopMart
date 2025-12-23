using AutoMapper;
using ShopMart.Application.ViewModels.Product;
using ShopMart.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMart.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfilecs : Profile
    {
        public ViewModelToDomainMappingProfilecs()

        {
            CreateMap<ProductCategoryViewModel, ProductCategory>()
                .ConstructUsing(c => new ProductCategory(c.Name,c.Description,c.ParentId,c.HomeOrder,c.Image,c.HomeFlag,
                c.SortOrder,c.Status,c.SeoPageTitle,c.SeoKeywords,c.SeoAlias,c.SeoDescription));
        }
    }
}
