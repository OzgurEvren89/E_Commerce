using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.OrderItemViewModels;
using Proje.Web.UI.Areas.Admin.Models.OrderViewModels;
using Proje.Web.UI.Areas.Admin.Models.ProductViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.ViewComponents
{
    public class GetOrderViewComponent : ViewComponent
    {
        private readonly IOrderApi _orderApi;
        private readonly IOrderItemApi _orderItemApi;
        private readonly IProductApi _productApi;
        private readonly IUserApi _userApi;
        private readonly IMapper _mapper;

        public GetOrderViewComponent(IOrderApi orderApi, IOrderItemApi orderItemApi, IProductApi productApi, IUserApi userApi, IMapper mapper)
        {
            _orderApi = orderApi;
            _orderItemApi = orderItemApi;
            _productApi = productApi;
            _userApi = userApi;
            _mapper = mapper;
        }

        
        
        public async Task<IViewComponentResult> InvokeAsync( Guid id)//user'i current çek tupple yap.
        {

            #region Product List
            List<ProductViewModel> prolist = new List<ProductViewModel>();
            var proListResult = await _productApi.GetActive();
            if (proListResult.IsSuccessStatusCode && proListResult.Content.IsSuccess && proListResult.Content.ResultData.Any())
                prolist = _mapper.Map<List<ProductViewModel>>(proListResult.Content.ResultData); 

            #endregion

            #region OrderItemList Product modeli üzerinde yüklü
            List<OrderItemViewModel> orderItemList = new List<OrderItemViewModel>();
            var orderItemListResult = await _orderItemApi.GetActive();
            if (orderItemListResult.IsSuccessStatusCode && orderItemListResult.Content.IsSuccess && orderItemListResult.Content.ResultData.Any())
              orderItemList = _mapper.Map<List<OrderItemViewModel>>(orderItemListResult.Content.ResultData);

            foreach (var orderItem in orderItemList)
            {
                orderItem.Product = prolist.FirstOrDefault(x => x.Id == orderItem.ProductId);
            }

            #endregion

            #region OrderList OrderItem'modeli üzerinde yüklü
            List<OrderViewModel> orderlist = new List<OrderViewModel>();
            var orderListResult = await _orderApi.GetActive();
            if (orderListResult.IsSuccessStatusCode && orderListResult.Content.IsSuccess && orderListResult.Content.ResultData.Any())
                orderlist = _mapper.Map<List<OrderViewModel>>(orderListResult.Content.ResultData);

            foreach (var item in orderlist)
            {
                item.OrderItems = orderItemList.Where(x => x.OrderId == item.Id).ToList();
            }

            orderlist = orderlist.Where(x => x.OrderItems.FirstOrDefault().UserId == id).ToList();
           
            #endregion

            return View(orderlist);
        }
    }
}
