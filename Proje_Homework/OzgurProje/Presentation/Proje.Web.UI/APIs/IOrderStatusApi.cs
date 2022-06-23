using Proje.Common.DTOs.OrderStatus;
using Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]

    public interface IOrderStatusApi
    {
        [Get("/orderstatus")]
        Task<ApiResponse<WebApiResponse<List<OrderStatusResponse>>>> List();

        [Get("/orderstatus/{id}")]
        Task<ApiResponse<WebApiResponse<OrderStatusResponse>>> Get(Guid id);

        [Post("/orderstatus")]
        Task<ApiResponse<WebApiResponse<OrderStatusResponse>>> Post(OrderStatusRequest request);

        [Put("/orderstatus/{id}")]
        Task<ApiResponse<WebApiResponse<OrderStatusResponse>>> Put(Guid id, OrderStatusRequest request);

        [Delete("/orderstatus/{id}")]
        Task<ApiResponse<WebApiResponse<OrderStatusResponse>>> Delete(Guid id);

        [Get("/orderstatus/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/orderstatus/getactive")]
        Task<ApiResponse<WebApiResponse<List<OrderStatusResponse>>>> GetActive();
    }
}
