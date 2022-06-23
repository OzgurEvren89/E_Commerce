using AutoMapper;
using Proje.Common.DTOs.OptionToProduct;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.OptionToProductViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proje.Web.UI.Areas.Admin.Models.OptionGroupViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proje.Web.UI.Areas.Admin.Models.ProductViewModels;
using Proje.Web.UI.Areas.Admin.Models.OptionsViewModels;
using Microsoft.AspNetCore.Routing;

namespace Proje.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class OptionToProductController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IOptionToProductApi _optionToProductApi;
        private readonly IOptionGroupApi _optionGroupApi;
        private readonly IOptionsApi _optionsApi;
        private readonly IProductApi _productApi;
        private readonly IMapper _mapper;


        public OptionToProductController(IWebHostEnvironment env, IOptionToProductApi optionToProductApi, IOptionGroupApi optionGroupApi, IOptionsApi optionsApi, IProductApi productApi, IMapper mapper)
        {
            _env = env;
            _optionToProductApi = optionToProductApi;
            _optionGroupApi = optionGroupApi;
            _optionsApi = optionsApi;
            _productApi = productApi;
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<OptionToProductViewModel> list = new List<OptionToProductViewModel>();
            var listResult = await _optionToProductApi.List();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<OptionToProductViewModel>>(listResult.Content.ResultData);

          
            foreach (var item in list)
            {
                var optionGroupResult = await _optionGroupApi.Get(item.OptionGroupId);
                var optionGroup = _mapper.Map<OptionGroupViewModel>(optionGroupResult.Content.ResultData);
                item.OptionGroup = optionGroup;
            }

            foreach (var item in list)
            {
                var optionsResult = await _optionsApi.Get(item.OptionId);
                var option = _mapper.Map<OptionsViewModel>(optionsResult.Content.ResultData);
                item.Option = option;
            }

            foreach (var item in list)
            {
                var proResult = await _productApi.Get(item.ProductId);
                var product = _mapper.Map<ProductViewModel>(proResult.Content.ResultData);
                item.Product = product;
            }
           

            return View(list);

        }

        [HttpGet]
        public async Task<IActionResult> Index2 (Guid Id)
        {
            List<OptionToProductViewModel> list = new List<OptionToProductViewModel>();
            var listResult = await _optionToProductApi.List();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<OptionToProductViewModel>>(listResult.Content.ResultData);

         

            list = list.Where(x => x.ParentProductId == Id).ToList();
            ViewData["parentProduct"] = "";
            ViewData["parentProduct"] = Id;
            

            foreach (var item in list)
            {
                var optionGroupResult = await _optionGroupApi.Get(item.OptionGroupId);
                var optionGroup = _mapper.Map<OptionGroupViewModel>(optionGroupResult.Content.ResultData);
                item.OptionGroup = optionGroup;
            }

            foreach (var item in list)
            {
                var optionsResult = await _optionsApi.Get(item.OptionId);
                var option = _mapper.Map<OptionsViewModel>(optionsResult.Content.ResultData);
                item.Option = option;
            }

            foreach (var item in list)
            {
                var proResult = await _productApi.Get(item.ProductId);
                var product = _mapper.Map<ProductViewModel>(proResult.Content.ResultData);
                item.Product = product;
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

            #region ProductViewBag
            List<ProductViewModel> prolist = new List<ProductViewModel>();
            var prolistResult = await _productApi.GetActive();

            if (prolistResult.IsSuccessStatusCode &&
                prolistResult.Content.IsSuccess &&
                prolistResult.Content.ResultData.Any())
                prolist = _mapper.Map<List<ProductViewModel>>(prolistResult.Content.ResultData);

            ViewBag.Products = new SelectList(prolist, "Id", "ProductName");
            #endregion

            #region Options ViewBag
            List<OptionsViewModel> optionsList = new List<OptionsViewModel>();
            var optionListResult = await _optionsApi.GetActive();

            if (optionListResult.IsSuccessStatusCode &&
                optionListResult.Content.IsSuccess &&
                optionListResult.Content.ResultData.Any())
                optionsList = _mapper.Map<List<OptionsViewModel>>(optionListResult.Content.ResultData);


            ViewBag.Options = new SelectList(optionsList, "Id", "Title");
            #endregion

            //ViewData["parentProduct"] = id;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateOptionToProductViewModel item)
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

            #region ProductViewBag
            List<ProductViewModel> prolist = new List<ProductViewModel>();
            var prolistResult = await _productApi.GetActive();

            if (prolistResult.IsSuccessStatusCode &&
                prolistResult.Content.IsSuccess &&
                prolistResult.Content.ResultData.Any())
                prolist = _mapper.Map<List<ProductViewModel>>(prolistResult.Content.ResultData);

            ViewBag.Products = new SelectList(prolist, "Id", "ProductName");
            #endregion

            #region Options ViewBag
            List<OptionsViewModel> optionsList = new List<OptionsViewModel>();
            var optionListResult = await _optionsApi.GetActive();

            if (optionListResult.IsSuccessStatusCode &&
                optionListResult.Content.IsSuccess &&
                optionListResult.Content.ResultData.Any())
                optionsList = _mapper.Map<List<OptionsViewModel>>(optionListResult.Content.ResultData);


            ViewBag.Options = new SelectList(optionsList, "Id", "Title");
            #endregion
            //var parentProId = item.ParentProductId;


            if (ModelState.IsValid)
            {
                var insertResult = await _optionToProductApi.Post(_mapper.Map<OptionToProductRequest>(item));
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

            #region ProductViewBag
            List<ProductViewModel> prolist = new List<ProductViewModel>();
            var prolistResult = await _productApi.GetActive();

            if (prolistResult.IsSuccessStatusCode &&
                prolistResult.Content.IsSuccess &&
                prolistResult.Content.ResultData.Any())
                prolist = _mapper.Map<List<ProductViewModel>>(prolistResult.Content.ResultData);

            ViewBag.Products = new SelectList(prolist, "Id", "ProductName");
            #endregion

            #region Options ViewBag
            List<OptionsViewModel> optionsList = new List<OptionsViewModel>();
            var optionListResult = await _optionsApi.GetActive();

            if (optionListResult.IsSuccessStatusCode &&
                optionListResult.Content.IsSuccess &&
                optionListResult.Content.ResultData.Any())
                optionsList = _mapper.Map<List<OptionsViewModel>>(optionListResult.Content.ResultData);


            ViewBag.Options = new SelectList(optionsList, "Id", "Title");
            #endregion



            

            UpdateOptionToProductViewModel model = new UpdateOptionToProductViewModel();
            var updateResult = await _optionToProductApi.Get(id);
            if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                model = _mapper.Map<UpdateOptionToProductViewModel>(updateResult.Content.ResultData);

            ViewData["parentProduct"] = model.ParentProductId;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateOptionToProductViewModel item)
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

            #region ProductViewBag
            List<ProductViewModel> prolist = new List<ProductViewModel>();
            var prolistResult = await _productApi.GetActive();

            if (prolistResult.IsSuccessStatusCode &&
                prolistResult.Content.IsSuccess &&
                prolistResult.Content.ResultData.Any())
                prolist = _mapper.Map<List<ProductViewModel>>(prolistResult.Content.ResultData);

            ViewBag.Products = new SelectList(prolist, "Id", "ProductName");
            #endregion

            #region Options ViewBag
            List<OptionsViewModel> optionsList = new List<OptionsViewModel>();
            var optionListResult = await _optionsApi.GetActive();

            if (optionListResult.IsSuccessStatusCode &&
                optionListResult.Content.IsSuccess &&
                optionListResult.Content.ResultData.Any())
                optionsList = _mapper.Map<List<OptionsViewModel>>(optionListResult.Content.ResultData);


            ViewBag.Options = new SelectList(optionsList, "Id", "Title");
            #endregion
            //var parentProId = item.ParentProductId;
            if (ModelState.IsValid)
            {
                var updateResult = await _optionToProductApi.Put(item.Id, _mapper.Map<OptionToProductRequest>(item));
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
            var activatedResut = await _optionToProductApi.Activate(id);
          
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedResut = await _optionToProductApi.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            OptionToProductViewModel model = new OptionToProductViewModel();
            var result = await _optionToProductApi.Get(id);
            if (result.IsSuccessStatusCode && result.Content.IsSuccess && result.Content.ResultData != null)
                model = _mapper.Map<OptionToProductViewModel>(result.Content.ResultData);
            return View(model);
        }
    }
}
