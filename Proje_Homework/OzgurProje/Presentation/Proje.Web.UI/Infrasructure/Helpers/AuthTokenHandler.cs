using Proje.Common.DTOs.User;
using Proje.Common.Extensions;
using Proje.Web.UI.APIs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Proje.Web.UI.Infrasructure.Helpers
{
    public class AuthTokenHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAccountApi _accountApi;

        public AuthTokenHandler(
            IHttpContextAccessor httpContextAccessor,
            IAccountApi accountApi)
        {
            _httpContextAccessor = httpContextAccessor;
            _accountApi = accountApi;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (_httpContextAccessor.HttpContext.Request.Cookies.ContainsKey("ProjeAccessToken"))
            {
                var cookieData = _httpContextAccessor.HttpContext.Request.Cookies["ProjeAccessToken"].Decrypt();
                var user = System.Text.Json.JsonSerializer.Deserialize<UserResponse>(cookieData);
                if (user.AccessToken.Expires <= DateTime.Now.ToUnixTime())
                {
                    var getAccessTokenResult = await _accountApi.RefreshToken(new Common.Models.RefreshToken
                    {
                        Email = user.Email,
                        Refresh_Token = user.AccessToken.RefreshToken
                    });
                    if (getAccessTokenResult.IsSuccessStatusCode && getAccessTokenResult.Content.IsSuccess)
                    {
                        var getAccessToken = getAccessTokenResult.Content.ResultData;
                        user.AccessToken = getAccessToken;

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

                        _httpContextAccessor.HttpContext.Response.Cookies.Append("ProjeAccessToken", System.Text.Json.JsonSerializer.Serialize<UserResponse>(user).Encrypt());
                        //using Microsoft.AspNetCore.Authentication;
                        await _httpContextAccessor.HttpContext.SignInAsync(principal);

                        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", user.AccessToken.AccessToken);
                    }
                }
                else
                {
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", user.AccessToken.AccessToken);
                }
            }
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
