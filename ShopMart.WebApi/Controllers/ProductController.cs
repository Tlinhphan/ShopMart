using Microsoft.AspNetCore.Mvc;
using ShopMart.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMart.WebApi.Controllers
{
    public class ProductController : ApiController
    {
        IProductCategoryService _productCategoryService;
        public ProductController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(_productCategoryService.GetAll());
        }

    }
}
