using Proje.Common.DTOs.User;
using Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface IUserApi
    {
        [Get("/user")]
        Task<ApiResponse<WebApiResponse<List<UserResponse>>>> List();

        [Get("/user/{id}")]
        Task<ApiResponse<WebApiResponse<UserResponse>>> Get(Guid id);

        [Post("/user")]
        Task<ApiResponse<WebApiResponse<UserResponse>>> Post(UserRequest request);

        [Put("/user/{id}")]
        Task<ApiResponse<WebApiResponse<UserResponse>>> Put(Guid id, UserRequest request);

        [Delete("/user/{id}")]
        Task<ApiResponse<WebApiResponse<UserResponse>>> Delete(Guid id);

        [Get("/user/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/user/getactive")]
        Task<ApiResponse<WebApiResponse<List<UserResponse>>>> GetActive();

        [Get("/user/getcartuser")]
        Task<ApiResponse<WebApiResponse<UserResponse>>> GetCartUser();
    }
}
