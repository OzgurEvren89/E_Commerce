using Proje.Common.DTOs.PaymentGateway;
using Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]

    public interface IPaymentGatewayApi
    {
        [Get("/paymentgateway")]
        Task<ApiResponse<WebApiResponse<List<PaymentGatewayResponse>>>> List();

        [Get("/paymentgateway/{id}")]
        Task<ApiResponse<WebApiResponse<PaymentGatewayResponse>>> Get(Guid id);

        [Post("/paymentgateway")]
        Task<ApiResponse<WebApiResponse<PaymentGatewayResponse>>> Post(PaymentGatewayRequest request);

        [Put("/paymentgateway/{id}")]
        Task<ApiResponse<WebApiResponse<PaymentGatewayResponse>>> Put(Guid id, PaymentGatewayRequest request);

        [Delete("/paymentgateway/{id}")]
        Task<ApiResponse<WebApiResponse<PaymentGatewayResponse>>> Delete(Guid id);

        [Get("/paymentgateway/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/paymentgateway/getactive")]
        Task<ApiResponse<WebApiResponse<List<PaymentGatewayResponse>>>> GetActive();
    }
}
