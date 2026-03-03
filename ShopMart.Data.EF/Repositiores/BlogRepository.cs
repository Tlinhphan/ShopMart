using ShopMart.Data.Entities;
using ShopMart.Data.IRepositores;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMart.Data.EF.Repositiores
{
       public class BlogRepository : EFRepository<Blog, int>, IBlogRepository
        {
            public BlogRepository(AppDbContext context) : base(context)
            {

            }
        }
}
