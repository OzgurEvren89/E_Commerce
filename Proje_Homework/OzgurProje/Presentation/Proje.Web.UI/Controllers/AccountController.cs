using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proje.Common.DTOs.Login;
using Proje.Common.DTOs.User;
using Proje.Common.Extensions;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Infrasructure.Helpers;
using Proje.Web.UI.Models.AccountViewModels;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Proje.Web.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IUserApi _userApi;
        private readonly IAccountApi _accountApi;
        private readonly IMapper _mapper;

        public AccountController(IWebHostEnvironment env, IUserApi userApi, IAccountApi accountApi, IMapper mapper)
        {
            _env = env;
            _userApi = userApi;
            _accountApi = accountApi;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel request)
        {
            if (ModelState.IsValid)
            {
                var loginRequest = await _accountApi.Login(_mapper.Map<LoginRequest>(request));
                if (loginRequest.IsSuccessStatusCode && loginRequest.Content.IsSuccess)
                {
                    UserResponse user = loginRequest.Content.ResultData;
                    var claims = new List<Claim>()
                    {
                        new Claim("Id",user.Id.ToString()),
                        new Claim(ClaimTypes.Name,user.FirstName),
                        new Claim(ClaimTypes.Surname,user.LastName),
                        new Claim(ClaimTypes.Email,user.Email),
                        new Claim("Image",user.ImageUrl),
                        new Claim("Title",user.Title)
                    };
                    //Giriş işlemlerini tamamlıyoruz ve kullanıcıyı yönetici sayfasına yönlendiriyoruz....
                    var userIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                   

                    var serializedData = System.Text.Json.JsonSerializer.Serialize(user);
                    HttpContext.Response.Cookies.Append("ProjeAccessToken", serializedData.Encrypt());

                    //using Microsoft.AspNetCore.Authentication;
                    await HttpContext.SignInAsync(principal);
                    if (user.Title== "Admin")
                        return RedirectToAction("Index", "Home", new { area = "Admin" });//!!!işte burada area ya giriyor. 
                    else
                        return RedirectToAction("Index", "Home", new { area = "" });
                }
            }
            return View(request);
        }

        public async Task<IActionResult> Logout()
        {
            HttpContext.Response.Cookies.Delete("ProjeAccessToken");
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        [HttpGet]
        public IActionResult InsertUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InsertUser(CreateUserVM item, List<IFormFile> files)
        {
            if (ModelState.IsValid)
            {
                bool imageResult;
                string imagePath = Upload.ImageUpload(files, _env, out imageResult);
                if (imageResult)
                    item.ImageUrl = imagePath;
                else
                {
                    TempData["Message"] = imagePath;
                    return View();
                }

                var insertResult = await _userApi.Post(_mapper.Map<UserRequest>(item));
                if (insertResult.IsSuccessStatusCode && insertResult.Content.IsSuccess && insertResult.Content.ResultData != null)
                    return RedirectToAction("Login", "Account", new { area = "" });
                else
                    TempData["Message"] = "Kayıt işlemi sırasında bir hata oluştu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";
            }
            else
                TempData["Message"] = "İşlem başarısız oldu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";
            return View();
        }
    }
}
