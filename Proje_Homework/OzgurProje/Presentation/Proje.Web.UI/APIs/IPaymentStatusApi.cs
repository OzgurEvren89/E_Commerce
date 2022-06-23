using Proje.Common.DTOs.PaymentStatus;
using Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]

    public interface IPaymentStatusApi
    {
        [Get("/paymentstatus")]
        Task<ApiResponse<WebApiResponse<List<PaymentStatusResponse>>>> List();

        [Get("/paymentstatus/{id}")]
        Task<ApiResponse<WebApiResponse<PaymentStatusResponse>>> Get(Guid id);

        [Post("/paymentstatus")]
        Task<ApiResponse<WebApiResponse<PaymentStatusResponse>>> Post(PaymentStatusRequest request);

        [Put("/paymentstatus/{id}")]
        Task<ApiResponse<WebApiResponse<PaymentStatusResponse>>> Put(Guid id, PaymentStatusRequest request);

        [Delete("/paymentstatus/{id}")]
        Task<ApiResponse<WebApiResponse<PaymentStatusResponse>>> Delete(Guid id);

        [Get("/paymentstatus/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/paymentstatus/getactive")]
        Task<ApiResponse<WebApiResponse<List<PaymentStatusResponse>>>> GetActive();
    }
}
