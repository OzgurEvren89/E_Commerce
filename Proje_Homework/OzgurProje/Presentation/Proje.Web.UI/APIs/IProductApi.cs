
using Proje.Common.DTOs.Product;
using Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface IProductApi
    {
        [Get("/product")]
        Task<ApiResponse<WebApiResponse<List<ProductResponse>>>> List();

        [Get("/product/{id}")]
        Task<ApiResponse<WebApiResponse<ProductResponse>>> Get(Guid id);

        [Post("/product")]
        Task<ApiResponse<WebApiResponse<ProductResponse>>> Post(ProductRequest request);

        [Put("/product/{id}")]
        Task<ApiResponse<WebApiResponse<ProductResponse>>> Put(Guid id, ProductRequest request);

        [Delete("/product/{id}")]
        Task<ApiResponse<WebApiResponse<ProductResponse>>> Delete(Guid id);

        [Get("/product/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/product/getactive")]
        Task<ApiResponse<WebApiResponse<List<ProductResponse>>>> GetActive();
    }
}
