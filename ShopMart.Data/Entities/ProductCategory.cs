using ShopMart.Data.Enums;
using ShopMart.Data.Interfaces;
using ShopMart.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMart.Data.Entities
{
    public class ProductCategory : DomainEntity<int>, IHasSeoMetaData, ISortable, ISwitchable, IDateTracking
    {
        public ProductCategory()
        {
            Products = new List<Product>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public int? ParentId { get; set; }

        public int? HomeOrder { get; set; }

        public string Image { get; set; }

        public bool? HomeFlag { get; set; }

        public string SeoPageTitle { get; set; }

        public string SeoAlias { get; set; }

        public string SeoKeywords { get; set ; }

        public string SeoDescription { get; set; }

        public int SortOrder { get; set; }

        public Status Status { get ; set; }

        public DateTime DateCreated { get ; set ; }

        public DateTime DateModified { get; set ; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
