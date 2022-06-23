using Proje.Common.DTOs.DistributorToProduct;
using Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]

    public interface IDistributorToProductApi
    {
        [Get("/distributortoproduct")]
        Task<ApiResponse<WebApiResponse<List<DistributorToProductResponse>>>> List();

        [Get("/distributortoproduct/{id}")]
        Task<ApiResponse<WebApiResponse<DistributorToProductResponse>>> Get(Guid id);

        [Post("/distributortoproduct")]
        Task<ApiResponse<WebApiResponse<DistributorToProductResponse>>> Post(DistributorToProductRequest request);

        [Put("/distributortoproduct/{id}")]
        Task<ApiResponse<WebApiResponse<DistributorToProductResponse>>> Put(Guid id, DistributorToProductRequest request);

        [Delete("/distributortoproduct/{id}")]
        Task<ApiResponse<WebApiResponse<DistributorToProductResponse>>> Delete(Guid id);

        [Get("/distributortoproduct/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/distributortoproduct/getactive")]
        Task<ApiResponse<WebApiResponse<List<DistributorToProductResponse>>>> GetActive();
    }
}
