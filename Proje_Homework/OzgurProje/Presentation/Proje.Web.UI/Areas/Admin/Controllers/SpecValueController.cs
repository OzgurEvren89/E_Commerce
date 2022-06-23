using AutoMapper;
using Proje.Common.DTOs.SpecValue;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.SpecValueViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proje.Web.UI.Areas.Admin.Models.SpecGroupViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proje.Web.UI.Areas.Admin.Models.SpecNameViewModels;

namespace Proje.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class SpecValueController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly ISpecValueApi _specValueApi;
        private readonly ISpecGroupApi _specGroupApi;
        private readonly ISpecNameApi _specNameApi;
        private readonly IMapper _mapper;

        public SpecValueController(IWebHostEnvironment env, ISpecValueApi specValueApi, ISpecGroupApi specGroupApi, ISpecNameApi specNameApi, IMapper mapper)
        {
            _env = env;
            _specValueApi = specValueApi;
            _specGroupApi = specGroupApi;
            _specNameApi = specNameApi;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<SpecValueViewModel> list = new List<SpecValueViewModel>();
            var listResult = await _specValueApi.List();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<SpecValueViewModel>>(listResult.Content.ResultData);

            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Insert()
        {

            List<SpecNameViewModel> namelist = new List<SpecNameViewModel>();
            var specNameResult = await _specNameApi.GetActive();

            if (specNameResult.IsSuccessStatusCode &&
                specNameResult.Content.IsSuccess &&
                specNameResult.Content.ResultData.Any())
                namelist = _mapper.Map<List<SpecNameViewModel>>(specNameResult.Content.ResultData);


            ViewBag.SpecNames = new SelectList(namelist, "Id", "Name");

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
        public async Task<IActionResult> Insert(CreateSpecValueViewModel item)
        {
            if (ModelState.IsValid)
            {
                var insertResult = await _specValueApi.Post(_mapper.Map<SpecValueRequest>(item));
                if (insertResult.IsSuccessStatusCode && insertResult.Content.IsSuccess && insertResult.Content.ResultData != null)
                    return RedirectToAction("Index");
                else
                    TempData["Message"] = "Kayıt işlemi sırasında bir hata oluştu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";
            }
            else
                TempData["Message"] = "İşlem başarısız oldu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";

            List<SpecNameViewModel> namelist = new List<SpecNameViewModel>();
            var specNameResult = await _specNameApi.GetActive();

            if (specNameResult.IsSuccessStatusCode &&
                specNameResult.Content.IsSuccess &&
                specNameResult.Content.ResultData.Any())
                namelist = _mapper.Map<List<SpecNameViewModel>>(specNameResult.Content.ResultData);


            ViewBag.SpecNames = new SelectList(namelist, "Id", "Name");


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
            UpdateSpecValueViewModel model = new UpdateSpecValueViewModel();
            var updateResult = await _specValueApi.Get(id);
            if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                model = _mapper.Map<UpdateSpecValueViewModel>(updateResult.Content.ResultData);

            List<SpecNameViewModel> namelist = new List<SpecNameViewModel>();
            var specNameResult = await _specNameApi.GetActive();

            if (specNameResult.IsSuccessStatusCode &&
                specNameResult.Content.IsSuccess &&
                specNameResult.Content.ResultData.Any())
                namelist = _mapper.Map<List<SpecNameViewModel>>(specNameResult.Content.ResultData);


            ViewBag.SpecNames = new SelectList(namelist, "Id", "Name");

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
        public async Task<IActionResult> Update(UpdateSpecValueViewModel item)
        {
            if (ModelState.IsValid)
            {
                var updateResult = await _specValueApi.Put(item.Id, _mapper.Map<SpecValueRequest>(item));
                if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                    return RedirectToAction("Index");
                else
                    TempData["Message"] = "Güncelleme işlemi sırasında bir hata oluştu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";
            }
            else
                TempData["Message"] = "İşlem başarısız oldu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";

            List<SpecNameViewModel> namelist = new List<SpecNameViewModel>();
            var specNameResult = await _specNameApi.GetActive();

            if (specNameResult.IsSuccessStatusCode &&
                specNameResult.Content.IsSuccess &&
                specNameResult.Content.ResultData.Any())
                namelist = _mapper.Map<List<SpecNameViewModel>>(specNameResult.Content.ResultData);


            ViewBag.SpecNames = new SelectList(namelist, "Id", "Name");

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
            var activatedResut = await _specValueApi.Activate(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedResut = await _specValueApi.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            SpecValueViewModel model = new SpecValueViewModel();
            var result = await _specValueApi.Get(id);
            if (result.IsSuccessStatusCode && result.Content.IsSuccess && result.Content.ResultData != null)
                model = _mapper.Map<SpecValueViewModel>(result.Content.ResultData);
            return View(model);
        }
    }
}
