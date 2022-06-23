using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.ProductImageViewModels;
using Proje.Web.UI.Areas.Admin.Models.ProductViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Controllers
{
    public class ProductDetailController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IProductApi _productApi;    
        private readonly IProductImageApi _productImageApi;    
        private readonly IMapper _mapper;

        public ProductDetailController(IWebHostEnvironment env, IProductApi productApi, IProductImageApi productImageApi, IMapper mapper)
        {
            _env = env;
            _productApi = productApi;
            _productImageApi = productImageApi;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductPropertiesViewComponent(Guid id)
        {
            return ViewComponent("ProductProperties", new { id = id });
        }

        public IActionResult InstallmentRateViewComponent(Guid id)
        {
            return ViewComponent("InstallmentRate", new { id = id });
        }

        public IActionResult ProductDetailViewComponent(Guid id)
        {
            return ViewComponent("ProductDetail", new { id = id });
        }

        public IActionResult OptionToProductViewComponent(Guid id)
        {
            return ViewComponent("OptionToProduct", new { id = id });
        }

        public IActionResult ProductCommentViewComponent(Guid id)
        {
            return ViewComponent("ProductComment", new { id = id });
        }

        public async Task<IActionResult> ProductDetails(Guid id)
        {
            ProductViewModel model = new ProductViewModel();
            var result = await _productApi.Get(id);
            if (result.IsSuccessStatusCode && result.Content.IsSuccess && result.Content.ResultData != null)
                model = _mapper.Map<ProductViewModel>(result.Content.ResultData);


            //herbir product'a ait productImage'leri listelemek için aşağıdaki kodu yazdım. 
            List<ProductImageViewModel> imagesViewModels = new List<ProductImageViewModel>();
            var listResultimages = await _productImageApi.GetActive();//aktif olanlar
            if (listResultimages.IsSuccessStatusCode && listResultimages.Content.IsSuccess && listResultimages.Content.ResultData.Any())
                imagesViewModels = _mapper.Map<List<ProductImageViewModel>>(listResultimages.Content.ResultData);

            model.ProductImages = imagesViewModels.Where(x => x.ProductId == model.Id).ToList();

            return View(model);
        }
      
    }
}
