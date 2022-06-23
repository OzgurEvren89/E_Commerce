using AutoMapper;
using Proje.Common.DTOs.OrderStatus;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.OrderStatusViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Proje.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class OrderStatusController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IOrderStatusApi _orderStatusApi;
        private readonly IMapper _mapper;

        public OrderStatusController(
            IWebHostEnvironment env,
            IOrderStatusApi orderStatusApi,
            IMapper mapper)
        {
            _env = env;
            _orderStatusApi = orderStatusApi;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<OrderStatusViewModel> list = new List<OrderStatusViewModel>();
            var listResult = await _orderStatusApi.List();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<OrderStatusViewModel>>(listResult.Content.ResultData);

            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateOrderStatusViewModel item)
        {
            if (ModelState.IsValid)
            {
                var insertResult = await _orderStatusApi.Post(_mapper.Map<OrderStatusRequest>(item));
                if (insertResult.IsSuccessStatusCode && insertResult.Content.IsSuccess && insertResult.Content.ResultData != null)
                    return RedirectToAction("Index");
                else
                    TempData["Message"] = "Kayıt işlemi sırasında bir hata oluştu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";
            }
            else
                TempData["Message"] = "İşlem başarısız oldu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            UpdateOrderStatusViewModel model = new UpdateOrderStatusViewModel();
            var updateResult = await _orderStatusApi.Get(id);
            if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                model = _mapper.Map<UpdateOrderStatusViewModel>(updateResult.Content.ResultData);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateOrderStatusViewModel item)
        {
            if (ModelState.IsValid)
            {
                var updateResult = await _orderStatusApi.Put(item.Id, _mapper.Map<OrderStatusRequest>(item));
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
            var activatedResut = await _orderStatusApi.Activate(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedResut = await _orderStatusApi.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            OrderStatusViewModel model = new OrderStatusViewModel();
            var result = await _orderStatusApi.Get(id);
            if (result.IsSuccessStatusCode && result.Content.IsSuccess && result.Content.ResultData != null)
                model = _mapper.Map<OrderStatusViewModel>(result.Content.ResultData);
            return View(model);
        }
    }
}
