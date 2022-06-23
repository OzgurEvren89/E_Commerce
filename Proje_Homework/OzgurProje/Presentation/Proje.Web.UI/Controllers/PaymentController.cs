using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Proje.Common.DTOs.CurrencyValue;
using Proje.Common.DTOs.Payment;
using Proje.Common.Extensions;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.CartItemViewModels;
using Proje.Web.UI.Areas.Admin.Models.CurrencyValueViewModels;
using Proje.Web.UI.Areas.Admin.Models.CurrencyViewModels;
using Proje.Web.UI.Areas.Admin.Models.InstallmentRateViewModels;
using Proje.Web.UI.Areas.Admin.Models.PaymentGatewayViewModels;
using Proje.Web.UI.Areas.Admin.Models.PaymentTypeViewModels;
using Proje.Web.UI.Areas.Admin.Models.PaymentViewModels;
using Proje.Web.UI.Areas.Admin.Models.UserViewModels;
using Proje.Web.UI.Infrasructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Proje.Web.UI.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _env;
        private readonly IPaymentApi _paymentApi;
        private readonly IPaymentGatewayApi _paymentGatewayApi;
        private readonly IPaymentTypeApi _paymentTypeApi;
        private readonly IPaymentStatusApi _paymentStatusApi;
        private readonly IInstallmentRateApi _iInstallmentRateApi;
        private readonly ICurrencyApi _currencyApi;
        private readonly ICurrencyValueApi _currencyValueApi;
        private readonly IUserApi _userApi;
        private readonly IMapper _mapper;

        public PaymentController(IHttpContextAccessor httpContextAccessor, IWebHostEnvironment env, IPaymentApi paymentApi, IPaymentGatewayApi paymentGatewayApi, IPaymentTypeApi paymentTypeApi, IPaymentStatusApi paymentStatusApi, IInstallmentRateApi iInstallmentRateApi, ICurrencyApi currencyApi, ICurrencyValueApi currencyValueApi, IUserApi userApi, IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _env = env;
            _paymentApi = paymentApi;
            _paymentGatewayApi = paymentGatewayApi;
            _paymentTypeApi = paymentTypeApi;
            _paymentStatusApi = paymentStatusApi;
            _iInstallmentRateApi = iInstallmentRateApi;
            _currencyApi = currencyApi;
            _currencyValueApi = currencyValueApi;
            _userApi = userApi;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> Insert(  )
        {

            #region PaymentGatewayName ViewBag

            List<PaymentGatewayViewModel> list = new List<PaymentGatewayViewModel>();
            var listResult = await _paymentGatewayApi.GetActive();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<PaymentGatewayViewModel>>(listResult.Content.ResultData);



            ViewBag.PaymentGatewayNames = new SelectList(list, "Name", "Name");
            //ViewBag.PaymentGatewayCodes = new SelectList(list, "Code", "Name");

            #endregion

            #region Instalment ViewBag

            int[] instalment = new int[13] { 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            ViewBag.Instalment = new SelectList(instalment);

            #endregion

            #region PaymentTypes ViewBag

            List<PaymentTypeViewModel> listPaymentType = new List<PaymentTypeViewModel>();
            var listTypeResult = await _paymentTypeApi.GetActive();

            if (listTypeResult.IsSuccessStatusCode &&
                listTypeResult.Content.IsSuccess &&
                listTypeResult.Content.ResultData.Any())
                listPaymentType = _mapper.Map<List<PaymentTypeViewModel>>(listTypeResult.Content.ResultData);


            ViewBag.PaymentTypes = new SelectList(listPaymentType, "Name", "Name");

            #endregion

            #region Kur ViewBag

            List<CurrencyViewModel> currencyList = new List<CurrencyViewModel>();
            var listCurrencyResult = await _currencyApi.GetActive();

            if (listCurrencyResult.IsSuccessStatusCode &&
                listCurrencyResult.Content.IsSuccess &&
                listCurrencyResult.Content.ResultData.Any())
                currencyList = _mapper.Map<List<CurrencyViewModel>>(listCurrencyResult.Content.ResultData);

            ViewBag.Currencies = new SelectList(currencyList, "ShortName", "ShortName");

            #endregion

           
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Insert(CreatePaymentViewModel item)
        {
            #region Seçilen Taksit Sayısına Göre Vade Oranını Atama         

            List<InstallmentRateViewModel> instalmentlist = new List<InstallmentRateViewModel>();
            var instalmentlistResult = await _iInstallmentRateApi.GetActive();

            if (instalmentlistResult.IsSuccessStatusCode &&
                instalmentlistResult.Content.IsSuccess &&
                instalmentlistResult.Content.ResultData.Any())
                instalmentlist = _mapper.Map<List<InstallmentRateViewModel>>(instalmentlistResult.Content.ResultData);

            List<PaymentGatewayViewModel> paymentGatewaylist = new List<PaymentGatewayViewModel>();
            var paymentGatewaylistResult = await _paymentGatewayApi.GetActive();

            if (paymentGatewaylistResult.IsSuccessStatusCode &&
                paymentGatewaylistResult.Content.IsSuccess &&
                paymentGatewaylistResult.Content.ResultData.Any())
                paymentGatewaylist = _mapper.Map<List<PaymentGatewayViewModel>>(paymentGatewaylistResult.Content.ResultData);

            var currentpaymentGateway = paymentGatewaylist.FirstOrDefault(x => x.Name == item.PaymentGatewayName);// PaymentGateway'im elimde

            if (currentpaymentGateway != null)
            {
                currentpaymentGateway.InstallmentRates = instalmentlist.Where(x => x.PaymentGatewayId == currentpaymentGateway.Id).ToList();
                var İnstalmentListForBank = currentpaymentGateway.InstallmentRates;
                İnstalmentListForBank = İnstalmentListForBank.OrderBy(x => x.Installment).ToList();
                item.InstallmentRate = 0;
                foreach (var instalment in İnstalmentListForBank) //müşterinin seçtiği taksit sayısına göre banka bazında taksit oranımı atıyorum.
                {

                    if (instalment.Installment >= item.Installment)
                    {
                        item.InstallmentRate = instalment.Rate;
                        break;
                    }
                    //seçilen taksit sayısı bankaya ait son taksit sayısından da büyükse sonucu sıfır döndürüp peşin fiyatı üzerinden tek çekim yapacak 
                }
            }

            #endregion

            #region Sepetten Fiyat ve SumOfGainedPoints Atama

            UserViewModel user = new UserViewModel();
            var userResult = await _userApi.GetCartUser();
            if (userResult.IsSuccessStatusCode && userResult.Content.IsSuccess)
                user = _mapper.Map<UserViewModel>(userResult.Content.ResultData);


            string userName = user.Id.ToString();

            decimal totalAmount = 0;

            if (Request.Cookies.Where(x => x.Key.Contains(userName)).Count() > 0)
            {

                List<CartItemViewModel> dizi = new List<CartItemViewModel>();
                var cookies = HttpContext.Request.Cookies.Where(x => x.Key.Contains(userName)).ToList();
                if (cookies != null && cookies.Count() > 0)
                {
                    foreach (var cokkieItem in cookies)
                    {
                        string strCart = cokkieItem.Value.Decrypt();
                        CartHelper cartHelper = JsonConvert.DeserializeObject<CartHelper>(strCart);
                        dizi.AddRange(cartHelper.Cart.CartItems.ToList());
                    }

                    foreach (var cartItem in dizi)
                    {
                        if (cartItem.Product.Price1 != null)
                        {
                            totalAmount += cartItem.Product.Price1 * Convert.ToDecimal(cartItem.Quantity);

                        }
                    }

                }
            }
            item.FinalAmount = totalAmount + totalAmount * item.InstallmentRate;
            item.SumOfGainedPoints = totalAmount / 20;
            #endregion

            #region PaymentGatewayCode Atama

            List<PaymentGatewayViewModel> paymentCodelist = new List<PaymentGatewayViewModel>();

            paymentCodelist = _mapper.Map<List<PaymentGatewayViewModel>>(paymentGatewaylistResult.Content.ResultData);

            var paymentGateway = paymentCodelist.FirstOrDefault(x => x.Name == item.PaymentGatewayName);
            if (paymentGateway != null)
            {
                item.PaymentGatewayCode = paymentGateway.Code;

            }

            #endregion

            #region  Ödeme Durumu atama(Onay Bekliyor)


            item.PaymentStatusId = Guid.Parse("294543A1-B385-4768-BEDA-CABCD5862364");//Onaylandı yapıyorum isterse admin sonra değiştirebilir.
            #endregion

            if (ModelState.IsValid)
            {


                PaymentRequest paymentRequest = _mapper.Map<PaymentRequest>(item);
                var insertResult = await _paymentApi.Post(paymentRequest);
                PaymentResponse payment = insertResult.Content.ResultData;

                #region Ödemeyi Cookie Aldım

                string paymentId = insertResult.Content.ResultData.Id.ToString();
                string key = userName.Substring(0, 9);
                string value = JsonConvert.SerializeObject(payment).Encrypt();
                var cookieOptions = new CookieOptions()
                {
                    Path = "/",
                    HttpOnly = false,
                    IsEssential = true,
                    Expires = DateTime.Now.AddMonths(1)

                };

                HttpContext.Response.Cookies.Append(key, value, cookieOptions);
                #endregion

                if (insertResult.IsSuccessStatusCode && insertResult.Content.IsSuccess && insertResult.Content.ResultData != null)
                    return RedirectToAction("Insert", "Order"/*, payment*/);//paymenti sonra kaldıralım gerek kalmadı
                else
                    TempData["Message"] = "Kayıt işlemi sırasında bir hata oluştu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";
            }
            else
                TempData["Message"] = "İşlem başarısız oldu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";

            #region PaymentGatewayName ViewBag
            List<PaymentGatewayViewModel> list = new List<PaymentGatewayViewModel>();
            var listResult = await _paymentGatewayApi.GetActive();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<PaymentGatewayViewModel>>(listResult.Content.ResultData);


            ViewBag.PaymentGatewayNames = new SelectList(list, "Name", "Name");

            #endregion

            #region Instalment ViewBag

            int[] instalments = new int[14] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            ViewBag.Instalment = new SelectList(instalments);

            #endregion

            #region PaymentTypes ViewBag

            List<PaymentTypeViewModel> listPaymentType = new List<PaymentTypeViewModel>();
            var listTypeResult = await _paymentTypeApi.GetActive();

            if (listTypeResult.IsSuccessStatusCode &&
                listTypeResult.Content.IsSuccess &&
                listTypeResult.Content.ResultData.Any())
                listPaymentType = _mapper.Map<List<PaymentTypeViewModel>>(listTypeResult.Content.ResultData);

            ViewBag.PaymentTypes = new SelectList(listPaymentType, "Name", "Name");

            #endregion

            #region Kur ViewBag

            List<CurrencyViewModel> currencyList = new List<CurrencyViewModel>();
            var listCurrencyResult = await _currencyApi.GetActive();

            if (listCurrencyResult.IsSuccessStatusCode &&
                listCurrencyResult.Content.IsSuccess &&
                listCurrencyResult.Content.ResultData.Any())
                currencyList = _mapper.Map<List<CurrencyViewModel>>(listCurrencyResult.Content.ResultData);

            ViewBag.Currencies = new SelectList(currencyList, "ShortName", "ShortName");

            #endregion

            return View();

        }

      
        [HttpPost]
        public async Task<IActionResult> GetCurrency(string shortName)
        {
            decimal totalAmount = 0;
            UserViewModel user = new UserViewModel();
            var userResult = await _userApi.GetCartUser();
            if (userResult.IsSuccessStatusCode && userResult.Content.IsSuccess)
                user = _mapper.Map<UserViewModel>(userResult.Content.ResultData);
            string userName = user.Id.ToString();
            if (Request.Cookies.Where(x => x.Key.Contains(userName)).Count() > 0)
            {
                List<CartItemViewModel> dizi = new List<CartItemViewModel>();
                var cookies = HttpContext.Request.Cookies.Where(x => x.Key.Contains(userName)).ToList();
                if (cookies != null && cookies.Count() > 0)
                {
                    foreach (var cokkieItem in cookies)
                    {
                        string strCart = cokkieItem.Value.Decrypt();
                        CartHelper cartHelper = JsonConvert.DeserializeObject<CartHelper>(strCart);
                        dizi.AddRange(cartHelper.Cart.CartItems.ToList());
                    }

                    foreach (var cartItem in dizi)
                    {
                        if (cartItem.Product.Price1 != null)
                        {
                            totalAmount += cartItem.Product.Price1 * Convert.ToDecimal(cartItem.Quantity);

                        }
                    }
                }
            }

            decimal totalAmountKur = 0;
            if (shortName != "TL")
            {
                XDocument xDoc = null;
                xDoc = XDocument.Load("https://www.tcmb.gov.tr/kurlar/today.xml");
                IEnumerable<System.Xml.Linq.XElement> curr = null;
                curr = from c in xDoc.Descendants("Currency") select c;
                CurrencyValueViewModel currencyValueViewModel = new CurrencyValueViewModel();
                foreach (XElement c in curr)
                {
                    string longName = c.Element("Isim").Value;
                    string shortNameXml = c.Attribute("Kod").Value;
                    if (shortNameXml == shortName)
                    {
                        List<CurrencyViewModel> currencyList = new List<CurrencyViewModel>();
                        var listCurrencyResult = await _currencyApi.GetActive();
                        if (listCurrencyResult.IsSuccessStatusCode &&
                            listCurrencyResult.Content.IsSuccess &&
                            listCurrencyResult.Content.ResultData.Any())
                            currencyList = _mapper.Map<List<CurrencyViewModel>>(listCurrencyResult.Content.ResultData);
                        currencyValueViewModel.ShortName = shortNameXml;
                        currencyValueViewModel.BuyingPrice = Convert.ToDecimal(c.Element("BanknoteBuying").Value.Replace(".", ","));
                        currencyValueViewModel.SalePrice = Convert.ToDecimal(c.Element("BanknoteSelling").Value.Replace(".", ","));
                        currencyValueViewModel.Date = DateTime.Now;
                        currencyValueViewModel.Id = currencyList.FirstOrDefault(x => x.ShortName == shortName).Id;
                        //kayıt et kuru admine de göster

                        CurrencyValueRequest currencyValueRequest = _mapper.Map<CurrencyValueRequest>(currencyValueViewModel);
                        var _currencyValueResult = await _currencyValueApi.Post(currencyValueRequest);


                        break;
                    }
                }

                if (currencyValueViewModel != null && currencyValueViewModel.SalePrice > 0)
                {
                    totalAmountKur = totalAmount / currencyValueViewModel.SalePrice;
                }
            }
            else
                totalAmountKur = totalAmount;
            return Json("Toplam Tutar:" +totalAmountKur.ToString("N2") +" "+  shortName);
        }




    }
}
