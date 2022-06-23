using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Proje.Common.DTOs.FavouritedProduct;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.FavouritedProductViewModels;
using Proje.Web.UI.Areas.Admin.Models.ProductImageViewModels;
using Proje.Web.UI.Areas.Admin.Models.ProductViewModels;
using Proje.Web.UI.Areas.Admin.Models.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Controllers
{
    public class FavouriteController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IFavouritedProductApi _favouritedProductApi;
        private readonly IProductApi _productApi;
        private readonly IProductImageApi _productImageApi;
        private readonly IUserApi _userApi;
        private readonly IMapper _mapper;

        public FavouriteController(IWebHostEnvironment env, IFavouritedProductApi favouritedProductApi, IProductApi productApi, IProductImageApi productImageApi, IUserApi userApi, IMapper mapper)
        {
            _env = env;
            _favouritedProductApi = favouritedProductApi;
            _productApi = productApi;
            _productImageApi = productImageApi;
            _userApi = userApi;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            UserViewModel user = new UserViewModel();
            var userResult = await _userApi.GetCartUser();
            if (userResult.IsSuccessStatusCode && userResult.Content.IsSuccess)
                user = _mapper.Map<UserViewModel>(userResult.Content.ResultData);


            if (user == null || user.Id == null || user.Id == Guid.Empty)
            {
                TempData["Message"] = "Sepete Girebilmeniz içn önce giriş yapmanız gerekmektedir!...Hesabınız yok ise lütfen kayıt olup tekrar deneyiniz...";
                return RedirectToAction("Login", "Account");
            }


            List<FavouritedProductViewModel> favtoprolist = new List<FavouritedProductViewModel>();
            var favtoprolistResult = await _favouritedProductApi.GetForUser();//sadece login olan kullanıcının favori ürünleri gelecek


            if (favtoprolistResult.IsSuccessStatusCode &&
                favtoprolistResult.Content.IsSuccess &&
                favtoprolistResult.Content.ResultData.Any())
                favtoprolist = _mapper.Map<List<FavouritedProductViewModel>>(favtoprolistResult.Content.ResultData);
           favtoprolist  =  favtoprolist.Where(x => x.Status == Common.Enums.Status.Active || x.Status == Common.Enums.Status.None).ToList();

            List<ProductViewModel> prolist = new List<ProductViewModel>();
            var prolistResult = await _productApi.List();

            if (prolistResult.IsSuccessStatusCode &&
                prolistResult.Content.IsSuccess &&
                prolistResult.Content.ResultData.Any())
                prolist = _mapper.Map<List<ProductViewModel>>(prolistResult.Content.ResultData);

            //#region ProductPrices
            //List<ProductPriceViewModel> productPrices = new List<ProductPriceViewModel>();

            //var listResulProPrices = await _productPriceApi.GetActive(); 
            //if (listResulProPrices.IsSuccessStatusCode && listResulProPrices.Content.IsSuccess && listResulProPrices.Content.ResultData.Any())
            //    productPrices = _mapper.Map<List<ProductPriceViewModel>>(listResulProPrices.Content.ResultData);

            //foreach (var item in prolist)
            //{
            //    item.ProductPrices = productPrices.Where(x => x.ProductId == item.Id).ToList();
            //}

            //#endregion

            #region ProductImages
            List<ProductImageViewModel> productImages = new List<ProductImageViewModel>();
            var listResulProImages = await _productImageApi.GetActive();//aktif olan brand to categoryleri çağırdım önce. 
            if (listResulProImages.IsSuccessStatusCode && listResulProImages.Content.IsSuccess && listResulProImages.Content.ResultData.Any())
                productImages = _mapper.Map<List<ProductImageViewModel>>(listResulProImages.Content.ResultData);

            foreach (var item in prolist)
            {
                item.ProductImages = productImages.Where(x => x.ProductId == item.Id).ToList();
            }

            #endregion


            foreach (var item in favtoprolist)
            {
                item.Product = prolist.FirstOrDefault(x => x.Id == item.ProductId);
            }

            return View(favtoprolist);
        }


        [HttpGet]
        public async Task<IActionResult> Insert(Guid Id)
        {


            #region Ürünü önceden eklediysem eklemiyecek

            List<FavouritedProductViewModel> favtoprolist = new List<FavouritedProductViewModel>();
            var favtoprolistResult = await _favouritedProductApi.GetForUser();//sadece login olan kullanıcının favori ürünleri gelecek

            if (favtoprolistResult.IsSuccessStatusCode &&
                favtoprolistResult.Content.IsSuccess &&
                favtoprolistResult.Content.ResultData.Any())
                favtoprolist = _mapper.Map<List<FavouritedProductViewModel>>(favtoprolistResult.Content.ResultData);

            foreach (var favtopro in favtoprolist)
            {
                if (favtopro.ProductId == Id && favtopro.Status!= Common.Enums.Status.Deleted)
                {
                    TempData["Message"] = "Bu ürün favorinizde bulunmaktadır.";
                    return RedirectToAction("Index", "Favourite");
                }
            }
            #endregion

            CreateFavouritedProductViewModel item = new CreateFavouritedProductViewModel();
            item.ProductId = Id;

            if (ModelState.IsValid)
            {

                var insertResult = await _favouritedProductApi.Post(_mapper.Map<FavouritedProductRequest>(item));
                if (insertResult.IsSuccessStatusCode && insertResult.Content.IsSuccess && insertResult.Content.ResultData != null)
                    return RedirectToAction("Index", "Favourite");
                else
                    TempData["Message"] = "Kayıt işlemi sırasında bir hata oluştu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";
            }
            else
                TempData["Message"] = "İşlem başarısız oldu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid Id)
        {
           
            var deletedResut = await _favouritedProductApi.Delete(Id);
            return RedirectToAction("Index", "Favourite");
        }
    }
}
