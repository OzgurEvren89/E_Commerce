using AutoMapper;
using Proje.Common.DTOs.PaymentStatus;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.PaymentStatusViewModels;
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
    public class PaymentStatusController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IPaymentStatusApi _paymentStatusApi;
        private readonly IMapper _mapper;

        public PaymentStatusController(
            IWebHostEnvironment env,
            IPaymentStatusApi paymentStatusApi,
            IMapper mapper)
        {
            _env = env;
            _paymentStatusApi = paymentStatusApi;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<PaymentStatusViewModel> list = new List<PaymentStatusViewModel>();
            var listResult = await _paymentStatusApi.List();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<PaymentStatusViewModel>>(listResult.Content.ResultData);

            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreatePaymentStatusViewModel item)
        {
            if (ModelState.IsValid)
            {
                var insertResult = await _paymentStatusApi.Post(_mapper.Map<PaymentStatusRequest>(item));
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
            UpdatePaymentStatusViewModel model = new UpdatePaymentStatusViewModel();
            var updateResult = await _paymentStatusApi.Get(id);
            if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                model = _mapper.Map<UpdatePaymentStatusViewModel>(updateResult.Content.ResultData);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdatePaymentStatusViewModel item)
        {
            if (ModelState.IsValid)
            {
                var updateResult = await _paymentStatusApi.Put(item.Id, _mapper.Map<PaymentStatusRequest>(item));
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
            var activatedResut = await _paymentStatusApi.Activate(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedResut = await _paymentStatusApi.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            PaymentStatusViewModel model = new PaymentStatusViewModel();
            var result = await _paymentStatusApi.Get(id);
            if (result.IsSuccessStatusCode && result.Content.IsSuccess && result.Content.ResultData != null)
                model = _mapper.Map<PaymentStatusViewModel>(result.Content.ResultData);
            return View(model);
        }
    }
}
