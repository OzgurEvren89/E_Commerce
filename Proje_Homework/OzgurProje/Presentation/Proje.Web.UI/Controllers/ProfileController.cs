using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proje.Common.DTOs.MemberAddress;
using Proje.Common.DTOs.OrderRefundDemand;
using Proje.Common.DTOs.PhoneNumber;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.DemandStatusViewModels;
using Proje.Web.UI.Areas.Admin.Models.MemberAddressViewModels;
using Proje.Web.UI.Areas.Admin.Models.OrderRefundDemandViewModels;
using Proje.Web.UI.Areas.Admin.Models.OrderViewModels;
using Proje.Web.UI.Areas.Admin.Models.PhoneNumberTypeViewModels;
using Proje.Web.UI.Areas.Admin.Models.PhoneNumberViewModels;
using Proje.Web.UI.Areas.Admin.Models.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IUserApi _userApi;
        private readonly IOrderApi _orderApi;
        private readonly IDemandStatusApi _demandStatusApi;
        private readonly IOrderRefundDemandApi _orderRefundDemandApi;
        private readonly IPhoneNumberApi _phoneNumberApi;
        private readonly IPhoneNumberTypeApi _phoneNumberTypeApi;
        private readonly IMemberAddressApi _memberAddressApi;
        private readonly IMapper _mapper;

        public ProfileController(IWebHostEnvironment env, IUserApi userApi, IOrderApi orderApi, IDemandStatusApi demandStatusApi, IOrderRefundDemandApi orderRefundDemandApi, IPhoneNumberApi phoneNumberApi, IPhoneNumberTypeApi phoneNumberTypeApi, IMemberAddressApi memberAddressApi, IMapper mapper)
        {
            _env = env;
            _userApi = userApi;
            _orderApi = orderApi;
            _demandStatusApi = demandStatusApi;
            _orderRefundDemandApi = orderRefundDemandApi;
            _phoneNumberApi = phoneNumberApi;
            _phoneNumberTypeApi = phoneNumberTypeApi;
            _memberAddressApi = memberAddressApi;
            _mapper = mapper;
        }


        public IActionResult UserAddressViewComponent()
        {
            return ViewComponent("UserAddress");
        }
        public IActionResult UserPhoneViewComponent()
        {
            return ViewComponent("UserPhone");
        }
        public IActionResult GetOrderViewComponent(Guid id)
        {
            return ViewComponent("GetOrder", new { id = id });
        }
        public IActionResult OrderRefundDemandViewComponent(Guid id)
        {
            return ViewComponent("OrderRefundDemand", new { id = id });
        }
        public async Task<IActionResult> Index()
        {


            UserViewModel user = new UserViewModel();
            var userResult = await _userApi.GetCartUser();
            if (userResult.IsSuccessStatusCode && userResult.Content.IsSuccess)
                user = _mapper.Map<UserViewModel>(userResult.Content.ResultData);


            #region Telefon Numarası 
            List<PhoneNumberViewModel> phoneList = new List<PhoneNumberViewModel>();
            var phoneListResult = await _phoneNumberApi.GetActive();
            if (phoneListResult.IsSuccessStatusCode && phoneListResult.Content.IsSuccess)
                phoneList = _mapper.Map<List<PhoneNumberViewModel>>(phoneListResult.Content.ResultData);
            phoneList = phoneList.Where(x => x.UserId == user.Id).OrderByDescending(x => x.CreatedDate).ToList();

            user.PhoneNumbers = phoneList;
            #endregion
      

            if (user == null || user.Id == null || user.Id == Guid.Empty)
            {
                TempData["Message"] = "Profil sayfanıza girebilmeniz içn önce giriş yapmanız gerekmektedir!...Hesabınız yok ise lütfen kayıt olup tekrar deneyiniz...";
                return RedirectToAction("Login", "Account");
            }


            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> PhoneInsert()
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
        public async Task<IActionResult> PhoneInsert(CreatePhoneNumberViewModel item)
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
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> InsertAddress()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InsertAddress(CreateMemberAddressViewModel item)
        {
            if (ModelState.IsValid)
            {
                var insertResult = await _memberAddressApi.Post(_mapper.Map<MemberAddressRequest>(item));
                if (insertResult.IsSuccessStatusCode && insertResult.Content.IsSuccess && insertResult.Content.ResultData != null)
                    return RedirectToAction("Index");
                else
                    TempData["Message"] = "Kayıt işlemi sırasında bir hata oluştu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";
            }
            else
                TempData["Message"] = "İşlem başarısız oldu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> InsertOrderRefundDemand()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InsertOrderRefundDemand(CreateOrderRefundDemandViewModel item)
        {

            #region UserId'yi Atadım

            UserViewModel user = new UserViewModel();
            var userResult = await _userApi.GetCartUser();
            if (userResult.IsSuccessStatusCode && userResult.Content.IsSuccess)
                user = _mapper.Map<UserViewModel>(userResult.Content.ResultData);

            item.UserId = user.Id;//user Id'yi atadım.     
            #endregion

            #region Result Statusu Atıyorum 
            //List<DemandStatusViewModel> demandStatus = new List<DemandStatusViewModel>();
            //var demandStatusResult = await _demandStatusApi.GetActive();
            //if (demandStatusResult.IsSuccessStatusCode && demandStatusResult.Content.IsSuccess)
            //    demandStatus = _mapper.Map<List<DemandStatusViewModel>>(demandStatusResult.Content.ResultData);
            //var demandStatu = demandStatus.FirstOrDefault(x => x.Name == "Onay Bekliyor");

            item.ResultStatus = "Onay Bekliyor";// aslında bu isimde br durumum var bu durumlar sabit yukarıda çekmiştim fakat controllor'ı yormaması için  direkt ifadeyi yazdım. admin bunu inceleyip ınaylandı yada iptal edildiye çekebilecek sayfasından.  
            #endregion

          
                var insertResult = await _orderRefundDemandApi.Post(_mapper.Map<OrderRefundDemandRequest>(item));
                if (insertResult.IsSuccessStatusCode && insertResult.Content.IsSuccess && insertResult.Content.ResultData != null)
                    return RedirectToAction("Index");
                else
                    TempData["Message"] = "Kayıt işlemi sırasında bir hata oluştu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";
           
                TempData["Message"] = "İşlem başarısız oldu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";

            return RedirectToAction("Index");
        }

    }
}
