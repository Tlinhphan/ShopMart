using ShopMart.Data.Entities;
using ShopMart.Data.IRepositores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ShopMart.Data.EF.Repositiores
{
  
        public class BlogTagRepository : EFRepository<BlogTag, int>, IBlogTagRepository
        {
            public BlogTagRepository(AppDbContext context) : base(context)
            {
            }
        }
    }
