using ShopMart.Data.Entities;
using ShopMart.Data.IRepositores;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMart.Data.EF.Repositiores
{
   public class SizeRepository : EFRepository<Size, int>, ISizeRepository
    {
        public SizeRepository(AppDbContext context) : base(context)
        {

        }
    }
}
