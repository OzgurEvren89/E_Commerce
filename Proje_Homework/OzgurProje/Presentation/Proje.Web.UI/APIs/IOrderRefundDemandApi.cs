using Proje.Common.DTOs.OrderRefundDemand;
using Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]

    public interface IOrderRefundDemandApi
    {
        [Get("/orderrefunddemand")]
        Task<ApiResponse<WebApiResponse<List<OrderRefundDemandResponse>>>> List();

        [Get("/orderrefunddemand/{id}")]
        Task<ApiResponse<WebApiResponse<OrderRefundDemandResponse>>> Get(Guid id);

        [Post("/orderrefunddemand")]
        Task<ApiResponse<WebApiResponse<OrderRefundDemandResponse>>> Post(OrderRefundDemandRequest request);

        [Put("/orderrefunddemand/{id}")]
        Task<ApiResponse<WebApiResponse<OrderRefundDemandResponse>>> Put(Guid id, OrderRefundDemandRequest request);

        [Delete("/orderrefunddemand/{id}")]
        Task<ApiResponse<WebApiResponse<OrderRefundDemandResponse>>> Delete(Guid id);

        [Get("/orderrefunddemand/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/orderrefunddemand/getactive")]
        Task<ApiResponse<WebApiResponse<List<OrderRefundDemandResponse>>>> GetActive();
    }
}
