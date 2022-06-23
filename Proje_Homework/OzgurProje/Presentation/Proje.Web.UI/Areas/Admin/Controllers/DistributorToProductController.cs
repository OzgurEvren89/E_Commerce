using AutoMapper;
using Proje.Common.DTOs.DistributorToProduct;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.DistributorToProductViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proje.Web.UI.Areas.Admin.Models.ProductViewModels;
using Proje.Web.UI.Areas.Admin.Models.DistributorViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Proje.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class DistributorToProductController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IDistributorToProductApi _distributorToProductApi;
        private readonly IDistributorApi _distributorApi;
        private readonly IProductApi _productApi;
        private readonly IMapper _mapper;

        public DistributorToProductController(IWebHostEnvironment env, IDistributorToProductApi distributorToProductApi, IDistributorApi distributorApi, IProductApi productApi, IMapper mapper)
        {
            _env = env;
            _distributorToProductApi = distributorToProductApi;
            _distributorApi = distributorApi;
            _productApi = productApi;
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<IActionResult> Index()
        {


            List<DistributorToProductViewModel> list = new List<DistributorToProductViewModel>();
            var listResult = await _distributorToProductApi.List();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<DistributorToProductViewModel>>(listResult.Content.ResultData);

            foreach (var item in list)
            {
                var productResult = await _productApi.Get(item.ProductId);
                var product = _mapper.Map<ProductViewModel>(productResult.Content.ResultData);
                item.Product = product;
            }

            foreach (var item in list)
            {
                var distributorResult = await _distributorApi.Get(item.DistributorId);
                var distributor = _mapper.Map<DistributorViewModel>(distributorResult.Content.ResultData);
                item.Distributor = distributor;
            }


            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Insert()
        {

            #region Product ViewBag

            List<ProductViewModel> list = new List<ProductViewModel>();
            var listResult = await _productApi.GetActive();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<ProductViewModel>>(listResult.Content.ResultData);

            ViewBag.Products = new SelectList(list, "Id", "ProductName");
            #endregion

            #region Distributor ViewBag

            List<DistributorViewModel> distList = new List<DistributorViewModel>();
            var distributorListResult = await _distributorApi.GetActive();

            if (distributorListResult.IsSuccessStatusCode &&
                distributorListResult.Content.IsSuccess &&
                distributorListResult.Content.ResultData.Any())
                distList = _mapper.Map<List<DistributorViewModel>>(distributorListResult.Content.ResultData);

            ViewBag.Distributors = new SelectList(distList, "Id", "Name"); 
            #endregion

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateDistributorToProductViewModel item)
        {
            #region Product ViewBag

            List<ProductViewModel> list = new List<ProductViewModel>();
            var listResult = await _productApi.GetActive();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<ProductViewModel>>(listResult.Content.ResultData);

            ViewBag.Products = new SelectList(list, "Id", "ProductName");
            #endregion

            #region Distributor ViewBag

            List<DistributorViewModel> distList = new List<DistributorViewModel>();
            var distributorListResult = await _distributorApi.GetActive();

            if (distributorListResult.IsSuccessStatusCode &&
                distributorListResult.Content.IsSuccess &&
                distributorListResult.Content.ResultData.Any())
                distList = _mapper.Map<List<DistributorViewModel>>(distributorListResult.Content.ResultData);

            ViewBag.Distributors = new SelectList(distList, "Id", "Name");
            #endregion

            if (ModelState.IsValid)
            {
                var insertResult = await _distributorToProductApi.Post(_mapper.Map<DistributorToProductRequest>(item));
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
            #region Product ViewBag

            List<ProductViewModel> list = new List<ProductViewModel>();
            var listResult = await _productApi.GetActive();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<ProductViewModel>>(listResult.Content.ResultData);

            ViewBag.Products = new SelectList(list, "Id", "ProductName");
            #endregion

            #region Distributor ViewBag

            List<DistributorViewModel> distList = new List<DistributorViewModel>();
            var distributorListResult = await _distributorApi.GetActive();

            if (distributorListResult.IsSuccessStatusCode &&
                distributorListResult.Content.IsSuccess &&
                distributorListResult.Content.ResultData.Any())
                distList = _mapper.Map<List<DistributorViewModel>>(distributorListResult.Content.ResultData);

            ViewBag.Distributors = new SelectList(distList, "Id", "Name");
            #endregion

            UpdateDistributorToProductViewModel model = new UpdateDistributorToProductViewModel();
            var updateResult = await _distributorToProductApi.Get(id);
            if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                model = _mapper.Map<UpdateDistributorToProductViewModel>(updateResult.Content.ResultData);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateDistributorToProductViewModel item)
        {
            #region Product ViewBag

            List<ProductViewModel> list = new List<ProductViewModel>();
            var listResult = await _productApi.GetActive();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<ProductViewModel>>(listResult.Content.ResultData);

            ViewBag.Products = new SelectList(list, "Id", "ProductName");
            #endregion

            #region Distributor ViewBag

            List<DistributorViewModel> distList = new List<DistributorViewModel>();
            var distributorListResult = await _distributorApi.GetActive();

            if (distributorListResult.IsSuccessStatusCode &&
                distributorListResult.Content.IsSuccess &&
                distributorListResult.Content.ResultData.Any())
                distList = _mapper.Map<List<DistributorViewModel>>(distributorListResult.Content.ResultData);

            ViewBag.Distributors = new SelectList(distList, "Id", "Name");
            #endregion

            if (ModelState.IsValid)
            {
                var updateResult = await _distributorToProductApi.Put(item.Id, _mapper.Map<DistributorToProductRequest>(item));
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
            var activatedResut = await _distributorToProductApi.Activate(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedResut = await _distributorToProductApi.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            DistributorToProductViewModel model = new DistributorToProductViewModel();
            var result = await _distributorToProductApi.Get(id);
            if (result.IsSuccessStatusCode && result.Content.IsSuccess && result.Content.ResultData != null)
                model = _mapper.Map<DistributorToProductViewModel>(result.Content.ResultData);
            return View(model);
        }
    }
}
