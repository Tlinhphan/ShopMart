using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopMart.Application.Interfaces;
using ShopMart.Extensions;
using ShopMart.Models;

namespace ShopMart.Controllers
{

    public class HomeController : Controller
    {
        private IProductService _productSer;
        private IProductCategoryService _productCategorySer;
        private IBlogService _blogSer;
        private ICommonService _commonSer;

        public HomeController(
                    IProductService productSer,
                    IBlogService blogSer,
                    ICommonService commonSer,
                    IProductCategoryService productCategorySer
                )
        {
            _blogSer = blogSer;
            _commonSer = commonSer;
            _productSer = productSer;
            _productCategorySer= productCategorySer;
        }

        public IActionResult Index()
        {
            ViewData["BodyClass"] = "cms-index-index cms-home-page";
            var homeVm = new HomeViewModel();
            homeVm.HomeCategories = _productCategorySer.GetHomeCategories(5);
            homeVm.HotProducts = _productSer.GetHotProduct(5);
            homeVm.TopSellProducts = _productSer.GetLastest(5);
            homeVm.LastestBlogs = _blogSer.GetLastest(5);
            homeVm.HomeSlides = _commonSer.GetSlides("top");
            return View(homeVm);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
