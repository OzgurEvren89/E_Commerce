using Proje.Common.DTOs.OrderItem;
using Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]

    public interface IOrderItemApi
    {
        [Get("/orderitem")]
        Task<ApiResponse<WebApiResponse<List<OrderItemResponse>>>> List();

        [Get("/orderitem/{id}")]
        Task<ApiResponse<WebApiResponse<OrderItemResponse>>> Get(Guid id);

        [Post("/orderitem")]
        Task<ApiResponse<WebApiResponse<OrderItemResponse>>> Post(OrderItemRequest request);

        [Put("/orderitem/{id}")]
        Task<ApiResponse<WebApiResponse<OrderItemResponse>>> Put(Guid id, OrderItemRequest request);

        [Delete("/orderitem/{id}")]
        Task<ApiResponse<WebApiResponse<OrderItemResponse>>> Delete(Guid id);

        [Get("/orderitem/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/orderitem/getactive")]
        Task<ApiResponse<WebApiResponse<List<OrderItemResponse>>>> GetActive();
    }
}
