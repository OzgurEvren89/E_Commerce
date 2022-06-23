using Proje.Common.DTOs.CurrencyValue;
using Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]

    public interface ICurrencyValueApi
    {
        [Get("/currencyvalue")]
        Task<ApiResponse<WebApiResponse<List<CurrencyValueResponse>>>> List();

        [Get("/currencyvalue/{id}")]
        Task<ApiResponse<WebApiResponse<CurrencyValueResponse>>> Get(Guid id);

        [Post("/currencyvalue")]
        Task<ApiResponse<WebApiResponse<CurrencyValueResponse>>> Post(CurrencyValueRequest request);

        [Put("/currencyvalue/{id}")]
        Task<ApiResponse<WebApiResponse<CurrencyValueResponse>>> Put(Guid id, CurrencyValueRequest request);

        [Delete("/currencyvalue/{id}")]
        Task<ApiResponse<WebApiResponse<CurrencyValueResponse>>> Delete(Guid id);

        [Get("/currencyvalue/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/currencyvalue/getactive")]
        Task<ApiResponse<WebApiResponse<List<CurrencyValueResponse>>>> GetActive();
    }
}
