using Proje.Common.DTOs.ProductDetail;
using Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]

    public interface IProductDetailApi
    {
        [Get("/productdetail")]
        Task<ApiResponse<WebApiResponse<List<ProductDetailResponse>>>> List();

        [Get("/productdetail/{id}")]
        Task<ApiResponse<WebApiResponse<ProductDetailResponse>>> Get(Guid id);

        [Post("/productdetail")]
        Task<ApiResponse<WebApiResponse<ProductDetailResponse>>> Post(ProductDetailRequest request);

        [Put("/productdetail/{id}")]
        Task<ApiResponse<WebApiResponse<ProductDetailResponse>>> Put(Guid id, ProductDetailRequest request);

        [Delete("/productdetail/{id}")]
        Task<ApiResponse<WebApiResponse<ProductDetailResponse>>> Delete(Guid id);

        [Get("/productdetail/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/productdetail/getactive")]
        Task<ApiResponse<WebApiResponse<List<ProductDetailResponse>>>> GetActive();
    }
}
