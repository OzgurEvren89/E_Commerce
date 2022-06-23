using Proje.Common.DTOs.CartItem;
using Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]

    public interface ICartItemApi
    {
        [Get("/cartitem")]
        Task<ApiResponse<WebApiResponse<List<CartItemResponse>>>> List();

        [Get("/cartitem/{id}")]
        Task<ApiResponse<WebApiResponse<CartItemResponse>>> Get(Guid id);

        [Post("/cartitem")]
        Task<ApiResponse<WebApiResponse<CartItemResponse>>> Post(CartItemRequest request);

        [Put("/cartitem/{id}")]
        Task<ApiResponse<WebApiResponse<CartItemResponse>>> Put(Guid id, CartItemRequest request);

        [Delete("/cartitem/{id}")]
        Task<ApiResponse<WebApiResponse<CartItemResponse>>> Delete(Guid id);

        [Get("/cartitem/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/cartitem/getactive")]
        Task<ApiResponse<WebApiResponse<List<CartItemResponse>>>> GetActive();
    }
}
