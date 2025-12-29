using ShopMart.Application.ViewModels.Product;
using ShopMart.Application.ViewModels.Sytsem;
using ShopMart.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopMart.Application.Interfaces
{
   public interface IProductService :IDisposable
    {
        List<ProductViewModel> GetAll();
    }
}
