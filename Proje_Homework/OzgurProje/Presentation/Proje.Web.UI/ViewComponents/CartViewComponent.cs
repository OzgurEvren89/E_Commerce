using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proje.Common.Extensions;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.CartItemViewModels;
using Proje.Web.UI.Areas.Admin.Models.UserViewModels;
using Proje.Web.UI.Infrasructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        private readonly IUserApi _userApi;
        private readonly IMapper _mapper;

        public CartViewComponent(IUserApi userApi, IMapper mapper)
        {
            _userApi = userApi;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            UserViewModel user = new UserViewModel();
            var userResult = await _userApi.GetCartUser();
            if (userResult.IsSuccessStatusCode && userResult.Content.IsSuccess)
                user = _mapper.Map<UserViewModel>(userResult.Content.ResultData);

           
                string userName = user.Id.ToString();

           
                if (Request.Cookies.Where(x => x.Key.Contains(userName)).Count() > 0)
                {
                  
                    List<CartItemViewModel> list = new List<CartItemViewModel>();
                    var cookies = HttpContext.Request.Cookies.Where(x => x.Key.Contains(userName)).ToList();
                    if (cookies != null && cookies.Count() > 0)
                    {
                        foreach (var cokkieItem in cookies)
                        {
                            string strCart = cokkieItem.Value.Decrypt();
                            CartHelper cartHelper = JsonConvert.DeserializeObject<CartHelper>(strCart);
                            list.AddRange(cartHelper.Cart.CartItems.ToList());
                        }
                    }
                   
                    return View(list);
                }
            
            TempData["Message"] = "Sepetinizde Ürün Bulunmamaktadır...";

            return View(new List<CartItemViewModel>());
        }
    }
}
