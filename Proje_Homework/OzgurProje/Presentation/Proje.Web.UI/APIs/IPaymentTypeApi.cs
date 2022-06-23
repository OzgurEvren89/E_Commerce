using Proje.Common.DTOs.PaymentType;
using Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]

    public interface IPaymentTypeApi
    {
        [Get("/paymenttype")]
        Task<ApiResponse<WebApiResponse<List<PaymentTypeResponse>>>> List();

        [Get("/paymenttype/{id}")]
        Task<ApiResponse<WebApiResponse<PaymentTypeResponse>>> Get(Guid id);

        [Post("/paymenttype")]
        Task<ApiResponse<WebApiResponse<PaymentTypeResponse>>> Post(PaymentTypeRequest request);

        [Put("/paymenttype/{id}")]
        Task<ApiResponse<WebApiResponse<PaymentTypeResponse>>> Put(Guid id, PaymentTypeRequest request);

        [Delete("/paymenttype/{id}")]
        Task<ApiResponse<WebApiResponse<PaymentTypeResponse>>> Delete(Guid id);

        [Get("/paymenttype/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/paymenttype/getactive")]
        Task<ApiResponse<WebApiResponse<List<PaymentTypeResponse>>>> GetActive();
    }
}
