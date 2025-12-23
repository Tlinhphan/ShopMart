using Microsoft.AspNetCore.Mvc;
using ShopMart.Application.Interfaces;
using ShopMart.Application.ViewModels.Sytsem;
using ShopMart.Extensions;
using ShopMart.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShopMart.Areas.Admin.Components
{

    public class SideBarViewComponent : ViewComponent
    {
        IFunctionService _functionService;
        public  SideBarViewComponent(IFunctionService functionService)
        {
            _functionService = functionService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var roles = ((ClaimsPrincipal)User).GetSpecificClaim("Roles");

            List<FunctionViewModel> functions; 

            if (roles.Split(";").Contains(CommonConstants.AdminRole))
            {
                functions = await _functionService.GetAll();
            }

            else

            {
                //TODO: Get by permission
                functions = new List<FunctionViewModel>();
            }
            return View(functions);
        }
    }
}
