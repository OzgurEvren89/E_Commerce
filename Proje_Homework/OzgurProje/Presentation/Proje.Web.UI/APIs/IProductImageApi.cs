using Proje.Common.DTOs.ProductImage;
using Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface IProductImageApi
    {
        [Get("/productImage")]
        Task<ApiResponse<WebApiResponse<List<ProductImageResponse>>>> List();

        [Get("/productImage/{id}")]
        Task<ApiResponse<WebApiResponse<ProductImageResponse>>> Get(Guid id);

        [Post("/productImage")]
        Task<ApiResponse<WebApiResponse<ProductImageResponse>>> Post(ProductImageRequest request);

        [Put("/productImage/{id}")]
        Task<ApiResponse<WebApiResponse<ProductImageResponse>>> Put(Guid id, ProductImageRequest request);

        [Delete("/productImage/{id}")]
        Task<ApiResponse<WebApiResponse<ProductImageResponse>>> Delete(Guid id);

        [Get("/productImage/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/productImage/getactive")]
        Task<ApiResponse<WebApiResponse<List<ProductImageResponse>>>> GetActive();
    }
}
