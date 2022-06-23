using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proje.Common.DTOs.Cart;
using Proje.Common.DTOs.CartItem;
using Proje.Common.DTOs.User;
using Proje.Common.WorkContext;
using Proje.Common.Extensions;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.CartItemViewModels;
using Proje.Web.UI.Areas.Admin.Models.CartViewModels;
using Proje.Web.UI.Areas.Admin.Models.ProductViewModels;
using Proje.Web.UI.Infrasructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Proje.Web.UI.Areas.Admin.Models.UserViewModels;

namespace Proje.Web.UI.Controllers
{
    public class CartsController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _env;
        private readonly ICartApi _cartApi;
        private readonly ICartItemApi _cartItemApi;
        private readonly IProductApi _productApi;
        private readonly IUserApi _userApi;
        private readonly IMapper _mapper;

        public CartsController(IHttpContextAccessor httpContextAccessor, IWebHostEnvironment env, ICartApi cartApi, ICartItemApi cartItemApi, IProductApi productApi, IUserApi userApi, IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _env = env;
            _cartApi = cartApi;
            _cartItemApi = cartItemApi;
            _productApi = productApi;
            _userApi = userApi;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            UserViewModel user = new UserViewModel();
            var userResult = await _userApi.GetCartUser();
            if (userResult.IsSuccessStatusCode && userResult.Content.IsSuccess)
                user = _mapper.Map<UserViewModel>(userResult.Content.ResultData);

            if (user == null || user.Id == null || user.Id == Guid.Empty)
            {
                TempData["Message"] = "Sepete Girebilmeniz içn önce giriş yapmanız gerekmektedir!...Hesabınız yok ise lütfen kayıt olup tekrar deneyiniz...";
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        public async Task<IActionResult> List()
        {
            UserViewModel user = new UserViewModel();
            var userResult = await _userApi.GetCartUser();
            if (userResult.IsSuccessStatusCode && userResult.Content.IsSuccess)
                user = _mapper.Map<UserViewModel>(userResult.Content.ResultData);

            if (user == null || user.Id == null || user.Id == Guid.Empty)
            {
                TempData["Message"] = "Sepete Girebilmeniz içn önce giriş yapmanız gerekmektedir!...Hesabınız yok ise lütfen kayıt olup tekrar deneyiniz...";
                return RedirectToAction("Login", "Account");
            }

            else
            {
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
                    
                    return Json(list);
                }
            }
            TempData["Message"] = "Sepetinizde Ürün Bulunmamaktadır...";

            return Json(new List<CartItemViewModel>());
        }

        public async Task<IActionResult> Add(Guid id)
        {

            ProductViewModel product = new ProductViewModel();
            var proResult = await _productApi.Get(id);
            if (proResult.IsSuccessStatusCode && proResult.Content.IsSuccess)
                product = _mapper.Map<ProductViewModel>(proResult.Content.ResultData);//ürünümün id,si
          

            UserViewModel user = new UserViewModel();
            var userResult = await _userApi.GetCartUser();
            if (userResult.IsSuccessStatusCode && userResult.Content.IsSuccess)
                user = _mapper.Map<UserViewModel>(userResult.Content.ResultData);


            if (user == null || user.Id == null || user.Id == Guid.Empty)
            {
                TempData["Message"] = "Sepete Girebilmeniz içn önce giriş yapmanız gerekmektedir!...Hesabınız yok ise lütfen kayıt olup tekrar deneyiniz...";
                return RedirectToAction("Login", "Account");
            }

            else
            {

                string userName = user.Id.ToString();
               
                if (Request.Cookies.Where(x => x.Key.Contains(userName)).Count() > 0 )//Cookiem var ise
                {

                    CartHelper cartHelper = new CartHelper(new CartViewModel());

                    List<CartItemViewModel> cartItemlist = new List<CartItemViewModel>();
                    var cookies = HttpContext.Request.Cookies.Where(x => x.Key.Contains(userName)).ToList();

                    if (cookies != null && cookies.Count() > 0)
                    {

                        foreach (var cokkieItem in cookies)
                        {
                            string strCart = cokkieItem.Value.Decrypt();
                            cartHelper = JsonConvert.DeserializeObject<CartHelper>(strCart);//cartHelperımı çözdüm
                            

                            cartItemlist.AddRange(cartHelper.Cart.CartItems.ToList());
                        }
                        cartHelper.Cart.CartItems = cartItemlist;
                    }

                    CartViewModel cartViewModel = new CartViewModel();//Cart Nesnem Dolumu Değilmi ona bakıp dolysa eskisini değilse sıfırdan oluşturup atayacağım. 

                    if (cartHelper.Cart.Id == Guid.Empty)
                    {
                        CreateCartViewModel createCartViewModel = new CreateCartViewModel();
                        var insertCartResult = await _cartApi.Post(_mapper.Map<CartRequest>(createCartViewModel));//birtane cart nesnesi oluşturdum boş.
                        if (insertCartResult.IsSuccessStatusCode && insertCartResult.Content.IsSuccess)
                            cartViewModel = _mapper.Map<CartViewModel>(insertCartResult.Content.ResultData);
                    }
                    else
                    {
                       cartViewModel = cartHelper.Cart;//yeni bir kart helper oluşturdum ve eski herşeyi buna atadım.dolu olduğundan

                    }

                    CartItemViewModel requestcartItemViewModel = cartViewModel.CartItems.FirstOrDefault(x => x.ProductId == id);
                    CartItemViewModel cartItemViewModel = new CartItemViewModel();
                    Guid productID;

                    if (requestcartItemViewModel == null)//hiç yok ise cartitem'ım yeni bir CartHelper oluşturacağım
                    {

                        var insertCartItemResult = await _cartItemApi.Post(_mapper.Map<CartItemRequest>(new CreateCartItemViewModel() { ProductId = id, CartId = cartViewModel.Id, Quantity = 1 }));
                        if (insertCartItemResult.IsSuccessStatusCode && insertCartItemResult.Content.IsSuccess)
                            cartItemViewModel = _mapper.Map<CartItemViewModel>(insertCartItemResult.Content.ResultData);

                        cartItemViewModel.Product = product;
                        cartHelper.Cart.CartItems.Clear();
                        cartHelper.AddCart(cartItemViewModel);
                        productID = cartItemViewModel.ProductId;
                    }
                    else//CartItem'im  varsa eskisinin üzerine sayı eklemeyi yapacak sadece 
                    {
                        cartHelper.Cart.CartItems.Clear();
                        cartHelper.Cart.CartItems.Add(requestcartItemViewModel);
                        cartHelper.AddCart(requestcartItemViewModel);
                        productID = requestcartItemViewModel.ProductId;
                    }


                    string key = userName + "/" + productID;
                    string value = JsonConvert.SerializeObject(cartHelper).Encrypt();
                    var cookieOptions = new CookieOptions()
                    {
                        Path = "/",
                        HttpOnly = false,
                        IsEssential = true,
                        Expires = DateTime.Now.AddMonths(1)

                    };

                    HttpContext.Response.Cookies.Append(key, value, cookieOptions);

                }
                else
                {
                    CreateCartViewModel createCartViewModel = new CreateCartViewModel();
                    CartViewModel cartViewModel = new CartViewModel();
                    var insertCartResult = await _cartApi.Post(_mapper.Map<CartRequest>(createCartViewModel));//birtane cart nesnesi oluşturdum boş.
                    if (insertCartResult.IsSuccessStatusCode && insertCartResult.Content.IsSuccess)
                        cartViewModel = _mapper.Map<CartViewModel>(insertCartResult.Content.ResultData);

                    CartItemViewModel cartItemViewModel = new CartItemViewModel();
                    var insertCartItemResult = await _cartItemApi.Post(_mapper.Map<CartItemRequest>(new CreateCartItemViewModel() { ProductId = id, CartId = cartViewModel.Id, Quantity = 1 }));
                    if (insertCartItemResult.IsSuccessStatusCode && insertCartItemResult.Content.IsSuccess)
                        cartItemViewModel = _mapper.Map<CartItemViewModel>(insertCartItemResult.Content.ResultData);

                    cartItemViewModel.Product = product;//cartItem'a id'den gelen ürünü atadım.            
                    CartHelper cartHelper = new CartHelper(cartViewModel); // yukarıdaki cartviewModelimi carthelper'da tanımladım
                    cartHelper.AddCart(cartItemViewModel);//cartitem dizime eklemeyi yaptım

                    //user ıd adında benzersiz sepetimi oluşturacağım.
                    string key = user.Id.ToString() + "/" + cartItemViewModel.ProductId;

                    var cookieValue = Request.Cookies[key];
                    if (cookieValue == null)
                    {
                        string value = JsonConvert.SerializeObject(cartHelper).Encrypt();
                        var cookieOptions = new CookieOptions()
                        {
                            Path = "/",
                            HttpOnly = false,
                            IsEssential = true,
                            Expires = DateTime.Now.AddMonths(1)
                        };

                        HttpContext.Response.Cookies.Append(key, value, cookieOptions);
                    }

                }

                //return RedirectToAction("Index", "Home", new { area = "" });
                return Json("Empty");
            }
        }

        public async Task<IActionResult> IncreaseCart(string strId)
        {

            Guid id = Guid.Parse(strId);
            ProductViewModel product = new ProductViewModel();
            var proResult = await _productApi.Get(id);
            if (proResult.IsSuccessStatusCode && proResult.Content.IsSuccess)
                product = _mapper.Map<ProductViewModel>(proResult.Content.ResultData);//ürünümün id,si


            //List<ProductPriceViewModel> productPrices = new List<ProductPriceViewModel>();
            //var proPriceResult = await _productPriceApi.GetActive();
            //if (proResult.IsSuccessStatusCode && proResult.Content.IsSuccess)
            //    productPrices = _mapper.Map<List<ProductPriceViewModel>>(proPriceResult.Content.ResultData);
            //productPrices = productPrices.Where(x => x.ProductId == id).ToList();

            //product.ProductPrices = productPrices;

            //string userName = ClaimsPrincipal.

            UserViewModel user = new UserViewModel();
            var userResult = await _userApi.GetCartUser();
            if (userResult.IsSuccessStatusCode && userResult.Content.IsSuccess)
                user = _mapper.Map<UserViewModel>(userResult.Content.ResultData);

            string userName = user.Id.ToString();

            CartHelper cartHelper = new CartHelper(new CartViewModel());
            List<CartItemViewModel> cartItemlist = new List<CartItemViewModel>();
            var cookies = HttpContext.Request.Cookies.Where(x => x.Key.Contains(userName)).ToList();
            if (cookies != null && cookies.Count() > 0)
            {
                foreach (var cokkieItem in cookies)
                {
                    string strCart = cokkieItem.Value.Decrypt();
                    cartHelper = JsonConvert.DeserializeObject<CartHelper>(strCart);
                    cartItemlist.AddRange(cartHelper.Cart.CartItems.ToList());
                }
                cartHelper.Cart.CartItems = cartItemlist;
            }
            var cartViewModel = cartHelper.Cart;//yeni bir kart helper oluşturdum ve eski herşeyi buna atadım.

            CartItemViewModel requestcartItemViewModel = cartViewModel.CartItems.FirstOrDefault(x => x.ProductId == id);
            Guid productID;


            cartHelper.Cart.CartItems.Clear();
            cartHelper.Cart.CartItems.Add(requestcartItemViewModel);
            cartHelper.AddCart(requestcartItemViewModel);
            productID = requestcartItemViewModel.ProductId;



            string key = userName + "/" + productID;
            string value = JsonConvert.SerializeObject(cartHelper).Encrypt();
            var cookieOptions = new CookieOptions()
            {
                Path = "/",
                HttpOnly = false,
                IsEssential = true,
                Expires = DateTime.Now.AddMonths(1)

            };

            HttpContext.Response.Cookies.Append(key, value, cookieOptions);


            return Json("Empty");
            //return RedirectToAction("List", "Carts", new { area = "" });

        }





        public async Task<IActionResult> DecreaseCart(string strId)
        {

            Guid id = Guid.Parse(strId);
            ProductViewModel product = new ProductViewModel();
            var proResult = await _productApi.Get(id);
            if (proResult.IsSuccessStatusCode && proResult.Content.IsSuccess)
                product = _mapper.Map<ProductViewModel>(proResult.Content.ResultData);//ürünümün id,si


            //List<ProductPriceViewModel> productPrices = new List<ProductPriceViewModel>();
            //var proPriceResult = await _productPriceApi.GetActive();
            //if (proResult.IsSuccessStatusCode && proResult.Content.IsSuccess)
            //    productPrices = _mapper.Map<List<ProductPriceViewModel>>(proPriceResult.Content.ResultData);
            //productPrices = productPrices.Where(x => x.ProductId == id).ToList();

            //product.ProductPrices = productPrices;

            //string userName = ClaimsPrincipal.

            UserViewModel user = new UserViewModel();
            var userResult = await _userApi.GetCartUser();
            if (userResult.IsSuccessStatusCode && userResult.Content.IsSuccess)
                user = _mapper.Map<UserViewModel>(userResult.Content.ResultData);

            string userName = user.Id.ToString();

            CartHelper cartHelper = new CartHelper(new CartViewModel());
            List<CartItemViewModel> cartItemlist = new List<CartItemViewModel>();
            var cookies = HttpContext.Request.Cookies.Where(x => x.Key.Contains(userName)).ToList();
            if (cookies != null && cookies.Count() > 0)
            {
                foreach (var cokkieItem in cookies)
                {
                    string strCart = cokkieItem.Value.Decrypt();
                    cartHelper = JsonConvert.DeserializeObject<CartHelper>(strCart);
                    cartItemlist.AddRange(cartHelper.Cart.CartItems.ToList());

                }
                cartHelper.Cart.CartItems = cartItemlist;
            }
            var cartViewModel = cartHelper.Cart;//yeni bir kart helper oluşturdum ve eski herşeyi buna atadım.

            CartItemViewModel requestcartItemViewModel = cartViewModel.CartItems.FirstOrDefault(x => x.ProductId == id);
            Guid productID;


            cartHelper.Cart.CartItems.Clear();
            cartHelper.Cart.CartItems.Add(requestcartItemViewModel);
            cartHelper.DecreaseCart(requestcartItemViewModel.Id);
            productID = requestcartItemViewModel.ProductId;



            string key = userName + "/" + productID;
            string value = JsonConvert.SerializeObject(cartHelper).Encrypt();
            var cookieOptions = new CookieOptions()
            {
                Path = "/",
                HttpOnly = false,
                IsEssential = true,
                Expires = DateTime.Now.AddMonths(1)

            };

            HttpContext.Response.Cookies.Append(key, value, cookieOptions);


            return Json("Empty");
            //return RedirectToAction("List", "Carts", new { area = "" });

        }

        public async Task<IActionResult> RemoveCart(string strId)
        {


            Guid id = Guid.Parse(strId);
            ProductViewModel product = new ProductViewModel();
            var proResult = await _productApi.Get(id);
            if (proResult.IsSuccessStatusCode && proResult.Content.IsSuccess)
                product = _mapper.Map<ProductViewModel>(proResult.Content.ResultData);//ürünümün id,si

            //string userName = ClaimsPrincipal.

            UserViewModel user = new UserViewModel();
            var userResult = await _userApi.GetCartUser();
            if (userResult.IsSuccessStatusCode && userResult.Content.IsSuccess)
                user = _mapper.Map<UserViewModel>(userResult.Content.ResultData);

            string userName = user.Id.ToString();

            CartHelper cartHelper = new CartHelper(new CartViewModel());
            List<CartItemViewModel> cartItemlist = new List<CartItemViewModel>();
            var cookies = HttpContext.Request.Cookies.Where(x => x.Key.Contains(userName)).ToList();
            if (cookies != null && cookies.Count() > 0)
            {
                foreach (var cokkieItem in cookies)
                {
                    string strCart = cokkieItem.Value.Decrypt();
                    cartHelper = JsonConvert.DeserializeObject<CartHelper>(strCart);
                    cartItemlist.AddRange(cartHelper.Cart.CartItems.ToList());
                }
                cartHelper.Cart.CartItems = cartItemlist;
            }
            var cartViewModel = cartHelper.Cart;//yeni bir kart helper oluşturdum ve eski herşeyi buna atadım.

            CartItemViewModel requestcartItemViewModel = cartViewModel.CartItems.FirstOrDefault(x => x.ProductId == id);
            Guid productID;


            cartHelper.Cart.CartItems.Clear();
            cartHelper.Cart.CartItems.Add(requestcartItemViewModel);
            cartHelper.RemoveCart(requestcartItemViewModel.Id);
            productID = requestcartItemViewModel.ProductId;



            string key = userName + "/" + productID;
            //string value = JsonConvert.SerializeObject(cartHelper).Encrypt();
            var cookieOptions = new CookieOptions()
            {
                Path = "/",
                HttpOnly = false,
                IsEssential = true,
                Expires = DateTime.Now.AddMonths(-1)

            };

            //HttpContext.Response.Cookies.Append(key, value, cookieOptions);
            HttpContext.Response.Cookies.Delete(key, cookieOptions);



            return Json("Empty");
            //return RedirectToAction("List", "Carts", new { area = "" });

        }

    }
}
