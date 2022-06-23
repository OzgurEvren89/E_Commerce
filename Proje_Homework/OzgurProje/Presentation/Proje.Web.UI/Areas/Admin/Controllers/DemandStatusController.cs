using AutoMapper;
using Proje.Common.DTOs.DemandStatus;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.DemandStatusViewModels;
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
    public class DemandStatusController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IDemandStatusApi _demandStatusApi;
        private readonly IMapper _mapper;

        public DemandStatusController(
            IWebHostEnvironment env,
            IDemandStatusApi demandStatusApi,
            IMapper mapper)
        {
            _env = env;
            _demandStatusApi = demandStatusApi;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<DemandStatusViewModel> list = new List<DemandStatusViewModel>();
            var listResult = await _demandStatusApi.List();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<DemandStatusViewModel>>(listResult.Content.ResultData);

            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateDemandStatusViewModel item)
        {
            if (ModelState.IsValid)
            {
                var insertResult = await _demandStatusApi.Post(_mapper.Map<DemandStatusRequest>(item));
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
            UpdateDemandStatusViewModel model = new UpdateDemandStatusViewModel();
            var updateResult = await _demandStatusApi.Get(id);
            if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                model = _mapper.Map<UpdateDemandStatusViewModel>(updateResult.Content.ResultData);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateDemandStatusViewModel item)
        {
            if (ModelState.IsValid)
            {
                var updateResult = await _demandStatusApi.Put(item.Id, _mapper.Map<DemandStatusRequest>(item));
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
            var activatedResut = await _demandStatusApi.Activate(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedResut = await _demandStatusApi.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            DemandStatusViewModel model = new DemandStatusViewModel();
            var result = await _demandStatusApi.Get(id);
            if (result.IsSuccessStatusCode && result.Content.IsSuccess && result.Content.ResultData != null)
                model = _mapper.Map<DemandStatusViewModel>(result.Content.ResultData);
            return View(model);
        }
    }
}
