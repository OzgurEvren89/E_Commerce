using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Proje.Common.DTOs.ProductComment;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.ProductCommentViewModels;
using Proje.Web.UI.Areas.Admin.Models.ProductImageViewModels;
using Proje.Web.UI.Areas.Admin.Models.ProductViewModels;
using Proje.Web.UI.Areas.Admin.Models.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Controllers
{
    public class ProductCommentController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IProductApi _productApi;
        private readonly IProductImageApi _productImageApi;
        private readonly IProductCommentApi _productCommentApi;
        private readonly IUserApi _userApi;
        private readonly IMapper _mapper;

        public ProductCommentController(IWebHostEnvironment env, IProductApi productApi, IProductImageApi productImageApi, IProductCommentApi productCommentApi, IUserApi userApi, IMapper mapper)
        {
            _env = env;
            _productApi = productApi;
            _productImageApi = productImageApi;
            _productCommentApi = productCommentApi;
            _userApi = userApi;
            _mapper = mapper;
        }






        [HttpGet]
        public async Task<IActionResult> Insert(Guid Id)
        {
            ProductViewModel model = new ProductViewModel();
            var result = await _productApi.Get(Id);
            if (result.IsSuccessStatusCode && result.Content.IsSuccess && result.Content.ResultData != null)
                model = _mapper.Map<ProductViewModel>(result.Content.ResultData);

            #region Ürüne Resimleri Yükledim İhtiyaç Halinde Kullanmak için 
            List<ProductImageViewModel> imagesViewModels = new List<ProductImageViewModel>();
            var listResultimages = await _productImageApi.GetActive();
            if (listResultimages.IsSuccessStatusCode && listResultimages.Content.IsSuccess && listResultimages.Content.ResultData.Any())
                imagesViewModels = _mapper.Map<List<ProductImageViewModel>>(listResultimages.Content.ResultData);

            model.ProductImages = imagesViewModels.Where(x => x.ProductId == model.Id).ToList(); 
            #endregion

            ViewData["product"] = model;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateProductCommentViewModel item)
        {
            UserViewModel user = new UserViewModel();
            var userResult = await _userApi.GetCartUser();
            if (userResult.IsSuccessStatusCode && userResult.Content.IsSuccess)
                user = _mapper.Map<UserViewModel>(userResult.Content.ResultData);
            
            item.UserId = user.Id;

            if (ModelState.IsValid)
            {
                var insertResult = await _productCommentApi.Post(_mapper.Map<ProductCommentRequest>(item));
                if (insertResult.IsSuccessStatusCode && insertResult.Content.IsSuccess && insertResult.Content.ResultData != null)
                    return RedirectToAction("Index", "Home");
                else
                    TempData["Message"] = "Kayıt işlemi sırasında bir hata oluştu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";
            }
            else
                TempData["Message"] = "İşlem başarısız oldu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";
            return View();
        }

        
    }
}
