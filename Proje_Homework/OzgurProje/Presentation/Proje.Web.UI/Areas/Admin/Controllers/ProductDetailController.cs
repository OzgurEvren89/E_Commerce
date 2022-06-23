using AutoMapper;
using Proje.Common.DTOs.ProductDetail;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.ProductDetailViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proje.Web.UI.Areas.Admin.Models.ProductViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Proje.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class ProductDetailController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IProductDetailApi _productDetailApi;
        private readonly IProductApi _productApi;
        private readonly IMapper _mapper;

        public ProductDetailController(IWebHostEnvironment env, IProductDetailApi productDetailApi, IProductApi productApi, IMapper mapper)
        {
            _env = env;
            _productDetailApi = productDetailApi;
            _productApi = productApi;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<ProductDetailViewModel> list = new List<ProductDetailViewModel>();
            var listResult = await _productDetailApi.List();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<ProductDetailViewModel>>(listResult.Content.ResultData);

            foreach (var item in list)
            {
                var productResult = await _productApi.Get(item.ProductId);
                var product = _mapper.Map<ProductViewModel>(productResult.Content.ResultData);
                item.Product = product;
            }

            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            #region Products ViewBag
            List<ProductViewModel> list = new List<ProductViewModel>();
            var listResult = await _productApi.GetActive();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<ProductViewModel>>(listResult.Content.ResultData);


            ViewBag.Products = new SelectList(list, "Id", "ProductName"); 
            #endregion

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateProductDetailViewModel item)
        {
            #region Products ViewBag
            List<ProductViewModel> list = new List<ProductViewModel>();
            var listResult = await _productApi.GetActive();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<ProductViewModel>>(listResult.Content.ResultData);


            ViewBag.Products = new SelectList(list, "Id", "ProductName");
            #endregion


            if (ModelState.IsValid)
            {
                var insertResult = await _productDetailApi.Post(_mapper.Map<ProductDetailRequest>(item));
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
            #region Products ViewBag
            List<ProductViewModel> list = new List<ProductViewModel>();
            var listResult = await _productApi.GetActive();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<ProductViewModel>>(listResult.Content.ResultData);


            ViewBag.Products = new SelectList(list, "Id", "ProductName");
            #endregion

            UpdateProductDetailViewModel model = new UpdateProductDetailViewModel();
            var updateResult = await _productDetailApi.Get(id);
            if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                model = _mapper.Map<UpdateProductDetailViewModel>(updateResult.Content.ResultData);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductDetailViewModel item)
        {
            #region Products ViewBag
            List<ProductViewModel> list = new List<ProductViewModel>();
            var listResult = await _productApi.GetActive();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<ProductViewModel>>(listResult.Content.ResultData);


            ViewBag.Products = new SelectList(list, "Id", "ProductName");
            #endregion

            if (ModelState.IsValid)
            {
                var updateResult = await _productDetailApi.Put(item.Id, _mapper.Map<ProductDetailRequest>(item));
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
            var activatedResut = await _productDetailApi.Activate(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedResut = await _productDetailApi.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            ProductDetailViewModel model = new ProductDetailViewModel();
            var result = await _productDetailApi.Get(id);
            if (result.IsSuccessStatusCode && result.Content.IsSuccess && result.Content.ResultData != null)
                model = _mapper.Map<ProductDetailViewModel>(result.Content.ResultData);
            return View(model);
        }
    }
}
