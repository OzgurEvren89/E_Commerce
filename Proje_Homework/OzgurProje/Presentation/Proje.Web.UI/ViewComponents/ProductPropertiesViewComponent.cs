using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.ProductViewModels;
using Proje.Web.UI.Areas.Admin.Models.SpecGroupViewModels;
using Proje.Web.UI.Areas.Admin.Models.SpecNameViewModels;
using Proje.Web.UI.Areas.Admin.Models.SpecToProductViewModels;
using Proje.Web.UI.Areas.Admin.Models.SpecValueViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.ViewComponents
{
    public class ProductPropertiesViewComponent : ViewComponent
    {
        private readonly ISpecToProductApi _specToProductdApi;
        private readonly ISpecGroupApi _specGroupApi;
        private readonly ISpecNameApi _specNameApi;
        private readonly ISpecValueApi _specValueApi;
        private readonly IProductApi _productApi;
        private readonly IMapper _mapper;

        public ProductPropertiesViewComponent(ISpecToProductApi specToProductdApi, ISpecGroupApi specGroupApi, ISpecNameApi specNameApi, ISpecValueApi specValueApi, IProductApi productApi, IMapper mapper)
        {
            _specToProductdApi = specToProductdApi;
            _specGroupApi = specGroupApi;
            _specNameApi = specNameApi;
            _specValueApi = specValueApi;
            _productApi = productApi;
            _mapper = mapper;
        }
      
        public async Task<IViewComponentResult> InvokeAsync(Guid? id)
        {
            List<SpecToProductViewModel> list = new List<SpecToProductViewModel>();
            var listResult = await _specToProductdApi.GetActive();
            if (listResult.IsSuccessStatusCode && listResult.Content.IsSuccess && listResult.Content.ResultData.Any())
                list = _mapper.Map<List<SpecToProductViewModel>>(listResult.Content.ResultData);
            List<SpecToProductViewModel> specToProList = list.Where(x => x.ProductId == id).ToList();


            foreach (var item in specToProList)
            {
                var productResult = await _productApi.Get(item.ProductId);
                var product = _mapper.Map<ProductViewModel>(productResult.Content.ResultData);
                item.Product = product;
            }

            foreach (var item in specToProList)
            {
                var specNameResult = await _specNameApi.Get(item.SpecNameId);
                var specName = _mapper.Map<SpecNameViewModel>(specNameResult.Content.ResultData);
                item.SpecName = specName;
            }

            foreach (var item in specToProList)
            {
                var specGroupResult = await _specGroupApi.Get(item.SpecGroupId);
                var specGroup = _mapper.Map<SpecGroupViewModel>(specGroupResult.Content.ResultData);
                item.SpecGroup = specGroup;
            }

            foreach (var item in specToProList)
            {
                var specValueResult = await _specValueApi.Get(item.SpecValueId);
                var specValue = _mapper.Map<SpecValueViewModel>(specValueResult.Content.ResultData);
                item.SpecValue = specValue;
            }

            return View(specToProList);
        }
    }
}
