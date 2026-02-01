using ShopMart.Application.ViewModels.Sytsem;
using ShopMart.Data.Entities;
using ShopMart.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShopMart.Application.ViewModels.Product
{
   public class BillDetailViewModel
    {
        public int Id { set; get; }

        public int BillId { set; get; }

        public int ProductId { set; get; }

        public int Quantity { set; get; }

        public decimal Price { set; get; }

        public int ColorId { get; set; }

        public int SizeId { get; set; }
        
        public virtual BillViewModel Bill { set; get; }


        public virtual ProductViewModel Product { set; get; }

        public virtual ColorViewModel Color { set; get; }

    
        public virtual SizeViewModel Size { set; get; }
    }
}
