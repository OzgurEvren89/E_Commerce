using AutoMapper;
using Proje.Common.DTOs.SpecToProduct;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.SpecToProductViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proje.Web.UI.Areas.Admin.Models.SpecNameViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proje.Web.UI.Areas.Admin.Models.SpecGroupViewModels;
using Proje.Web.UI.Areas.Admin.Models.SpecValueViewModels;
using Proje.Web.UI.Areas.Admin.Models.ProductViewModels;

namespace Proje.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class SpecToProductController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly ISpecToProductApi _specToProductApi;
        private readonly ISpecGroupApi _specGroupApi;
        private readonly ISpecNameApi _specNameApi;
        private readonly ISpecValueApi _specValueApi;
        private readonly IProductApi _productApi;
        private readonly IMapper _mapper;

        public SpecToProductController(IWebHostEnvironment env, ISpecToProductApi specToProductApi, ISpecGroupApi specGroupApi, ISpecNameApi specNameApi, ISpecValueApi specValueApi, IProductApi productApi, IMapper mapper)
        {
            _env = env;
            _specToProductApi = specToProductApi;
            _specGroupApi = specGroupApi;
            _specNameApi = specNameApi;
            _specValueApi = specValueApi;
            _productApi = productApi;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<SpecToProductViewModel> list = new List<SpecToProductViewModel>();
            var listResult = await _specToProductApi.List();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<SpecToProductViewModel>>(listResult.Content.ResultData);

            //Nesneyi Listelerken Tek Tek ForeigKeylerini Tanımlama
            foreach (var item in list)
            {
                var productResult = await _productApi.Get(item.ProductId);
                var product = _mapper.Map<ProductViewModel>(productResult.Content.ResultData);
                item.Product = product;
            }

            foreach (var item in list)
            {
                var specNameResult = await _specNameApi.Get(item.SpecNameId);
                var specName = _mapper.Map<SpecNameViewModel>(specNameResult.Content.ResultData);
                item.SpecName = specName;
            }

            foreach (var item in list)
            {
                var specGroupResult = await _specGroupApi.Get(item.SpecGroupId);
                var specGroup = _mapper.Map<SpecGroupViewModel>(specGroupResult.Content.ResultData);
                item.SpecGroup = specGroup;
            }

            foreach (var item in list)
            {
                var specValueResult = await _specValueApi.Get(item.SpecValueId);
                var specValue = _mapper.Map<SpecValueViewModel>(specValueResult.Content.ResultData);
                item.SpecValue = specValue;
            }
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Insert()
        {

            #region ForeignKeyList
            List<SpecValueViewModel> valuelist = new List<SpecValueViewModel>();
            var specValueResult = await _specValueApi.GetActive();

            if (specValueResult.IsSuccessStatusCode &&
                specValueResult.Content.IsSuccess &&
                specValueResult.Content.ResultData.Any())
                valuelist = _mapper.Map<List<SpecValueViewModel>>(specValueResult.Content.ResultData);

            ViewBag.SpecValues = new SelectList(valuelist, "Id", "Name");

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

            List<ProductViewModel> prolist = new List<ProductViewModel>();
            var productResult = await _productApi.GetActive();

            if (productResult.IsSuccessStatusCode &&
                productResult.Content.IsSuccess &&
                productResult.Content.ResultData.Any())
                prolist = _mapper.Map<List<ProductViewModel>>(productResult.Content.ResultData);


            ViewBag.Products = new SelectList(prolist, "Id", "ProductName"); 
            #endregion

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateSpecToProductViewModel item)
        {
            if (ModelState.IsValid)
            {
                var insertResult = await _specToProductApi.Post(_mapper.Map<SpecToProductRequest>(item));
                if (insertResult.IsSuccessStatusCode && insertResult.Content.IsSuccess && insertResult.Content.ResultData != null)
                    return RedirectToAction("Index");
                else
                    TempData["Message"] = "Kayıt işlemi sırasında bir hata oluştu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";
            }
            else
                TempData["Message"] = "İşlem başarısız oldu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";

            #region ForeignKeyList
            List<SpecValueViewModel> valuelist = new List<SpecValueViewModel>();
            var specValueResult = await _specValueApi.GetActive();

            if (specValueResult.IsSuccessStatusCode &&
                specValueResult.Content.IsSuccess &&
                specValueResult.Content.ResultData.Any())
                valuelist = _mapper.Map<List<SpecValueViewModel>>(specValueResult.Content.ResultData);

            ViewBag.SpecValues = new SelectList(valuelist, "Id", "Name");

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

            List<ProductViewModel> prolist = new List<ProductViewModel>();
            var productResult = await _productApi.GetActive();

            if (productResult.IsSuccessStatusCode &&
                productResult.Content.IsSuccess &&
                productResult.Content.ResultData.Any())
                prolist = _mapper.Map<List<ProductViewModel>>(productResult.Content.ResultData);


            ViewBag.Products = new SelectList(prolist, "Id", "ProductName");
            #endregion

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            UpdateSpecToProductViewModel model = new UpdateSpecToProductViewModel();
            var updateResult = await _specToProductApi.Get(id);
            if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                model = _mapper.Map<UpdateSpecToProductViewModel>(updateResult.Content.ResultData);

            #region ForeignKeyList
            List<SpecValueViewModel> valuelist = new List<SpecValueViewModel>();
            var specValueResult = await _specValueApi.GetActive();

            if (specValueResult.IsSuccessStatusCode &&
                specValueResult.Content.IsSuccess &&
                specValueResult.Content.ResultData.Any())
                valuelist = _mapper.Map<List<SpecValueViewModel>>(specValueResult.Content.ResultData);

            ViewBag.SpecValues = new SelectList(valuelist, "Id", "Name");

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

            List<ProductViewModel> prolist = new List<ProductViewModel>();
            var productResult = await _productApi.GetActive();

            if (productResult.IsSuccessStatusCode &&
                productResult.Content.IsSuccess &&
                productResult.Content.ResultData.Any())
                prolist = _mapper.Map<List<ProductViewModel>>(productResult.Content.ResultData);


            ViewBag.Products = new SelectList(prolist, "Id", "ProductName");
            #endregion

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateSpecToProductViewModel item)
        {
            if (ModelState.IsValid)
            {
                var updateResult = await _specToProductApi.Put(item.Id, _mapper.Map<SpecToProductRequest>(item));
                if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                    return RedirectToAction("Index");
                else
                    TempData["Message"] = "Güncelleme işlemi sırasında bir hata oluştu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";
            }
            else
                TempData["Message"] = "İşlem başarısız oldu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";

            #region ForeignKeyList
            List<SpecValueViewModel> valuelist = new List<SpecValueViewModel>();
            var specValueResult = await _specValueApi.GetActive();

            if (specValueResult.IsSuccessStatusCode &&
                specValueResult.Content.IsSuccess &&
                specValueResult.Content.ResultData.Any())
                valuelist = _mapper.Map<List<SpecValueViewModel>>(specValueResult.Content.ResultData);

            ViewBag.SpecValues = new SelectList(valuelist, "Id", "Name");

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

            List<ProductViewModel> prolist = new List<ProductViewModel>();
            var productResult = await _productApi.GetActive();

            if (productResult.IsSuccessStatusCode &&
                productResult.Content.IsSuccess &&
                productResult.Content.ResultData.Any())
                prolist = _mapper.Map<List<ProductViewModel>>(productResult.Content.ResultData);


            ViewBag.Products = new SelectList(prolist, "Id", "ProductName");
            #endregion

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Activate(Guid id)
        {
            var activatedResut = await _specToProductApi.Activate(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedResut = await _specToProductApi.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            SpecToProductViewModel model = new SpecToProductViewModel();
            var result = await _specToProductApi.Get(id);
            if (result.IsSuccessStatusCode && result.Content.IsSuccess && result.Content.ResultData != null)
                model = _mapper.Map<SpecToProductViewModel>(result.Content.ResultData);
            return View(model);
        }
    }
}
