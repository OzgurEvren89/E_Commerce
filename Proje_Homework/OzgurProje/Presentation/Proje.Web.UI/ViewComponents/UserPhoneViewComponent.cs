using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.PhoneNumberTypeViewModels;
using Proje.Web.UI.Areas.Admin.Models.PhoneNumberViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.ViewComponents
{
    public class UserPhoneViewComponent : ViewComponent
    {
        private readonly IPhoneNumberApi _phoneNumberApi;
        private readonly IMapper _mapper;      
        private readonly IPhoneNumberTypeApi _phoneNumberTypeApi;

        public UserPhoneViewComponent(IPhoneNumberApi phoneNumberApi, IMapper mapper, IPhoneNumberTypeApi phoneNumberTypeApi)
        {
            _phoneNumberApi = phoneNumberApi;
            _mapper = mapper;
            _phoneNumberTypeApi = phoneNumberTypeApi;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            #region AddressType ViewBag

            List<PhoneNumberTypeViewModel> phoneNumberType = new List<PhoneNumberTypeViewModel>();
            var listPhoneNumberTypeResult = await _phoneNumberTypeApi.GetActive();

            if (listPhoneNumberTypeResult.IsSuccessStatusCode &&
                listPhoneNumberTypeResult.Content.IsSuccess &&
                listPhoneNumberTypeResult.Content.ResultData.Any())
                phoneNumberType = _mapper.Map<List<PhoneNumberTypeViewModel>>(listPhoneNumberTypeResult.Content.ResultData);

            ViewBag.PhoneNumberType = new SelectList(phoneNumberType, "Name", "Name");
            #endregion

            return View(new CreatePhoneNumberViewModel());

        }
    }
}
