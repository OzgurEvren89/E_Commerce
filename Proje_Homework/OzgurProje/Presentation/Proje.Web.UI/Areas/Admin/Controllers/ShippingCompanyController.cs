using AutoMapper;
using Proje.Common.DTOs.ShippingCompany;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.ShippingCompanyViewModels;
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
    public class ShippingCompanyController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IShippingCompanyApi _shippingCompanyApi;
        private readonly IMapper _mapper;

        public ShippingCompanyController(
            IWebHostEnvironment env,
            IShippingCompanyApi shippingCompanyApi,
            IMapper mapper)
        {
            _env = env;
            _shippingCompanyApi = shippingCompanyApi;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<ShippingCompanyViewModel> list = new List<ShippingCompanyViewModel>();
            var listResult = await _shippingCompanyApi.List();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<ShippingCompanyViewModel>>(listResult.Content.ResultData);

            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateShippingCompanyViewModel item)
        {
            if (ModelState.IsValid)
            {
                var insertResult = await _shippingCompanyApi.Post(_mapper.Map<ShippingCompanyRequest>(item));
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
            UpdateShippingCompanyViewModel model = new UpdateShippingCompanyViewModel();
            var updateResult = await _shippingCompanyApi.Get(id);
            if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                model = _mapper.Map<UpdateShippingCompanyViewModel>(updateResult.Content.ResultData);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateShippingCompanyViewModel item)
        {
            if (ModelState.IsValid)
            {
                var updateResult = await _shippingCompanyApi.Put(item.Id, _mapper.Map<ShippingCompanyRequest>(item));
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
            var activatedResut = await _shippingCompanyApi.Activate(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedResut = await _shippingCompanyApi.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            ShippingCompanyViewModel model = new ShippingCompanyViewModel();
            var result = await _shippingCompanyApi.Get(id);
            if (result.IsSuccessStatusCode && result.Content.IsSuccess && result.Content.ResultData != null)
                model = _mapper.Map<ShippingCompanyViewModel>(result.Content.ResultData);
            return View(model);
        }
    }
}
