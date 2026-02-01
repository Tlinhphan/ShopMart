using ShopMart.Data.Entities;
using ShopMart.Data.IRepositores;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMart.Data.EF.Repositiores
{
   public class BillDetailRepository : EFRepository<BillDetail, int>, IBillDetailRepository
    {
        public BillDetailRepository(AppDbContext context) : base(context)
        {

        }
    }
}
