using AutoMapper;
using Proje.Common.DTOs.SpecName;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.SpecNameViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proje.Web.UI.Areas.Admin.Models.SpecGroupViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Proje.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class SpecNameController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly ISpecNameApi _specnameApi;
        private readonly ISpecGroupApi _specGroupApi;
        private readonly IMapper _mapper;

        public SpecNameController(IWebHostEnvironment env, ISpecNameApi specnameApi, ISpecGroupApi specGroupApi, IMapper mapper)
        {
            _env = env;
            _specnameApi = specnameApi;
            _specGroupApi = specGroupApi;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<SpecNameViewModel> list = new List<SpecNameViewModel>();
            var listResult = await _specnameApi.List();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<SpecNameViewModel>>(listResult.Content.ResultData);

            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Insert()
        {

            List<SpecGroupViewModel> list = new List<SpecGroupViewModel>();
            var listResult = await _specGroupApi.GetActive();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<SpecGroupViewModel>>(listResult.Content.ResultData);


            ViewBag.SpecGroups = new SelectList(list, "Id", "SpecGroupName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateSpecNameViewModel item)
        {
            if (ModelState.IsValid)
            {
                var insertResult = await _specnameApi.Post(_mapper.Map<SpecNameRequest>(item));
                if (insertResult.IsSuccessStatusCode && insertResult.Content.IsSuccess && insertResult.Content.ResultData != null)
                    return RedirectToAction("Index");
                else
                    TempData["Message"] = "Kayıt işlemi sırasında bir hata oluştu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";
            }

            else
                TempData["Message"] = "İşlem başarısız oldu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";

            List<SpecGroupViewModel> list = new List<SpecGroupViewModel>();
            var listResult = await _specGroupApi.GetActive();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<SpecGroupViewModel>>(listResult.Content.ResultData);


            ViewBag.SpecGroups = new SelectList(list, "Id", "SpecGroupName");

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            UpdateSpecNameViewModel model = new UpdateSpecNameViewModel();
            var updateResult = await _specnameApi.Get(id);
            if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                model = _mapper.Map<UpdateSpecNameViewModel>(updateResult.Content.ResultData);

            List<SpecGroupViewModel> list = new List<SpecGroupViewModel>();
            var listResult = await _specGroupApi.GetActive();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<SpecGroupViewModel>>(listResult.Content.ResultData);


            ViewBag.SpecGroups = new SelectList(list, "Id", "SpecGroupName");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateSpecNameViewModel item)
        {
            if (ModelState.IsValid)
            {
                var updateResult = await _specnameApi.Put(item.Id, _mapper.Map<SpecNameRequest>(item));
                if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                    return RedirectToAction("Index");
                else
                    TempData["Message"] = "Güncelleme işlemi sırasında bir hata oluştu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";
            }
            else
                TempData["Message"] = "İşlem başarısız oldu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";

            List<SpecGroupViewModel> list = new List<SpecGroupViewModel>();
            var listResult = await _specGroupApi.GetActive();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<SpecGroupViewModel>>(listResult.Content.ResultData);


            ViewBag.SpecGroups = new SelectList(list, "Id", "SpecGroupName");

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Activate(Guid id)
        {
            var activatedResut = await _specnameApi.Activate(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedResut = await _specnameApi.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            SpecNameViewModel model = new SpecNameViewModel();
            var result = await _specnameApi.Get(id);
            if (result.IsSuccessStatusCode && result.Content.IsSuccess && result.Content.ResultData != null)
                model = _mapper.Map<SpecNameViewModel>(result.Content.ResultData);
            return View(model);
        }
    }
}
