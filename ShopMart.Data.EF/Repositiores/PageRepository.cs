using ShopMart.Data.Entities;
using ShopMart.Data.IRepositores;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMart.Data.EF.Repositiores
{
    public class PageRepository : EFRepository<Page, int>, IPageRepository
    {
        public PageRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}

