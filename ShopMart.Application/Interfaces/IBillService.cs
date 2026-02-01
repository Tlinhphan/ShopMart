using ShopMart.Application.ViewModels.Product;
using ShopMart.Data.Enums;
using ShopMart.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMart.Application.Interfaces
{
   public interface IBillService
    {
        void Create(IBillService billVm);

        void Update(IBillService billVm);

        PagedResult<BillViewModel> GetAllPaging(string startDate, string endDate, string keyword,
            int pageIndex, int pageSize);

        BillViewModel GetDetail(int billId);

        BillDetailViewModel CreateDetail(BillDetailViewModel billDetailVm);

        void DeleteDetail(int productId, int billId, int colorId, int sizeId);

        void UpdateStatus(int orderId, BillStatus status);

        List<BillDetailViewModel> GetBillDetails(int billId);

        List<ColorViewModel> GetColors();

        List<SizeViewModel> GetSizes();

        void Save();
        void Create(BillViewModel billVm);
        void Update(BillViewModel billVm);
    }
}
