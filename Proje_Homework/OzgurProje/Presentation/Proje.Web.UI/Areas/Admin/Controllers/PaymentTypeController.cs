using AutoMapper;
using Proje.Common.DTOs.PaymentType;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.PaymentTypeViewModels;
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
    public class PaymentTypeController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IPaymentTypeApi _paymentTypeApi;
        private readonly IMapper _mapper;

        public PaymentTypeController(
            IWebHostEnvironment env,
            IPaymentTypeApi paymentTypeApi,
            IMapper mapper)
        {
            _env = env;
            _paymentTypeApi = paymentTypeApi;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<PaymentTypeViewModel> list = new List<PaymentTypeViewModel>();
            var listResult = await _paymentTypeApi.List();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<PaymentTypeViewModel>>(listResult.Content.ResultData);

            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreatePaymentTypeViewModel item)
        {
            if (ModelState.IsValid)
            {
                var insertResult = await _paymentTypeApi.Post(_mapper.Map<PaymentTypeRequest>(item));
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
            UpdatePaymentTypeViewModel model = new UpdatePaymentTypeViewModel();
            var updateResult = await _paymentTypeApi.Get(id);
            if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                model = _mapper.Map<UpdatePaymentTypeViewModel>(updateResult.Content.ResultData);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdatePaymentTypeViewModel item)
        {
            if (ModelState.IsValid)
            {
                var updateResult = await _paymentTypeApi.Put(item.Id, _mapper.Map<PaymentTypeRequest>(item));
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
            var activatedResut = await _paymentTypeApi.Activate(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedResut = await _paymentTypeApi.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            PaymentTypeViewModel model = new PaymentTypeViewModel();
            var result = await _paymentTypeApi.Get(id);
            if (result.IsSuccessStatusCode && result.Content.IsSuccess && result.Content.ResultData != null)
                model = _mapper.Map<PaymentTypeViewModel>(result.Content.ResultData);
            return View(model);
        }
    }
}
