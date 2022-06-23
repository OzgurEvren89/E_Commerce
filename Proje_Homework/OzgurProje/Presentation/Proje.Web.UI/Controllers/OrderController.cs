using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Proje.Common.DTOs.MemberAddress;
using Proje.Common.DTOs.Order;
using Proje.Common.DTOs.OrderItem;
using Proje.Common.DTOs.Payment;
using Proje.Common.Extensions;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.AddressTypeViewModels;
using Proje.Web.UI.Areas.Admin.Models.CartItemViewModels;
using Proje.Web.UI.Areas.Admin.Models.CityViewModels;
using Proje.Web.UI.Areas.Admin.Models.CountyViewModels;
using Proje.Web.UI.Areas.Admin.Models.MemberAddressViewModels;
using Proje.Web.UI.Areas.Admin.Models.OrderItemViewModels;
using Proje.Web.UI.Areas.Admin.Models.OrderViewModels;
using Proje.Web.UI.Areas.Admin.Models.PaymentViewModels;
using Proje.Web.UI.Areas.Admin.Models.ProductViewModels;
using Proje.Web.UI.Areas.Admin.Models.ShippingCompanyViewModels;
using Proje.Web.UI.Areas.Admin.Models.UserViewModels;
using Proje.Web.UI.Infrasructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;
        private readonly IUserApi _userApi;
        private readonly IPaymentApi _paymentApi;
        private readonly IOrderApi _orderApi;
        private readonly IOrderItemApi _orderItemApi;
        private readonly IMemberAddressApi _memberAddressApi;
        private readonly IShippingCompanyApi _shippingCompanyApi;

        public OrderController(IHttpContextAccessor httpContextAccessor, IWebHostEnvironment env, IMapper mapper, IUserApi userApi, IPaymentApi paymentApi, IOrderApi orderApi, IOrderItemApi orderItemApi, IMemberAddressApi memberAddressApi, IShippingCompanyApi shippingCompanyApi)
        {
            _httpContextAccessor = httpContextAccessor;
            _env = env;
            _mapper = mapper;
            _userApi = userApi;
            _paymentApi = paymentApi;
            _orderApi = orderApi;
            _orderItemApi = orderItemApi;
            _memberAddressApi = memberAddressApi;
            _shippingCompanyApi = shippingCompanyApi;
        }


        public IActionResult UserAddressFormViewComponent()
        {
            return ViewComponent("UserAddressForm");
        }

        [HttpGet]
        public async Task<IActionResult> Insert(/*PaymentResponse item */)
        {

            #region MemberAddress ViewBag

            List<MemberAddressViewModel> listMemberAddress = new List<MemberAddressViewModel>();
            var listMemberAddressResult = await _memberAddressApi.GetActive();

            if (listMemberAddressResult.IsSuccessStatusCode &&
                listMemberAddressResult.Content.IsSuccess &&
                listMemberAddressResult.Content.ResultData.Any())
                listMemberAddress = _mapper.Map<List<MemberAddressViewModel>>(listMemberAddressResult.Content.ResultData);
            listMemberAddress = listMemberAddress.OrderByDescending(x => x.CreatedDate).ToList();

            ViewBag.MemberAdresses = new SelectList(listMemberAddress, "Id", "AddressName");

            #endregion

            #region ShippingCompany ViewBag

            List<ShippingCompanyViewModel> listShippingCompany = new List<ShippingCompanyViewModel>();
            var listShippingCompanyResult = await _shippingCompanyApi.GetActive();

            if (listShippingCompanyResult.IsSuccessStatusCode &&
                listShippingCompanyResult.Content.IsSuccess &&
                listShippingCompanyResult.Content.ResultData.Any())
                listShippingCompany = _mapper.Map<List<ShippingCompanyViewModel>>(listShippingCompanyResult.Content.ResultData);
     

            ViewBag.ShippingCompany = new SelectList(listShippingCompany, "Name", "Name");

            #endregion

            //ViewData["payment"] = item;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Insert(CreateOrderViewModel item)
        {

            #region MemberAddress ViewBag

            List<MemberAddressViewModel> listMemberAddress = new List<MemberAddressViewModel>();
            var listMemberAddressResult = await _memberAddressApi.GetActive();

            if (listMemberAddressResult.IsSuccessStatusCode &&
                listMemberAddressResult.Content.IsSuccess &&
                listMemberAddressResult.Content.ResultData.Any())
                listMemberAddress = _mapper.Map<List<MemberAddressViewModel>>(listMemberAddressResult.Content.ResultData);


            ViewBag.MemberAdresses = new SelectList(listMemberAddress, "Id", "AddressName");
            #endregion

            #region ShippingCompany ViewBag

            List<ShippingCompanyViewModel> listShippingCompany = new List<ShippingCompanyViewModel>();
            var listShippingCompanyResult = await _shippingCompanyApi.GetActive();

            if (listShippingCompanyResult.IsSuccessStatusCode &&
                listShippingCompanyResult.Content.IsSuccess &&
                listShippingCompanyResult.Content.ResultData.Any())
                listShippingCompany = _mapper.Map<List<ShippingCompanyViewModel>>(listShippingCompanyResult.Content.ResultData);


            ViewBag.ShippingCompany = new SelectList(listShippingCompany, "Name", "Name");



            #endregion

            #region Paymentimi Çek Cookiden

            UserViewModel user = new UserViewModel();
            var userResult = await _userApi.GetCartUser();
            if (userResult.IsSuccessStatusCode && userResult.Content.IsSuccess)
                user = _mapper.Map<UserViewModel>(userResult.Content.ResultData);

            string userName = user.Id.ToString();

            PaymentResponse paymentResponse = new PaymentResponse();
            var cookie = HttpContext.Request.Cookies.Where(x => x.Key == userName.Substring(0,9));
            if (cookie != null && cookie.Count() > 0)
            {
                string strPayment = cookie.FirstOrDefault().Value.Decrypt();
                paymentResponse = JsonConvert.DeserializeObject<PaymentResponse>(strPayment);
            }
            #endregion


            item.CustomerFirstname = paymentResponse.UserFirstname;
            item.CustomerSurname = paymentResponse.UserSurname;
            item.CustomerEmail = paymentResponse.UserEmail;
            item.CustomerPhone = paymentResponse.UserPhone;
            item.PaymentGatewayName = paymentResponse.PaymentGatewayName;
            item.PaymentGatewayCode = paymentResponse.PaymentGatewayCode;
            item.PaymentTypeName = paymentResponse.PaymentTypeName;
            item.Amount = paymentResponse.FinalAmount;


            var shippingCompany = listShippingCompany.FirstOrDefault(x => x.Name == item.ShippingCompanyName);

            if (shippingCompany != null )
            {
                if (item.Amount < shippingCompany.FreeShipmentOrderPrice)
                {
                    item.Amount = paymentResponse.FinalAmount + shippingCompany.ExtraPrice;
                }             
            }
        
           
            
            item.OrderStatus = "Siparişiniz Hazırlanıyor";//sabit durumlardan ilki admin kargoya verip duzeltebilir siparişler sayfasından adım adım.

            #region Sepetimi Çekiyorum
            List<CartItemViewModel> cartList = new List<CartItemViewModel>();

            if (Request.Cookies.Where(x => x.Key.Contains(userName)).Count() > 0)
                {
                   
                    var cookies = HttpContext.Request.Cookies.Where(x => x.Key.Contains(userName)).ToList();
                    if (cookies != null && cookies.Count() > 0)
                    {
                        foreach (var cokkieItem in cookies)
                        {
                            string strCart = cokkieItem.Value.Decrypt();
                            CartHelper cartHelper = JsonConvert.DeserializeObject<CartHelper>(strCart);
                            cartList.AddRange(cartHelper.Cart.CartItems.ToList());
                        }
                    }                                       
                }
            List<ProductViewModel> cartProList = new List<ProductViewModel>();
            
          
            #endregion

            OrderRequest orderRequest = _mapper.Map<OrderRequest>(item);
                var insertResult = await _orderApi.Post(orderRequest);

            #region Siparşimin Kalemlerini Oluşturuyorum.
            
            foreach (var cartItem in cartList)
            {
                CreateOrderItemViewModel orderItem = new CreateOrderItemViewModel();
                orderItem.OrderId = insertResult.Content.ResultData.Id;
                orderItem.ProductId = cartItem.ProductId;
                orderItem.ProductName = cartItem.Product.ProductName;
                orderItem.ProductWeight = cartItem.Product.VolumetricWeight;
                orderItem.UserId = user.Id;
                var orderItemResult = await _orderItemApi.Post(_mapper.Map<OrderItemRequest>(orderItem));
            } 
            #endregion

            paymentResponse.PaymentStatusId = Guid.Parse("922F400A-9743-4508-80CF-C6C3BBB385C0");

            if (insertResult.IsSuccessStatusCode && insertResult.Content.IsSuccess && insertResult.Content.ResultData != null)
            {
                //Ödeme tamamlandığı için sepeti ve diğer cookieleri temizliyorum.

                #region Ödemeyi temizliyorum.
                string key1 = userName.Substring(0,9);
                var cookieOptions = new CookieOptions()
                {
                    Path = "/",
                    HttpOnly = false,
                    IsEssential = true,
                    Expires = DateTime.Now.AddMonths(-1)

                };

                HttpContext.Response.Cookies.Delete(key1, cookieOptions);
                #endregion

                #region Sepeti Boşalttım
                var cookies = HttpContext.Request.Cookies.Where(x => x.Key.Contains(userName)).ToList();
                if (cookies != null && cookies.Count() > 0)
                {
                    foreach (var cokkieItem in cookies)
                    {
                        //string strCart = cokkieItem.Value.Decrypt();

                        string key2 = cokkieItem.Key;
                        var cookieOptions2 = new CookieOptions()
                        {
                            Path = "/",
                            HttpOnly = false,
                            IsEssential = true,
                            Expires = DateTime.Now.AddMonths(-1)
                        };
                        HttpContext.Response.Cookies.Delete(key2, cookieOptions2);

                    }
                } 
                #endregion

                return RedirectToAction("Index", "Home");//Değişecek

            }
            else
            {
                TempData["Message"] = "Kayıt işlemi sırasında bir hata oluştu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";
                return View();
            }         
        }

        [HttpGet]
        public async Task<IActionResult> InsertUserAddress()
        {

            UserViewModel user = new UserViewModel();
            var userResult = await _userApi.GetCartUser();
            if (userResult.IsSuccessStatusCode && userResult.Content.IsSuccess)
                user = _mapper.Map<UserViewModel>(userResult.Content.ResultData);

            if (user == null || user.Id == null || user.Id == Guid.Empty)
            {
                TempData["Message"] = "Adres kaydedebilmeniz için önce giriş yapmanız gerekmektedir!...Hesabınız yok ise lütfen kayıt olup tekrar deneyiniz...";
                return RedirectToAction("Login", "Account");
            }

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> InsertUserAddress(CreateMemberAddressViewModel item)
        {

            if (ModelState.IsValid)
            {

                MemberAddressRequest memberAddressRequest = _mapper.Map<MemberAddressRequest>(item);
                var memberAddressResult = await _memberAddressApi.Post(memberAddressRequest);
                if (memberAddressResult.IsSuccessStatusCode && memberAddressResult.Content.IsSuccess && memberAddressResult.Content.ResultData != null)
                    return RedirectToAction("Insert");
                else
                    TempData["Message"] = "Kayıt işlemi sırasında bir hata oluştu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";
            }
            else
                TempData["Message"] = "İşlem başarısız oldu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";

            return RedirectToAction("Insert");
        }


    }
}
