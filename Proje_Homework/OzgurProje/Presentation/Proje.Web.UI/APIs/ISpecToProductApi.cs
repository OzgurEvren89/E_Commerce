using Proje.Common.DTOs.SpecToProduct;
using Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]

    public interface ISpecToProductApi
    {
        [Get("/spectoproduct")]
        Task<ApiResponse<WebApiResponse<List<SpecToProductResponse>>>> List();

        [Get("/spectoproduct/{id}")]
        Task<ApiResponse<WebApiResponse<SpecToProductResponse>>> Get(Guid id);

        [Post("/spectoproduct")]
        Task<ApiResponse<WebApiResponse<SpecToProductResponse>>> Post(SpecToProductRequest request);

        [Put("/spectoproduct/{id}")]
        Task<ApiResponse<WebApiResponse<SpecToProductResponse>>> Put(Guid id, SpecToProductRequest request);

        [Delete("/spectoproduct/{id}")]
        Task<ApiResponse<WebApiResponse<SpecToProductResponse>>> Delete(Guid id);

        [Get("/spectoproduct/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/spectoproduct/getactive")]
        Task<ApiResponse<WebApiResponse<List<SpecToProductResponse>>>> GetActive();
    }
}
