using Proje.Common.DTOs.BrandToCategory;
using Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface IBrandToCategoryApi
    {
        [Get("/brandtocategory")]
        Task<ApiResponse<WebApiResponse<List<BrandToCategoryResponse>>>> List();

        [Get("/brandtocategory/{id}")]
        Task<ApiResponse<WebApiResponse<BrandToCategoryResponse>>> Get(Guid id);

        [Post("/brandtocategory")]
        Task<ApiResponse<WebApiResponse<BrandToCategoryResponse>>> Post(BrandToCategoryRequest request);

        [Put("/brandtocategory/{id}")]
        Task<ApiResponse<WebApiResponse<BrandToCategoryResponse>>> Put(Guid id, BrandToCategoryRequest request);

        [Delete("/brandtocategory/{id}")]
        Task<ApiResponse<WebApiResponse<BrandToCategoryResponse>>> Delete(Guid id);

        [Get("/brandtocategory/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/brandtocategory/getactive")]
        Task<ApiResponse<WebApiResponse<List<BrandToCategoryResponse>>>> GetActive();
    }
}
