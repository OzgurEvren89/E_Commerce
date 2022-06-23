using AutoMapper;
using Proje.Common.DTOs.BrandToCategory;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.BrandToCategoryViewModels;
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
    public class BrandToCategoryController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IBrandToCategoryApi _brandtocategoryApi;
        private readonly IMapper _mapper;

        public BrandToCategoryController(
            IWebHostEnvironment env,
            IBrandToCategoryApi brandtocategoryApi,
            IMapper mapper)
        {
            _env = env;
            _brandtocategoryApi = brandtocategoryApi;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<BrandToCategoryViewModel> list = new List<BrandToCategoryViewModel>();
            var listResult = await _brandtocategoryApi.List();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<BrandToCategoryViewModel>>(listResult.Content.ResultData);

            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateBrandToCategoryViewModel item)
        {
            if (ModelState.IsValid)
            {
                var insertResult = await _brandtocategoryApi.Post(_mapper.Map<BrandToCategoryRequest>(item));
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
            UpdateBrandToCategoryViewModel model = new UpdateBrandToCategoryViewModel();
            var updateResult = await _brandtocategoryApi.Get(id);
            if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                model = _mapper.Map<UpdateBrandToCategoryViewModel>(updateResult.Content.ResultData);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateBrandToCategoryViewModel item)
        {
            if (ModelState.IsValid)
            {
                var updateResult = await _brandtocategoryApi.Put(item.Id, _mapper.Map<BrandToCategoryRequest>(item));
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
            var activatedResut = await _brandtocategoryApi.Activate(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedResut = await _brandtocategoryApi.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            BrandToCategoryViewModel model = new BrandToCategoryViewModel();
            var result = await _brandtocategoryApi.Get(id);
            if (result.IsSuccessStatusCode && result.Content.IsSuccess && result.Content.ResultData != null)
                model = _mapper.Map<BrandToCategoryViewModel>(result.Content.ResultData);
            return View(model);
        }
    }
}
