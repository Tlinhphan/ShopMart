using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMart.ViewComponents
{
    public class PagerViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(object model)
        {
            return View(model);
        }
    
    }
}
