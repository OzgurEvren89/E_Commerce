using AutoMapper;
using Proje.Common.DTOs.County;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.CountyViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proje.Web.UI.Areas.Admin.Models.CityViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Proje.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class CountyController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly ICountyApi _countyApi;
        private readonly ICityApi _cityApi;
        private readonly IMapper _mapper;

        public CountyController(IWebHostEnvironment env, ICountyApi countyApi, ICityApi cityApi, IMapper mapper)
        {
            _env = env;
            _countyApi = countyApi;
            _cityApi = cityApi;
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<CountyViewModel> list = new List<CountyViewModel>();
            var listResult = await _countyApi.List();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<CountyViewModel>>(listResult.Content.ResultData);

            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            #region CityCode ViewBag

            List<CityViewModel> list = new List<CityViewModel>();
            var listResult = await _cityApi.GetActive();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<CityViewModel>>(listResult.Content.ResultData);

            ViewBag.Cities = new SelectList(list, "CityCode", "CityName");

            #endregion

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateCountyViewModel item)
        {
            if (ModelState.IsValid)
            {
                var insertResult = await _countyApi.Post(_mapper.Map<CountyRequest>(item));
                if (insertResult.IsSuccessStatusCode && insertResult.Content.IsSuccess && insertResult.Content.ResultData != null)
                    return RedirectToAction("Index");
                else
                    TempData["Message"] = "Kayıt işlemi sırasında bir hata oluştu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";
            }
            else
                TempData["Message"] = "İşlem başarısız oldu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";

            #region CityCode ViewBag

            List<CityViewModel> list = new List<CityViewModel>();
            var listResult = await _cityApi.GetActive();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<CityViewModel>>(listResult.Content.ResultData);

            ViewBag.Cities = new SelectList(list, "CityCode", "CityName");

            #endregion


            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            UpdateCountyViewModel model = new UpdateCountyViewModel();
            var updateResult = await _countyApi.Get(id);
            if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                model = _mapper.Map<UpdateCountyViewModel>(updateResult.Content.ResultData);

            #region CityCode ViewBag

            List<CityViewModel> list = new List<CityViewModel>();
            var listResult = await _cityApi.GetActive();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<CityViewModel>>(listResult.Content.ResultData);

            ViewBag.Cities = new SelectList(list, "CityCode", "CityName");

            #endregion

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCountyViewModel item)
        {
            if (ModelState.IsValid)
            {
                var updateResult = await _countyApi.Put(item.Id, _mapper.Map<CountyRequest>(item));
                if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                    return RedirectToAction("Index");
                else
                    TempData["Message"] = "Güncelleme işlemi sırasında bir hata oluştu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";
            }
            else
                TempData["Message"] = "İşlem başarısız oldu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";

            #region CityCode ViewBag

            List<CityViewModel> list = new List<CityViewModel>();
            var listResult = await _cityApi.GetActive();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<CityViewModel>>(listResult.Content.ResultData);

            ViewBag.Cities = new SelectList(list, "CityCode", "CityName");

            #endregion


            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Activate(Guid id)
        {
            var activatedResut = await _countyApi.Activate(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedResut = await _countyApi.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            CountyViewModel model = new CountyViewModel();
            var result = await _countyApi.Get(id);
            if (result.IsSuccessStatusCode && result.Content.IsSuccess && result.Content.ResultData != null)
                model = _mapper.Map<CountyViewModel>(result.Content.ResultData);
            return View(model);
        }
    }
}
