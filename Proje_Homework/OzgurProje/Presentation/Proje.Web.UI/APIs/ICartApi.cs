using Proje.Common.DTOs.Cart;
using Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]

    public interface ICartApi
    {
        [Get("/cart")]
        Task<ApiResponse<WebApiResponse<List<CartResponse>>>> List();

        [Get("/cart/{id}")]
        Task<ApiResponse<WebApiResponse<CartResponse>>> Get(Guid id);

        [Post("/cart")]
        Task<ApiResponse<WebApiResponse<CartResponse>>> Post(CartRequest request);

        [Put("/cart/{id}")]
        Task<ApiResponse<WebApiResponse<CartResponse>>> Put(Guid id, CartRequest request);

        [Delete("/cart/{id}")]
        Task<ApiResponse<WebApiResponse<CartResponse>>> Delete(Guid id);

        [Get("/cart/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/cart/getactive")]
        Task<ApiResponse<WebApiResponse<List<CartResponse>>>> GetActive();
    }
}
