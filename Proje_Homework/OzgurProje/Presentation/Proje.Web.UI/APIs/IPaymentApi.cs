using Proje.Common.DTOs.Payment;
using Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]

    public interface IPaymentApi
    {

        [Get("/payment")]
        Task<ApiResponse<WebApiResponse<List<PaymentResponse>>>> List();

        [Get("/payment/{id}")]
        Task<ApiResponse<WebApiResponse<PaymentResponse>>> Get(Guid id);

        [Post("/payment")]
        Task<ApiResponse<WebApiResponse<PaymentResponse>>> Post(PaymentRequest request);

        [Put("/payment/{id}")]
        Task<ApiResponse<WebApiResponse<PaymentResponse>>> Put(Guid id, PaymentRequest request);

        [Delete("/payment/{id}")]
        Task<ApiResponse<WebApiResponse<PaymentResponse>>> Delete(Guid id);

        [Get("/payment/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/payment/getactive")]
        Task<ApiResponse<WebApiResponse<List<PaymentResponse>>>> GetActive();
    }
}
