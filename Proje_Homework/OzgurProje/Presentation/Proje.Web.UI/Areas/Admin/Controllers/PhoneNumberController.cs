using AutoMapper;
using Proje.Common.DTOs.PhoneNumber;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.PhoneNumberViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proje.Web.UI.Areas.Admin.Models.UserViewModels;
using Proje.Web.UI.Areas.Admin.Models.PhoneNumberTypeViewModels;

namespace Proje.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class PhoneNumberController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IPhoneNumberApi _phoneNumberApi;
        private readonly IPhoneNumberTypeApi _phoneNumberTypeApi;
        private readonly IUserApi _userApi;
        private readonly IMapper _mapper;

        public PhoneNumberController(IWebHostEnvironment env, IPhoneNumberApi phoneNumberApi, IPhoneNumberTypeApi phoneNumberTypeApi, IUserApi userApi, IMapper mapper)
        {
            _env = env;
            _phoneNumberApi = phoneNumberApi;
            _phoneNumberTypeApi = phoneNumberTypeApi;
            _userApi = userApi;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            List<UserViewModel> users = new List<UserViewModel>();
            var userListResult = await _userApi.GetActive();
            if (userListResult.IsSuccessStatusCode && userListResult.Content.IsSuccess)
                users = _mapper.Map<List<UserViewModel>>(userListResult.Content.ResultData);


            List<PhoneNumberViewModel> list = new List<PhoneNumberViewModel>();
            var listResult = await _phoneNumberApi.List();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<PhoneNumberViewModel>>(listResult.Content.ResultData);

            foreach (var item in list)
            {
                item.User = users.FirstOrDefault(x=>x.Id==item.UserId);
            }

            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            #region Phone Number Type ViewBag
            List<PhoneNumberTypeViewModel> typeList = new List<PhoneNumberTypeViewModel>();
            var typeListResult = await _phoneNumberTypeApi.GetActive();

            if (typeListResult.IsSuccessStatusCode &&
                typeListResult.Content.IsSuccess &&
                typeListResult.Content.ResultData.Any())
                typeList = _mapper.Map<List<PhoneNumberTypeViewModel>>(typeListResult.Content.ResultData);


            ViewBag.Types = new SelectList(typeList, "Name", "Name");
            #endregion


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreatePhoneNumberViewModel item)
        {
            #region Phone Number Type ViewBag
            List<PhoneNumberTypeViewModel> typeList = new List<PhoneNumberTypeViewModel>();
            var typeListResult = await _phoneNumberTypeApi.GetActive();

            if (typeListResult.IsSuccessStatusCode &&
                typeListResult.Content.IsSuccess &&
                typeListResult.Content.ResultData.Any())
                typeList = _mapper.Map<List<PhoneNumberTypeViewModel>>(typeListResult.Content.ResultData);


            ViewBag.Types = new SelectList(typeList, "Name", "Name");
            #endregion

            #region User'ı ekliyorum.
            UserViewModel user = new UserViewModel();
            var userResult = await _userApi.GetCartUser();
            if (userResult.IsSuccessStatusCode && userResult.Content.IsSuccess)
                user = _mapper.Map<UserViewModel>(userResult.Content.ResultData);

            item.UserId = user.Id; 
            #endregion

            if (ModelState.IsValid)
            {
                var insertResult = await _phoneNumberApi.Post(_mapper.Map<PhoneNumberRequest>(item));
                if (insertResult.IsSuccessStatusCode && insertResult.Content.IsSuccess && insertResult.Content.ResultData != null)
                    return RedirectToAction("Index");
                else
                    TempData["Message"] = "Kayıt işlemi sırasında bir hata oluştu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";
            }
            else
                TempData["Message"] = "İşlem başarısız oldu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            #region Phone Number Type ViewBag
            List<PhoneNumberTypeViewModel> typeList = new List<PhoneNumberTypeViewModel>();
            var typeListResult = await _phoneNumberTypeApi.GetActive();

            if (typeListResult.IsSuccessStatusCode &&
                typeListResult.Content.IsSuccess &&
                typeListResult.Content.ResultData.Any())
                typeList = _mapper.Map<List<PhoneNumberTypeViewModel>>(typeListResult.Content.ResultData);


            ViewBag.Types = new SelectList(typeList, "Name", "Name");
            #endregion



            UpdatePhoneNumberViewModel model = new UpdatePhoneNumberViewModel();
            var updateResult = await _phoneNumberApi.Get(id);
            if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                model = _mapper.Map<UpdatePhoneNumberViewModel>(updateResult.Content.ResultData);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdatePhoneNumberViewModel item)
        {
            #region Phone Number Type ViewBag
            List<PhoneNumberTypeViewModel> typeList = new List<PhoneNumberTypeViewModel>();
            var typeListResult = await _phoneNumberTypeApi.GetActive();

            if (typeListResult.IsSuccessStatusCode &&
                typeListResult.Content.IsSuccess &&
                typeListResult.Content.ResultData.Any())
                typeList = _mapper.Map<List<PhoneNumberTypeViewModel>>(typeListResult.Content.ResultData);


            ViewBag.Types = new SelectList(typeList, "Name", "Name");
            #endregion

            #region User'ı ekliyorum.
            UserViewModel user = new UserViewModel();
            var userResult = await _userApi.GetCartUser();
            if (userResult.IsSuccessStatusCode && userResult.Content.IsSuccess)
                user = _mapper.Map<UserViewModel>(userResult.Content.ResultData);

            item.UserId = user.Id;
            #endregion


            if (ModelState.IsValid)
            {
                var updateResult = await _phoneNumberApi.Put(item.Id, _mapper.Map<PhoneNumberRequest>(item));
                if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                    return RedirectToAction("Index");
                else
                    TempData["Message"] = "Güncelleme işlemi sırasında bir hata oluştu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";
            }
            else
                TempData["Message"] = "İşlem başarısız oldu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Activate(Guid id)
        {
            var activatedResut = await _phoneNumberApi.Activate(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedResut = await _phoneNumberApi.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            PhoneNumberViewModel model = new PhoneNumberViewModel();
            var result = await _phoneNumberApi.Get(id);
            if (result.IsSuccessStatusCode && result.Content.IsSuccess && result.Content.ResultData != null)
                model = _mapper.Map<PhoneNumberViewModel>(result.Content.ResultData);
            return View(model);
        }
    }
}
