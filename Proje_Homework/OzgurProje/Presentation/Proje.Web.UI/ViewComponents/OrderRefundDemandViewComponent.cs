using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.DemandReasonViewModels;
using Proje.Web.UI.Areas.Admin.Models.OrderRefundDemandViewModels;
using Proje.Web.UI.Areas.Admin.Models.OrderViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.ViewComponents
{
    public class OrderRefundDemandViewComponent : ViewComponent
    {
        private readonly IOrderRefundDemandApi _orderRefundDemandApi;
        private readonly IDemandReasonApi _demandReasonApi;
        private readonly IOrderApi _orderApi;
        private readonly IMapper _mapper;

        public OrderRefundDemandViewComponent(IOrderRefundDemandApi orderRefundDemandApi, IDemandReasonApi demandReasonApi, IOrderApi orderApi, IMapper mapper)
        {
            _orderRefundDemandApi = orderRefundDemandApi;
            _demandReasonApi = demandReasonApi;
            _orderApi = orderApi;
            _mapper = mapper;
        }


        public async Task<IViewComponentResult> InvokeAsync(Guid id)//order Id gelsin.
        {

            #region DemandReason ViewBag

            List<DemandReasonViewModel> demandReasonList = new List<DemandReasonViewModel>();
            var demandReasonListResult = await _demandReasonApi.GetActive();

            if (demandReasonListResult.IsSuccessStatusCode &&
                demandReasonListResult.Content.IsSuccess &&
                demandReasonListResult.Content.ResultData.Any())
                demandReasonList = _mapper.Map<List<DemandReasonViewModel>>(demandReasonListResult.Content.ResultData);


            ViewBag.DemandReason = new SelectList(demandReasonList, "Reason", "Reason");
            #endregion

            #region Order ViewBag

            List<OrderViewModel> orderList = new List<OrderViewModel>();
            var orderListResult = await _orderApi.GetActive();

            if (orderListResult.IsSuccessStatusCode &&
                orderListResult.Content.IsSuccess &&
                orderListResult.Content.ResultData.Any())
                orderList = _mapper.Map<List<OrderViewModel>>(orderListResult.Content.ResultData);

            var order = orderList.FirstOrDefault(x => x.Id == id);

            #endregion

            ViewData["order"] = order;

            return View(new CreateOrderRefundDemandViewModel());
        }
    }
}
