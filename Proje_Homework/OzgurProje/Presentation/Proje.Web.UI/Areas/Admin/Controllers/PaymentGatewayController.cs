using AutoMapper;
using Proje.Common.DTOs.PaymentGateway;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.PaymentGatewayViewModels;
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
    public class PaymentGatewayController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IPaymentGatewayApi _paymentGatewayApi;
        private readonly IMapper _mapper;

        public PaymentGatewayController(
            IWebHostEnvironment env,
            IPaymentGatewayApi paymentGatewayApi,
            IMapper mapper)
        {
            _env = env;
            _paymentGatewayApi = paymentGatewayApi;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<PaymentGatewayViewModel> list = new List<PaymentGatewayViewModel>();
            var listResult = await _paymentGatewayApi.List();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<PaymentGatewayViewModel>>(listResult.Content.ResultData);

            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreatePaymentGatewayViewModel item)
        {
            if (ModelState.IsValid)
            {
                var insertResult = await _paymentGatewayApi.Post(_mapper.Map<PaymentGatewayRequest>(item));
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
            UpdatePaymentGatewayViewModel model = new UpdatePaymentGatewayViewModel();
            var updateResult = await _paymentGatewayApi.Get(id);
            if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                model = _mapper.Map<UpdatePaymentGatewayViewModel>(updateResult.Content.ResultData);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdatePaymentGatewayViewModel item)
        {
            if (ModelState.IsValid)
            {
                var updateResult = await _paymentGatewayApi.Put(item.Id, _mapper.Map<PaymentGatewayRequest>(item));
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
            var activatedResut = await _paymentGatewayApi.Activate(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedResut = await _paymentGatewayApi.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            PaymentGatewayViewModel model = new PaymentGatewayViewModel();
            var result = await _paymentGatewayApi.Get(id);
            if (result.IsSuccessStatusCode && result.Content.IsSuccess && result.Content.ResultData != null)
                model = _mapper.Map<PaymentGatewayViewModel>(result.Content.ResultData);
            return View(model);
        }
    }
}
