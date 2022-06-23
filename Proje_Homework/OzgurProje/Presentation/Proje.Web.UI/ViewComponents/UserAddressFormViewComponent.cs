using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proje.Common.DTOs.MemberAddress;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.AddressTypeViewModels;
using Proje.Web.UI.Areas.Admin.Models.CityViewModels;
using Proje.Web.UI.Areas.Admin.Models.CountyViewModels;
using Proje.Web.UI.Areas.Admin.Models.MemberAddressViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.ViewComponents
{
    public class UserAddressFormViewComponent : ViewComponent
    {
        private readonly IMemberAddressApi _memberAddressApi;
        private readonly IMapper _mapper;
        private readonly IOrderApi _orderApi;
        private readonly ICityApi _cityApi;
        private readonly ICountyApi _countyApi;
        private readonly IAddressTypeApi _addressTypeApi;

        public UserAddressFormViewComponent(IMemberAddressApi memberAddressApi, IMapper mapper, IOrderApi orderApi, ICityApi cityApi, ICountyApi countyApi, IAddressTypeApi addressTypeApi)
        {
            _memberAddressApi = memberAddressApi;
            _mapper = mapper;
            _orderApi = orderApi;
            _cityApi = cityApi;
            _countyApi = countyApi;
            _addressTypeApi = addressTypeApi;
        }



       

       
        public async Task<IViewComponentResult> InvokeAsync()
        {
            #region AddressType ViewBag

            List<AddressTypeViewModel> listAddressType = new List<AddressTypeViewModel>();
            var listAddressTypeResult = await _addressTypeApi.GetActive();

            if (listAddressTypeResult.IsSuccessStatusCode &&
                listAddressTypeResult.Content.IsSuccess &&
                listAddressTypeResult.Content.ResultData.Any())
                listAddressType = _mapper.Map<List<AddressTypeViewModel>>(listAddressTypeResult.Content.ResultData);

            ViewBag.AddressType = new SelectList(listAddressType, "Id", "TypeName");
            #endregion

            #region City ViewBag

            List<CityViewModel> listCity = new List<CityViewModel>();
            var listCityResult = await _cityApi.GetActive();

            if (listCityResult.IsSuccessStatusCode &&
                listCityResult.Content.IsSuccess &&
                listCityResult.Content.ResultData.Any())
                listCity = _mapper.Map<List<CityViewModel>>(listCityResult.Content.ResultData);


            ViewBag.Cities = new SelectList(listCity, "CityCode", "CityName");
            #endregion

            #region County ViewBag

            List<CountyViewModel> listCount = new List<CountyViewModel>();
            var listCountyResult = await _countyApi.GetActive();

            if (listCountyResult.IsSuccessStatusCode &&
                listCountyResult.Content.IsSuccess &&
                listCountyResult.Content.ResultData.Any())
                listCount = _mapper.Map<List<CountyViewModel>>(listCountyResult.Content.ResultData);


            ViewBag.Counties = new SelectList(listCount, "CountyCode", "CountyName");
            #endregion



            return View(new CreateMemberAddressViewModel()) ;

        }

    }
}
