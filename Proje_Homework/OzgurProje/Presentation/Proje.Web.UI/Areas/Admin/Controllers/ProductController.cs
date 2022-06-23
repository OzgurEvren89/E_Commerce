using AutoMapper;
using Proje.Common.DTOs.Product;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.ProductViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proje.Web.UI.Areas.Admin.Models.ProductImageViewModels;

namespace Proje.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IProductApi _productApi;
        private readonly IProductImageApi _productimageApi;
        private readonly IMapper _mapper;

        public ProductController(IWebHostEnvironment env, IProductApi productApi, IProductImageApi productimageApi, IMapper mapper)
        {
            _env = env;
            _productApi = productApi;
            _productimageApi = productimageApi;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<ProductViewModel> list = new List<ProductViewModel>();
            var listResult = await _productApi.List();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<ProductViewModel>>(listResult.Content.ResultData);

            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateProductViewModel item)
        {
            if (ModelState.IsValid)
            {
                var insertResult = await _productApi.Post(_mapper.Map<ProductRequest>(item));
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
            UpdateProductViewModel model = new UpdateProductViewModel();
            var updateResult = await _productApi.Get(id);
            if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                model = _mapper.Map<UpdateProductViewModel>(updateResult.Content.ResultData);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductViewModel item)
        {
            if (ModelState.IsValid)
            {
                var updateResult = await _productApi.Put(item.Id, _mapper.Map<ProductRequest>(item));
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
            var activatedResut = await _productApi.Activate(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedResut = await _productApi.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            ProductViewModel model = new ProductViewModel();
            var result = await _productApi.Get(id);
            if (result.IsSuccessStatusCode && result.Content.IsSuccess && result.Content.ResultData != null)
                model = _mapper.Map<ProductViewModel>(result.Content.ResultData);

            //herbir product'a ait productImage'leri listelemek için aşağıdaki kodu yazdım. 
            List<ProductImageViewModel> imagesViewModels = new List<ProductImageViewModel>();
            var listResultimages = await _productimageApi.GetActive();
            if (listResultimages.IsSuccessStatusCode && listResultimages.Content.IsSuccess && listResultimages.Content.ResultData.Any())
                imagesViewModels = _mapper.Map<List<ProductImageViewModel>>(listResultimages.Content.ResultData);

            model.ProductImages = imagesViewModels.Where(x => x.ProductId == model.Id).ToList();

            return View(model);

        }
    }
}
