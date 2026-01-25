using ShopMart.Application.ViewModels.Product;
using ShopMart.Application.ViewModels.Sytsem;
using ShopMart.Data.Entities;
using ShopMart.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopMart.Application.Interfaces
{
   public interface IProductService :IDisposable
    {
        List<ProductViewModel> GetAll();

        PagedResult<ProductViewModel> GetAllPaging(int? categoryId, string keyword, int page, int pageSize);

        ProductViewModel Add(ProductViewModel product);

        void Update(ProductViewModel product);

        void Delete(int id);

        ProductViewModel GetById(int Id);

        void ImportExcel(string filePath, int categoryId);

        void Save();
    }
}
