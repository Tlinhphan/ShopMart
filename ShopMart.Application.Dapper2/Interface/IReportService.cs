using ShopMart.Application.Dapper.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopMart.Application.Dapper.Interface
{
    public interface IReportService
    {
        Task<IEnumerable<RevenueReportViewModel>> GetReportAsync(string fromDate, string toDate);
    }
}
