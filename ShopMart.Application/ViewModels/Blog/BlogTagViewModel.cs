using ShopMart.Data.Entities;
using ShopMart.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShopMart.Application.ViewModels.Blog
{
   public class BlogTagViewModel
   
    {
        public int BlogId { set; get; }

        public string TagId { set; get; }

        
    }
}
