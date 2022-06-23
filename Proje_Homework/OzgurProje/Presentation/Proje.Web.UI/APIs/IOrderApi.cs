using Proje.Common.DTOs.Order;
using Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]

    public interface IOrderApi
    {
        [Get("/order")]
        Task<ApiResponse<WebApiResponse<List<OrderResponse>>>> List();

        [Get("/order/{id}")]
        Task<ApiResponse<WebApiResponse<OrderResponse>>> Get(Guid id);

        [Post("/order")]
        Task<ApiResponse<WebApiResponse<OrderResponse>>> Post(OrderRequest request);

        [Put("/order/{id}")]
        Task<ApiResponse<WebApiResponse<OrderResponse>>> Put(Guid id, OrderRequest request);

        [Delete("/order/{id}")]
        Task<ApiResponse<WebApiResponse<OrderResponse>>> Delete(Guid id);

        [Get("/order/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/order/getactive")]
        Task<ApiResponse<WebApiResponse<List<OrderResponse>>>> GetActive();
    }
}
