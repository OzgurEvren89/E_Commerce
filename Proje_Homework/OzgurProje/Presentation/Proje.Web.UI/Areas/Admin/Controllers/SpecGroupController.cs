using AutoMapper;
using Proje.Common.DTOs.SpecGroup;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.SpecGroupViewModels;
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
    public class SpecGroupController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly ISpecGroupApi _specGroupApi;
        private readonly IMapper _mapper;

        public SpecGroupController(
            IWebHostEnvironment env,
            ISpecGroupApi specGroupApi,
            IMapper mapper)
        {
            _env = env;
            _specGroupApi = specGroupApi;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<SpecGroupViewModel> list = new List<SpecGroupViewModel>();
            var listResult = await _specGroupApi.List();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<SpecGroupViewModel>>(listResult.Content.ResultData);

            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateSpecGroupViewModel item)
        {
            if (ModelState.IsValid)
            {
                var insertResult = await _specGroupApi.Post(_mapper.Map<SpecGroupRequest>(item));
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
            UpdateSpecGroupViewModel model = new UpdateSpecGroupViewModel();
            var updateResult = await _specGroupApi.Get(id);
            if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                model = _mapper.Map<UpdateSpecGroupViewModel>(updateResult.Content.ResultData);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateSpecGroupViewModel item)
        {
            if (ModelState.IsValid)
            {
                var updateResult = await _specGroupApi.Put(item.Id, _mapper.Map<SpecGroupRequest>(item));
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
            var activatedResut = await _specGroupApi.Activate(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedResut = await _specGroupApi.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            SpecGroupViewModel model = new SpecGroupViewModel();
            var result = await _specGroupApi.Get(id);
            if (result.IsSuccessStatusCode && result.Content.IsSuccess && result.Content.ResultData != null)
                model = _mapper.Map<SpecGroupViewModel>(result.Content.ResultData);
            return View(model);
        }
    }
}
