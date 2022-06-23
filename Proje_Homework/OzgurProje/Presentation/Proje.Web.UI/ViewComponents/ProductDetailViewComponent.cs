using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.ProductDetailViewModels;
using Proje.Web.UI.Areas.Admin.Models.ProductViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.ViewComponents
{
    public class ProductDetailViewComponent : ViewComponent
    {
        private readonly IProductDetailApi _productDetailApi;
        private readonly IProductApi _productApi;
        private readonly IMapper _mapper;

        public ProductDetailViewComponent(IProductDetailApi productDetailApi, IProductApi productApi, IMapper mapper)
        {
            _productDetailApi = productDetailApi;
            _productApi = productApi;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid Id)//product Id'den bulacağız detayları
        {
            //ProductViewModel product = new ProductViewModel();
            //var proResult = await _productApi.Get(Id);

            List<ProductDetailViewModel> list = new List<ProductDetailViewModel>();
            var listResult = await _productDetailApi.GetActive();
            if (listResult.IsSuccessStatusCode && listResult.Content.IsSuccess && listResult.Content.ResultData.Any())
                list = _mapper.Map<List<ProductDetailViewModel>>(listResult.Content.ResultData);
            list = list.Where(x => x.ProductId == Id).ToList();

            return View(list);
        }

    }
}
