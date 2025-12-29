using AutoMapper.QueryableExtensions;
using ShopMart.Application.Interfaces;
using ShopMart.Application.ViewModels.Product;
using ShopMart.Data.Entities;
using ShopMart.Data.IRepositores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopMart.Application.Implementation
{
   public class ProductService :IProductService
    {
        IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<ProductViewModel> GetAll()
        {
            return _productRepository.FindAll(x=>x.ProductCategory).ProjectTo<ProductViewModel>().ToList();
        }


    }
}
