using ShopMart.Data.Entities;
using ShopMart.Data.IRepositores;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMart.Data.EF.Repositiores
{
   public class FunctionRepository: EFRepository<Function,string>, IFunctionRepository
    {
        public FunctionRepository(AppDbContext context): base(context)
        {

        }
    }
}
