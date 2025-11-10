using ShopMart.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMart.Data.Interfaces
{
   public interface ISwitchable
    {
        Status Status { set; get; }
    }
}
