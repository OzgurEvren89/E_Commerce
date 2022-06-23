using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.OptionGroupViewModels;
using Proje.Web.UI.Areas.Admin.Models.OptionsViewModels;
using Proje.Web.UI.Areas.Admin.Models.OptionToProductViewModels;
using Proje.Web.UI.Areas.Admin.Models.ProductViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.ViewComponents
{
    public class OptionToProductViewComponent : ViewComponent
    {
        private readonly IWebHostEnvironment _env;
        private readonly IOptionToProductApi _optionToProductApi;
        private readonly IOptionGroupApi _optionGroupApi;
        private readonly IOptionsApi _optionsApi;
        private readonly IProductApi _productApi;
        private readonly IMapper _mapper;


        public OptionToProductViewComponent(IWebHostEnvironment env, IOptionToProductApi optionToProductApi, IOptionGroupApi optionGroupApi, IOptionsApi optionsApi, IProductApi productApi, IMapper mapper)
        {
            _env = env;
            _optionToProductApi = optionToProductApi;
            _optionGroupApi = optionGroupApi;
            _optionsApi = optionsApi;
            _productApi = productApi;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid Id)
        {
            List<OptionToProductViewModel> list = new List<OptionToProductViewModel>();
            var listResult = await _optionToProductApi.List();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<OptionToProductViewModel>>(listResult.Content.ResultData);



            list = list.Where(x => x.ParentProductId == Id).ToList();
            ViewData["parentProduct"] = "";
            ViewData["parentProduct"] = Id;


            foreach (var item in list)
            {
                var optionGroupResult = await _optionGroupApi.Get(item.OptionGroupId);
                var optionGroup = _mapper.Map<OptionGroupViewModel>(optionGroupResult.Content.ResultData);
                item.OptionGroup = optionGroup;
            }

            foreach (var item in list)
            {
                var optionsResult = await _optionsApi.Get(item.OptionId);
                var option = _mapper.Map<OptionsViewModel>(optionsResult.Content.ResultData);
                item.Option = option;
            }

            foreach (var item in list)
            {
                var proResult = await _productApi.Get(item.ProductId);
                var product = _mapper.Map<ProductViewModel>(proResult.Content.ResultData);
                item.Product = product;
            }
            list = list.OrderBy(x => x.OptionGroupId).ToList();
            return View(list);

        }
    }
}
