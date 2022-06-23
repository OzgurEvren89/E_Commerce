using AutoMapper;
using Proje.Common.DTOs.InstallmentRate;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.InstallmentRateViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proje.Web.UI.Areas.Admin.Models.PaymentGatewayViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Proje.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class InstallmentRateController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IInstallmentRateApi _installmentRateApi;
        private readonly IPaymentGatewayApi _paymentGatewayApi;
        private readonly IMapper _mapper;

        public InstallmentRateController(IWebHostEnvironment env, IInstallmentRateApi installmentRateApi, IPaymentGatewayApi paymentGatewayApi, IMapper mapper)
        {
            _env = env;
            _installmentRateApi = installmentRateApi;
            _paymentGatewayApi = paymentGatewayApi;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<InstallmentRateViewModel> list = new List<InstallmentRateViewModel>();
            var listResult = await _installmentRateApi.List();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<InstallmentRateViewModel>>(listResult.Content.ResultData);

            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            List<PaymentGatewayViewModel> list = new List<PaymentGatewayViewModel>();
            var listResult = await _paymentGatewayApi.GetActive();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<PaymentGatewayViewModel>>(listResult.Content.ResultData);

            ViewBag.PaymentGateways = new SelectList(list, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateInstallmentRateViewModel item)
        {
            if (ModelState.IsValid)
            {
                var insertResult = await _installmentRateApi.Post(_mapper.Map<InstallmentRateRequest>(item));
                if (insertResult.IsSuccessStatusCode && insertResult.Content.IsSuccess && insertResult.Content.ResultData != null)
                    return RedirectToAction("Index");
                else
                    TempData["Message"] = "Kayıt işlemi sırasında bir hata oluştu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";
            }
            else
                TempData["Message"] = "İşlem başarısız oldu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";

            List<PaymentGatewayViewModel> list = new List<PaymentGatewayViewModel>();
            var listResult = await _paymentGatewayApi.GetActive();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<PaymentGatewayViewModel>>(listResult.Content.ResultData);

            ViewBag.PaymentGateways = new SelectList(list, "Id", "Name");

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            UpdateInstallmentRateViewModel model = new UpdateInstallmentRateViewModel();
            var updateResult = await _installmentRateApi.Get(id);
            if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                model = _mapper.Map<UpdateInstallmentRateViewModel>(updateResult.Content.ResultData);

            List<PaymentGatewayViewModel> list = new List<PaymentGatewayViewModel>();
            var listResult = await _paymentGatewayApi.GetActive();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<PaymentGatewayViewModel>>(listResult.Content.ResultData);

            ViewBag.PaymentGateways = new SelectList(list, "Id", "Name");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateInstallmentRateViewModel item)
        {
            if (ModelState.IsValid)
            {
                var updateResult = await _installmentRateApi.Put(item.Id, _mapper.Map<InstallmentRateRequest>(item));
                if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                    return RedirectToAction("Index");
                else
                    TempData["Message"] = "Güncelleme işlemi sırasında bir hata oluştu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";
            }
            else
                TempData["Message"] = "İşlem başarısız oldu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";

            List<PaymentGatewayViewModel> list = new List<PaymentGatewayViewModel>();
            var listResult = await _paymentGatewayApi.GetActive();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<PaymentGatewayViewModel>>(listResult.Content.ResultData);

            ViewBag.PaymentGateways = new SelectList(list, "Id", "Name");

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Activate(Guid id)
        {
            var activatedResut = await _installmentRateApi.Activate(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedResut = await _installmentRateApi.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            InstallmentRateViewModel model = new InstallmentRateViewModel();
            var result = await _installmentRateApi.Get(id);
            if (result.IsSuccessStatusCode && result.Content.IsSuccess && result.Content.ResultData != null)
                model = _mapper.Map<InstallmentRateViewModel>(result.Content.ResultData);
            return View(model);
        }
    }
}
