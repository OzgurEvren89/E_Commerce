using Proje.Common.DTOs.Brand;
using Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]

    public interface IBrandApi
    {
        [Get("/brand")]
        Task<ApiResponse<WebApiResponse<List<BrandResponse>>>> List();

        [Get("/brand/{id}")]
        Task<ApiResponse<WebApiResponse<BrandResponse>>> Get(Guid id);

        [Post("/brand")]
        Task<ApiResponse<WebApiResponse<BrandResponse>>> Post(BrandRequest request);

        [Put("/brand/{id}")]
        Task<ApiResponse<WebApiResponse<BrandResponse>>> Put(Guid id, BrandRequest request);

        [Delete("/brand/{id}")]
        Task<ApiResponse<WebApiResponse<BrandResponse>>> Delete(Guid id);

        [Get("/brand/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/brand/getactive")]
        Task<ApiResponse<WebApiResponse<List<BrandResponse>>>> GetActive();
    }
}
