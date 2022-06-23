using AutoMapper;
using Proje.Common.DTOs.Options;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.OptionsViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proje.Web.UI.Areas.Admin.Models.OptionGroupViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Proje.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class OptionsController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IOptionsApi _brandApi;
        private readonly IOptionGroupApi _optionGroupApi;
        private readonly IMapper _mapper;

        public OptionsController(IWebHostEnvironment env, IOptionsApi brandApi, IOptionGroupApi optionGroupApi, IMapper mapper)
        {
            _env = env;
            _brandApi = brandApi;
            _optionGroupApi = optionGroupApi;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<OptionsViewModel> list = new List<OptionsViewModel>();
            var listResult = await _brandApi.List();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<OptionsViewModel>>(listResult.Content.ResultData);

            foreach (var item in list)
            {
                var optionGroupResult = await _optionGroupApi.Get(item.OptionGroupId);
                var optionGroup = _mapper.Map<OptionGroupViewModel>(optionGroupResult.Content.ResultData);
                item.OptionGroup = optionGroup;
            }


            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Insert()
        {

            #region OptionGroup ViewBag
            List<OptionGroupViewModel> list = new List<OptionGroupViewModel>();
            var listResult = await _optionGroupApi.GetActive();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<OptionGroupViewModel>>(listResult.Content.ResultData);


            ViewBag.OptionGroups = new SelectList(list, "Id", "Title"); 
            #endregion

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateOptionsViewModel item)
        {
            #region OptionGroup ViewBag
            List<OptionGroupViewModel> list = new List<OptionGroupViewModel>();
            var listResult = await _optionGroupApi.GetActive();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<OptionGroupViewModel>>(listResult.Content.ResultData);


            ViewBag.Products = new SelectList(list, "Id", "Title");
            #endregion


            if (ModelState.IsValid)
            {
                var insertResult = await _brandApi.Post(_mapper.Map<OptionsRequest>(item));
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
            #region OptionGroup ViewBag
            List<OptionGroupViewModel> list = new List<OptionGroupViewModel>();
            var listResult = await _optionGroupApi.GetActive();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<OptionGroupViewModel>>(listResult.Content.ResultData);


            ViewBag.OptionGroups = new SelectList(list, "Id", "Title");
            #endregion


            UpdateOptionsViewModel model = new UpdateOptionsViewModel();
            var updateResult = await _brandApi.Get(id);
            if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                model = _mapper.Map<UpdateOptionsViewModel>(updateResult.Content.ResultData);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateOptionsViewModel item)
        {
            #region OptionGroup ViewBag
            List<OptionGroupViewModel> list = new List<OptionGroupViewModel>();
            var listResult = await _optionGroupApi.GetActive();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<OptionGroupViewModel>>(listResult.Content.ResultData);


            ViewBag.OptionGroups = new SelectList(list, "Id", "Title");
            #endregion

            if (ModelState.IsValid)
            {
                var updateResult = await _brandApi.Put(item.Id, _mapper.Map<OptionsRequest>(item));
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
            var activatedResut = await _brandApi.Activate(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedResut = await _brandApi.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            OptionsViewModel model = new OptionsViewModel();
            var result = await _brandApi.Get(id);
            if (result.IsSuccessStatusCode && result.Content.IsSuccess && result.Content.ResultData != null)
                model = _mapper.Map<OptionsViewModel>(result.Content.ResultData);
            return View(model);
        }
    }
}
