using AutoMapper;
using Proje.Common.DTOs.ProductImage;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.ProductImageViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Proje.Web.UI.Infrasructure.Helpers;
using Proje.Web.UI.Areas.Admin.Models.ProductViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Proje.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class ProductImageController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IProductImageApi _productImageApi;
        private readonly IProductApi _productApi;
        private readonly IMapper _mapper;

        public ProductImageController(IWebHostEnvironment env, IProductImageApi productImageApi, IProductApi productApi, IMapper mapper)
        {
            _env = env;
            _productImageApi = productImageApi;
            _productApi = productApi;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<ProductImageViewModel> list = new List<ProductImageViewModel>();
            var listResult = await _productImageApi.List();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<ProductImageViewModel>>(listResult.Content.ResultData);

            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            //-------------aktif olan product listemi viewbag'a alıyorum Product ID seçebilmek için. 
            List<ProductViewModel> list = new List<ProductViewModel>();
            var listResult = await _productApi.GetActive();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<ProductViewModel>>(listResult.Content.ResultData);

            ViewBag.Products = new SelectList(list, "Id", "ProductName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateProductImageViewModel item, List<IFormFile> files)
        {
            if (ModelState.IsValid)
            {
                bool imageResult;
                string imagePath = Upload.ImageUpload(files, _env, out imageResult);
                if (imageResult)
                    item.FileName = imagePath;
                else
                {
                    TempData["Message"] = imagePath;
                    return View();
                }
               
                //-----------------productImageyi yüklüyorum. 
                var insertResult = await _productImageApi.Post(_mapper.Map<ProductImageRequest>(item));
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
            List<ProductViewModel> list = new List<ProductViewModel>();
            var listResult = await _productApi.GetActive();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<ProductViewModel>>(listResult.Content.ResultData);

            ViewBag.Products = new SelectList(list, "Id", "ProductName");

            UpdateProductImageViewModel model = new UpdateProductImageViewModel();
            var updateResult = await _productImageApi.Get(id);
            if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                model = _mapper.Map<UpdateProductImageViewModel>(updateResult.Content.ResultData);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductImageViewModel item, List<IFormFile> files)
        {
            if (ModelState.IsValid)
            {
                bool imageResult;
                string imagePath = Upload.ImageUpload(files, _env, out imageResult);
                if (imageResult)
                    item.FileName = imagePath;
                else
                {
                    TempData["Message"] = imagePath;
                    return View();
                }

                var updateResult = await _productImageApi.Put(item.Id, _mapper.Map<ProductImageRequest>(item));
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
            var activatedResut = await _productImageApi.Activate(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedResut = await _productImageApi.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            ProductImageViewModel model = new ProductImageViewModel();
            var result = await _productImageApi.Get(id);
            if (result.IsSuccessStatusCode && result.Content.IsSuccess && result.Content.ResultData != null)
                model = _mapper.Map<ProductImageViewModel>(result.Content.ResultData);
            return View(model);
        }
    }
}
