using Proje.Common.DTOs.DemandStatus;
using Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]

    public interface IDemandStatusApi
    {
        [Get("/demandstatus")]
        Task<ApiResponse<WebApiResponse<List<DemandStatusResponse>>>> List();

        [Get("/demandstatus/{id}")]
        Task<ApiResponse<WebApiResponse<DemandStatusResponse>>> Get(Guid id);

        [Post("/demandstatus")]
        Task<ApiResponse<WebApiResponse<DemandStatusResponse>>> Post(DemandStatusRequest request);

        [Put("/demandstatus/{id}")]
        Task<ApiResponse<WebApiResponse<DemandStatusResponse>>> Put(Guid id, DemandStatusRequest request);

        [Delete("/demandstatus/{id}")]
        Task<ApiResponse<WebApiResponse<DemandStatusResponse>>> Delete(Guid id);

        [Get("/demandstatus/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/demandstatus/getactive")]
        Task<ApiResponse<WebApiResponse<List<DemandStatusResponse>>>> GetActive();
    }
}
