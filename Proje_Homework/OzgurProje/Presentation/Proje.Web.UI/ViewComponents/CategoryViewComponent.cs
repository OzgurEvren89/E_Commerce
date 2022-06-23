using AutoMapper;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.CategoryViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Proje.Web.UI.Areas.Admin.Models.BrandToCategoryViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Proje.Web.UI.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly ICategoryApi _categoryApi;
        private readonly IBrandToCategoryApi _brandtocategoryApi;
        private readonly IMapper _mapper;

        public CategoryViewComponent(ICategoryApi categoryApi, IBrandToCategoryApi brandtocategoryApi, IMapper mapper)
        {
            _categoryApi = categoryApi;
            _brandtocategoryApi = brandtocategoryApi;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<CategoryViewModel> list = new List<CategoryViewModel>();
            var listResult = await _categoryApi.GetActive();
            if (listResult.IsSuccessStatusCode && listResult.Content.IsSuccess && listResult.Content.ResultData.Any())
                list = _mapper.Map<List<CategoryViewModel>>(listResult.Content.ResultData);
            //herbir kategoriye ait markaları listelemek için aşağıdaki kodu yazdım. 
            List<BrandToCategoryViewModel> brandToCategoryViewModels = new List<BrandToCategoryViewModel>();
            var listResultbrandtocategory = await _brandtocategoryApi.GetActive();//aktif olan brand to categoryleri çağırdım önce. 
            if (listResultbrandtocategory.IsSuccessStatusCode && listResultbrandtocategory.Content.IsSuccess && listResultbrandtocategory.Content.ResultData.Any())
                brandToCategoryViewModels = _mapper.Map<List<BrandToCategoryViewModel>>(listResultbrandtocategory.Content.ResultData);
            foreach (var item in list)
            {
                item.BrandToCategories = brandToCategoryViewModels.Where(x => x.CategoryId == item.Id).ToList();//kategorilerime sırayla tanımlıyorum brandtocategories propertlerini. 
            }
            //BrandToCategoryViewModel brandToCategory = new  BrandToCategoryViewModel();

            return View(list);
        }
    }
}
