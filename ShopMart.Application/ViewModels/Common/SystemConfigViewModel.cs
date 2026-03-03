using ShopMart.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMart.Application.ViewModels.Blog
{
   public class SystemConfigViewModel
    {
        public string Id { set; get; }
        public string Name { get; set; }
        public string Value1 { get; set; }
        public int? Value2 { get; set; }
        public bool? Value3 { get; set; }
        public DateTime? Value4 { get; set; }
        public decimal? Value5 { get; set; }
        public Status status { get; set; }
    }
}
