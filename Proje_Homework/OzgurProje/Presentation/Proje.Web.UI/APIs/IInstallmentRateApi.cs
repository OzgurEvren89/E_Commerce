using Proje.Common.DTOs.InstallmentRate;
using Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]

    public interface IInstallmentRateApi
    {
        [Get("/installmentrate")]
        Task<ApiResponse<WebApiResponse<List<InstallmentRateResponse>>>> List();

        [Get("/installmentrate/{id}")]
        Task<ApiResponse<WebApiResponse<InstallmentRateResponse>>> Get(Guid id);

        [Post("/installmentrate")]
        Task<ApiResponse<WebApiResponse<InstallmentRateResponse>>> Post(InstallmentRateRequest request);

        [Put("/installmentrate/{id}")]
        Task<ApiResponse<WebApiResponse<InstallmentRateResponse>>> Put(Guid id, InstallmentRateRequest request);

        [Delete("/installmentrate/{id}")]
        Task<ApiResponse<WebApiResponse<InstallmentRateResponse>>> Delete(Guid id);

        [Get("/installmentrate/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/installmentrate/getactive")]
        Task<ApiResponse<WebApiResponse<List<InstallmentRateResponse>>>> GetActive();
    }
}
