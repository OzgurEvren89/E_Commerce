using Proje.Common.DTOs.Category;
using Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface ICategoryApi
    {
        [Get("/category")]
        Task<ApiResponse<WebApiResponse<List<CategoryResponse>>>> List();

        [Get("/category/{id}")]
        Task<ApiResponse<WebApiResponse<CategoryResponse>>> Get(Guid id);

        [Post("/category")]
        Task<ApiResponse<WebApiResponse<CategoryResponse>>> Post(CategoryRequest request);

        [Put("/category/{id}")]
        Task<ApiResponse<WebApiResponse<CategoryResponse>>> Put(Guid id, CategoryRequest request);

        [Delete("/category/{id}")]
        Task<ApiResponse<WebApiResponse<CategoryResponse>>> Delete(Guid id);

        [Get("/category/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/category/getactive")]
        Task<ApiResponse<WebApiResponse<List<CategoryResponse>>>> GetActive();
    }
}
