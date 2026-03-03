using Microsoft.AspNetCore.Mvc;
using ShopMart.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMart.Controllers.Components
{
    public class MainMenuViewComponent : ViewComponent
    {
        private IProductCategoryService _productCategoryService;

        public MainMenuViewComponent(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = _productCategoryService.GetAll();
            return View(model);
        }
    }
}
