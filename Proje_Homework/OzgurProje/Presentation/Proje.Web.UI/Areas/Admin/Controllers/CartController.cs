using AutoMapper;
using Proje.Common.DTOs.Cart;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.CartViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proje.Web.UI.Areas.Admin.Models.CartItemViewModels;
using Proje.Web.UI.Areas.Admin.Models.ProductViewModels;

namespace Proje.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class CartController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly ICartApi _cartApi;
        private readonly ICartItemApi _cartItemApi;
        private readonly IProductApi _productApi;
        private readonly IMapper _mapper;

        public CartController(IWebHostEnvironment env, ICartApi cartApi, ICartItemApi cartItemApi, IProductApi productApi, IMapper mapper)
        {
            _env = env;
            _cartApi = cartApi;
            _cartItemApi = cartItemApi;
            _productApi = productApi;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<CartViewModel> list = new List<CartViewModel>();
            var listResult = await _cartApi.List();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<CartViewModel>>(listResult.Content.ResultData);          

          List <CartItemViewModel> cartItemViewModels = new List<CartItemViewModel>();
            var listResultCartItems = await _cartItemApi.GetActive();//aktif olan brand to categoryleri çağırdım önce. 
            if (listResultCartItems.IsSuccessStatusCode && listResultCartItems.Content.IsSuccess && listResultCartItems.Content.ResultData.Any())
                cartItemViewModels = _mapper.Map<List<CartItemViewModel>>(listResultCartItems.Content.ResultData);
            foreach (var item in list)
            {
                item.CartItems = cartItemViewModels.Where(x => x.CartId == item.Id).ToList();// Cart'a CartItem Listelerini atadım.
                foreach (var cartItem in item.CartItems)
                {
                    ProductViewModel product = new ProductViewModel();
                    var proResult = await _productApi.Get(cartItem.ProductId);
                    if (proResult.IsSuccessStatusCode && proResult.Content.IsSuccess)
                        product = _mapper.Map<ProductViewModel>(proResult.Content.ResultData);

                    cartItem.Product = product;// her bir cartitem'ın product'unu atadım
                }
            }

            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateCartViewModel item)
        {
            if (ModelState.IsValid)
            {
                var insertResult = await _cartApi.Post(_mapper.Map<CartRequest>(item));
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
            UpdateCartViewModel model = new UpdateCartViewModel();
            var updateResult = await _cartApi.Get(id);
            if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                model = _mapper.Map<UpdateCartViewModel>(updateResult.Content.ResultData);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCartViewModel item)
        {
            if (ModelState.IsValid)
            {
                var updateResult = await _cartApi.Put(item.Id, _mapper.Map<CartRequest>(item));
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
            var activatedResut = await _cartApi.Activate(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedResut = await _cartApi.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            CartViewModel model = new CartViewModel();
            var result = await _cartApi.Get(id);
            if (result.IsSuccessStatusCode && result.Content.IsSuccess && result.Content.ResultData != null)
                model = _mapper.Map<CartViewModel>(result.Content.ResultData);
            return View(model);
        }
    }
}
