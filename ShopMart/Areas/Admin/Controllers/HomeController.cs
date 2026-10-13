using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopMart.Extensions;
using ShopMart.Application.Interfaces;
using ShopMart.Application.Dapper.Interface;

namespace ShopMart.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IReportService _reportService;

        public HomeController(IReportService reportService)
        {
            _reportService = reportService;
        }

        public IActionResult Index()
        {
            var email = User.GetSpecificClaim("Email");

            return View();
        }

        public async Task<IActionResult> GetRevenue(string fromDate, string toDate)
        {
            return new OkObjectResult(await _reportService.GetReportAsync(fromDate, toDate));
        }
    }
}