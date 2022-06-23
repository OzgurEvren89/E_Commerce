using AutoMapper;
using Proje.Common.DTOs.Distributor;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.DistributorViewModels;
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
    public class DistributorController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IDistributorApi _distributorApi;
        private readonly IMapper _mapper;

        public DistributorController(
            IWebHostEnvironment env,
            IDistributorApi distributorApi,
            IMapper mapper)
        {
            _env = env;
            _distributorApi = distributorApi;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<DistributorViewModel> list = new List<DistributorViewModel>();
            var listResult = await _distributorApi.List();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<DistributorViewModel>>(listResult.Content.ResultData);

            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateDistributorViewModel item)
        {
            if (ModelState.IsValid)
            {
                var insertResult = await _distributorApi.Post(_mapper.Map<DistributorRequest>(item));
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
            UpdateDistributorViewModel model = new UpdateDistributorViewModel();
            var updateResult = await _distributorApi.Get(id);
            if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                model = _mapper.Map<UpdateDistributorViewModel>(updateResult.Content.ResultData);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateDistributorViewModel item)
        {
            if (ModelState.IsValid)
            {
                var updateResult = await _distributorApi.Put(item.Id, _mapper.Map<DistributorRequest>(item));
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
            var activatedResut = await _distributorApi.Activate(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedResut = await _distributorApi.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            DistributorViewModel model = new DistributorViewModel();
            var result = await _distributorApi.Get(id);
            if (result.IsSuccessStatusCode && result.Content.IsSuccess && result.Content.ResultData != null)
                model = _mapper.Map<DistributorViewModel>(result.Content.ResultData);
            return View(model);
        }
    }
}
