using AutoMapper;
using Proje.Common.DTOs.DemandReason;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.DemandReasonViewModels;
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
    public class DemandReasonController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IDemandReasonApi _demandReasonApi;
        private readonly IMapper _mapper;

        public DemandReasonController(
            IWebHostEnvironment env,
            IDemandReasonApi demandReasonApi,
            IMapper mapper)
        {
            _env = env;
            _demandReasonApi = demandReasonApi;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<DemandReasonViewModel> list = new List<DemandReasonViewModel>();
            var listResult = await _demandReasonApi.List();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<DemandReasonViewModel>>(listResult.Content.ResultData);

            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateDemandReasonViewModel item)
        {
            if (ModelState.IsValid)
            {
                var insertResult = await _demandReasonApi.Post(_mapper.Map<DemandReasonRequest>(item));
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
            UpdateDemandReasonViewModel model = new UpdateDemandReasonViewModel();
            var updateResult = await _demandReasonApi.Get(id);
            if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                model = _mapper.Map<UpdateDemandReasonViewModel>(updateResult.Content.ResultData);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateDemandReasonViewModel item)
        {
            if (ModelState.IsValid)
            {
                var updateResult = await _demandReasonApi.Put(item.Id, _mapper.Map<DemandReasonRequest>(item));
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
            var activatedResut = await _demandReasonApi.Activate(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedResut = await _demandReasonApi.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            DemandReasonViewModel model = new DemandReasonViewModel();
            var result = await _demandReasonApi.Get(id);
            if (result.IsSuccessStatusCode && result.Content.IsSuccess && result.Content.ResultData != null)
                model = _mapper.Map<DemandReasonViewModel>(result.Content.ResultData);
            return View(model);
        }
    }
}
