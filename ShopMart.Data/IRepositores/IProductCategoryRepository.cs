using ShopMart.Data.Entities;
using ShopMart.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMart.Data.IRepositores
{
    public interface IProductCategoryRepository : IRepository<ProductCategory, int>
    {
        List<ProductCategory> GetByAlias(string alias);
    }
}
