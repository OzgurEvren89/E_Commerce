using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.ProductCommentViewModels;
using Proje.Web.UI.Areas.Admin.Models.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.ViewComponents
{
    public class ProductCommentViewComponent : ViewComponent
    {
        private readonly IProductCommentApi _productCommentApi;
        private readonly IUserApi _userApi;
        private readonly IMapper _mapper;

        public ProductCommentViewComponent(IProductCommentApi productCommentApi, IUserApi userApi, IMapper mapper)
        {
            _productCommentApi = productCommentApi;
            _userApi = userApi;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid id)
        {
            List<ProductCommentViewModel> list = new List<ProductCommentViewModel>();
            var listResult = await _productCommentApi.GetActive();
            if (listResult.IsSuccessStatusCode && listResult.Content.IsSuccess && listResult.Content.ResultData.Any())
                list = _mapper.Map<List<ProductCommentViewModel>>(listResult.Content.ResultData);
            list = list.Where(x => x.ProductId == id).ToList();


            #region Yoruma, Yorumu yapan kullanıcı nesnesini de yükledim.
            List<UserViewModel> userViewModels = new List<UserViewModel>();
            var listResultUser = await _userApi.GetActive();
            if (listResultUser.IsSuccessStatusCode && listResultUser.Content.IsSuccess && listResultUser.Content.ResultData.Any())
                userViewModels = _mapper.Map<List<UserViewModel>>(listResultUser.Content.ResultData);

            foreach (var item in list)
            {
                item.User = userViewModels.FirstOrDefault(x => x.Id == item.UserId);
            } 
            #endregion

            return View(list);
        }
    }
}
