using AutoMapper;
using Proje.Common.DTOs.OrderRefundDemand;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.OrderRefundDemandViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proje.Web.UI.Areas.Admin.Models.UserViewModels;
using Proje.Web.UI.Areas.Admin.Models.OrderViewModels;
using Proje.Web.UI.Areas.Admin.Models.DemandReasonViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proje.Web.UI.Areas.Admin.Models.DemandStatusViewModels;

namespace Proje.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class OrderRefundDemandController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IOrderRefundDemandApi _orderRefundDemandApi;
        private readonly IUserApi _userApi;
        private readonly IOrderApi _orderApi;
        private readonly IDemandReasonApi _demandReasonApi;
        private readonly IDemandStatusApi _demandStatusApi;
        private readonly IMapper _mapper;

        public OrderRefundDemandController(IWebHostEnvironment env, IOrderRefundDemandApi orderRefundDemandApi, IUserApi userApi, IOrderApi orderApi, IDemandReasonApi demandReasonApi, IDemandStatusApi demandStatusApi, IMapper mapper)
        {
            _env = env;
            _orderRefundDemandApi = orderRefundDemandApi;
            _userApi = userApi;
            _orderApi = orderApi;
            _demandReasonApi = demandReasonApi;
            _demandStatusApi = demandStatusApi;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {

            List<OrderRefundDemandViewModel> list = new List<OrderRefundDemandViewModel>();
            var listResult = await _orderRefundDemandApi.List();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<OrderRefundDemandViewModel>>(listResult.Content.ResultData);

            List<UserViewModel> userList = new List<UserViewModel>();
            var userListResult = await _userApi.GetActive();
            if (userListResult.IsSuccessStatusCode && userListResult.Content.IsSuccess)
                userList = _mapper.Map<List<UserViewModel>>(userListResult.Content.ResultData);

            foreach (var item in list)
            {
                item.User = userList.FirstOrDefault(x => x.Id == item.UserId);
            }

            return View(list);
        }
     

        [HttpGet]
        public async Task<IActionResult> UpdateStatus(Guid id)
        {
            #region DemandStatus ViewBag

            List<DemandStatusViewModel> demandStatusList = new List<DemandStatusViewModel>();
            var demandStatusListResult = await _demandStatusApi.GetActive();

            if (demandStatusListResult.IsSuccessStatusCode &&
                demandStatusListResult.Content.IsSuccess &&
                demandStatusListResult.Content.ResultData.Any())
                demandStatusList = _mapper.Map<List<DemandStatusViewModel>>(demandStatusListResult.Content.ResultData);


            ViewBag.DemandStatus = new SelectList(demandStatusList, "Name", "Name");
            #endregion

            UpdateOrderRefundDemandViewModel model = new UpdateOrderRefundDemandViewModel();
            var updateResult = await _orderRefundDemandApi.Get(id);
            if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                model = _mapper.Map<UpdateOrderRefundDemandViewModel>(updateResult.Content.ResultData);
          

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatus(UpdateOrderRefundDemandViewModel item)
        {
            #region DemandStatus ViewBag

            List<DemandStatusViewModel> demandStatusList = new List<DemandStatusViewModel>();
            var demandStatusListResult = await _demandStatusApi.GetActive();

            if (demandStatusListResult.IsSuccessStatusCode &&
                demandStatusListResult.Content.IsSuccess &&
                demandStatusListResult.Content.ResultData.Any())
                demandStatusList = _mapper.Map<List<DemandStatusViewModel>>(demandStatusListResult.Content.ResultData);


            ViewBag.DemandStatus = new SelectList(demandStatusList, "Name", "Name");
            #endregion

            #region Order ViewBag

            List<OrderViewModel> orderList = new List<OrderViewModel>();
            var orderListResult = await _orderApi.GetActive();

            if (orderListResult.IsSuccessStatusCode &&
                orderListResult.Content.IsSuccess &&
                orderListResult.Content.ResultData.Any())
                orderList = _mapper.Map<List<OrderViewModel>>(orderListResult.Content.ResultData);



            #endregion

            #region DemandReason ViewBag

            List<DemandReasonViewModel> demandReasonList = new List<DemandReasonViewModel>();
            var demandReasonListResult = await _demandReasonApi.GetActive();

            if (demandReasonListResult.IsSuccessStatusCode &&
                demandReasonListResult.Content.IsSuccess &&
                demandReasonListResult.Content.ResultData.Any())
                demandReasonList = _mapper.Map<List<DemandReasonViewModel>>(demandReasonListResult.Content.ResultData);


            ViewBag.DemandReason = new SelectList(demandReasonList, "Reason", "Reason");
            #endregion

            if (ModelState.IsValid)
            {
                var updateResult = await _orderRefundDemandApi.Put(item.Id, _mapper.Map<OrderRefundDemandRequest>(item));
                if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                    return RedirectToAction("Index");
                else
                    TempData["Message"] = "Güncelleme işlemi sırasında bir hata oluştu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";
            }
            else
                TempData["Message"] = "İşlem başarısız oldu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Activate(Guid id)
        {
            var activatedResut = await _orderRefundDemandApi.Activate(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedResut = await _orderRefundDemandApi.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            OrderRefundDemandViewModel model = new OrderRefundDemandViewModel();
            var result = await _orderRefundDemandApi.Get(id);
            if (result.IsSuccessStatusCode && result.Content.IsSuccess && result.Content.ResultData != null)
                model = _mapper.Map<OrderRefundDemandViewModel>(result.Content.ResultData);
            return View(model);
        }
    }
}
