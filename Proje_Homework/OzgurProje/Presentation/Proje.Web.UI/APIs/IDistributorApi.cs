using Proje.Common.DTOs. Distributor;
using Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]

    public interface IDistributorApi
    {
        [Get("/distributor")]
        Task<ApiResponse<WebApiResponse<List< DistributorResponse>>>> List();

        [Get("/distributor/{id}")]
        Task<ApiResponse<WebApiResponse< DistributorResponse>>> Get(Guid id);

        [Post("/distributor")]
        Task<ApiResponse<WebApiResponse< DistributorResponse>>> Post( DistributorRequest request);

        [Put("/distributor/{id}")]
        Task<ApiResponse<WebApiResponse< DistributorResponse>>> Put(Guid id,  DistributorRequest request);

        [Delete("/distributor/{id}")]
        Task<ApiResponse<WebApiResponse< DistributorResponse>>> Delete(Guid id);

        [Get("/distributor/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/distributor/getactive")]
        Task<ApiResponse<WebApiResponse<List< DistributorResponse>>>> GetActive();
    }
}
