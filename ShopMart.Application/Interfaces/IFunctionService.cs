using ShopMart.Application.ViewModels.Sytsem;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopMart.Application.Interfaces
{
   public interface IFunctionService: IDisposable
    {
       Task<List<FunctionViewModel>> GetAll();

        List<FunctionViewModel> GetAllByPermission(Guid userId);
    }
}
