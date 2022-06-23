using Proje.Common.DTOs.Login;
using Proje.Common.DTOs.User;
using Proje.Common.Models;
using Refit;
using System.Threading.Tasks;

namespace Proje.Web.UI.APIs
{
    [Headers("Content-Type: application/json")]
    public interface IAccountApi
    {
        [Get("/account/login")]
        Task<ApiResponse<WebApiResponse<UserResponse>>> Login(LoginRequest request);

        [Get("/account/refreshtoken")]
        Task<ApiResponse<WebApiResponse<GetAccessToken>>> RefreshToken(RefreshToken request);
    }
}
