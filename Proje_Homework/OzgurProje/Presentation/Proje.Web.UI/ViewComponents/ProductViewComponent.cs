using AutoMapper;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.ProductViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proje.Web.UI.Areas.Admin.Models.ProductImageViewModels;

namespace Proje.Web.UI.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        private readonly IProductApi _productApi;
        private readonly IProductImageApi _productimageApi;
        private readonly IMapper _mapper;

        public ProductViewComponent(IProductApi productApi, IProductImageApi productimageApi, IMapper mapper)
        {
            _productApi = productApi;
            _productimageApi = productimageApi;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<ProductViewModel> list = new List<ProductViewModel>();
            var listResult = await _productApi.GetActive();
            if (listResult.IsSuccessStatusCode && listResult.Content.IsSuccess && listResult.Content.ResultData.Any())
                list = _mapper.Map<List<ProductViewModel>>(listResult.Content.ResultData);

            //herbir product'a ait productImage'leri listelemek için aşağıdaki kodu yazdım. 
            List<ProductImageViewModel> imagesViewModels = new List<ProductImageViewModel>();
            var listResultimages= await _productimageApi.GetActive();//aktif olanlar
            if (listResultimages.IsSuccessStatusCode && listResultimages.Content.IsSuccess && listResultimages.Content.ResultData.Any())
                imagesViewModels = _mapper.Map<List<ProductImageViewModel>>(listResultimages.Content.ResultData);

            //List<ProductPriceViewModel> pricesViewModels = new List<ProductPriceViewModel>();
            //var listResulProducts = await _productPriceApi.GetActive();//aktif olanlar
            //if (listResulProducts.IsSuccessStatusCode && listResulProducts.Content.IsSuccess && listResulProducts.Content.ResultData.Any())
            //    pricesViewModels = _mapper.Map<List<ProductPriceViewModel>>(listResulProducts.Content.ResultData);

            foreach (var item in list)
            {
                item.ProductImages = imagesViewModels.Where(x => x.ProductId == item.Id).ToList();
            }
            //------------------------------------------------------------------------------------
            return View(list);
        }
    }
}
