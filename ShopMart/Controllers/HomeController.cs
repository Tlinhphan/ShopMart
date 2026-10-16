using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
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
        private readonly IStringLocalizer<HomeController> _localizer;

        public HomeController(
                    IProductService productSer,
                    IBlogService blogSer,
                    ICommonService commonSer,
                    IProductCategoryService productCategorySer,
                    IStringLocalizer<HomeController> localizer
                )
        {
            _blogSer = blogSer;
            _commonSer = commonSer;
            _productSer = productSer;
            _productCategorySer= productCategorySer;
            _localizer = localizer;
        }

        [ResponseCache(CacheProfileName = "Default")]
        public IActionResult Index()
        {
            var title = _localizer["Title"];
            var culture = HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.Culture.Name;
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

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
    }
}
