using Proje.Common.DTOs.DemandReason;
using Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]

    public interface IDemandReasonApi
    {
        [Get("/demandreason")]
        Task<ApiResponse<WebApiResponse<List<DemandReasonResponse>>>> List();

        [Get("/demandreason/{id}")]
        Task<ApiResponse<WebApiResponse<DemandReasonResponse>>> Get(Guid id);

        [Post("/demandreason")]
        Task<ApiResponse<WebApiResponse<DemandReasonResponse>>> Post(DemandReasonRequest request);

        [Put("/demandreason/{id}")]
        Task<ApiResponse<WebApiResponse<DemandReasonResponse>>> Put(Guid id, DemandReasonRequest request);

        [Delete("/demandreason/{id}")]
        Task<ApiResponse<WebApiResponse<DemandReasonResponse>>> Delete(Guid id);

        [Get("/demandreason/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/demandreason/getactive")]
        Task<ApiResponse<WebApiResponse<List<DemandReasonResponse>>>> GetActive();
    }
}
