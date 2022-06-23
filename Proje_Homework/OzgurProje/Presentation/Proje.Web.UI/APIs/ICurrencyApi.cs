using Proje.Common.DTOs.Currency;
using Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]

    public interface ICurrencyApi
    {
        [Get("/currency")]
        Task<ApiResponse<WebApiResponse<List<CurrencyResponse>>>> List();

        [Get("/currency/{id}")]
        Task<ApiResponse<WebApiResponse<CurrencyResponse>>> Get(Guid id);

        [Post("/currency")]
        Task<ApiResponse<WebApiResponse<CurrencyResponse>>> Post(CurrencyRequest request);

        [Put("/currency/{id}")]
        Task<ApiResponse<WebApiResponse<CurrencyResponse>>> Put(Guid id, CurrencyRequest request);

        [Delete("/currency/{id}")]
        Task<ApiResponse<WebApiResponse<CurrencyResponse>>> Delete(Guid id);

        [Get("/currency/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/currency/getactive")]
        Task<ApiResponse<WebApiResponse<List<CurrencyResponse>>>> GetActive();
    }
}
