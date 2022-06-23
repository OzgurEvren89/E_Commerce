using AutoMapper;
using Proje.Common.DTOs.CartItem;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.CartItemViewModels;
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
    public class CartItemController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly ICartItemApi _cartItemApi;
        private readonly IProductApi _productApi;
        private readonly IMapper _mapper;

        public CartItemController(IWebHostEnvironment env, ICartItemApi cartItemApi, IProductApi productApi, IMapper mapper)
        {
            _env = env;
            _cartItemApi = cartItemApi;
            _productApi = productApi;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<CartItemViewModel> list = new List<CartItemViewModel>();
            var listResult = await _cartItemApi.List();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<CartItemViewModel>>(listResult.Content.ResultData);

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
        public async Task<IActionResult> Insert(CreateCartItemViewModel item)
        {
            if (ModelState.IsValid)
            {
                var insertResult = await _cartItemApi.Post(_mapper.Map<CartItemRequest>(item));
                if (insertResult.IsSuccessStatusCode && insertResult.Content.IsSuccess && insertResult.Content.ResultData != null)
                    return RedirectToAction("Index");
                else
                    TempData["Message"] = "Kayıt işlemi sırasında bir hata oluştu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";
            }
            else
                TempData["Message"] = "İşlem başarısız oldu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";


            List<ProductViewModel> list = new List<ProductViewModel>();
            var listResult = await _productApi.GetActive();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<ProductViewModel>>(listResult.Content.ResultData);

            ViewBag.Products = new SelectList(list, "Id", "ProductName");

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            UpdateCartItemViewModel model = new UpdateCartItemViewModel();
            var updateResult = await _cartItemApi.Get(id);
            if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                model = _mapper.Map<UpdateCartItemViewModel>(updateResult.Content.ResultData);

            List<ProductViewModel> list = new List<ProductViewModel>();
            var listResult = await _productApi.GetActive();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<ProductViewModel>>(listResult.Content.ResultData);

            ViewBag.Products = new SelectList(list, "Id", "ProductName");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCartItemViewModel item)
        {
            if (ModelState.IsValid)
            {
                var updateResult = await _cartItemApi.Put(item.Id, _mapper.Map<CartItemRequest>(item));
                if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                    return RedirectToAction("Index");
                else
                    TempData["Message"] = "Güncelleme işlemi sırasında bir hata oluştu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";
            }
            else
                TempData["Message"] = "İşlem başarısız oldu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";


            List<ProductViewModel> list = new List<ProductViewModel>();
            var listResult = await _productApi.GetActive();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<ProductViewModel>>(listResult.Content.ResultData);

            ViewBag.Products = new SelectList(list, "Id", "ProductName");

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Activate(Guid id)
        {
            var activatedResut = await _cartItemApi.Activate(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedResut = await _cartItemApi.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            CartItemViewModel model = new CartItemViewModel();
            var result = await _cartItemApi.Get(id);
            if (result.IsSuccessStatusCode && result.Content.IsSuccess && result.Content.ResultData != null)
                model = _mapper.Map<CartItemViewModel>(result.Content.ResultData);
            return View(model);
        }
    }
}
