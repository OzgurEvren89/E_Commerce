using Proje.Common.DTOs.ProductComment;
using Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]

    public interface IProductCommentApi
    {
        [Get("/productcomment")]
        Task<ApiResponse<WebApiResponse<List<ProductCommentResponse>>>> List();

        [Get("/productcomment/{id}")]
        Task<ApiResponse<WebApiResponse<ProductCommentResponse>>> Get(Guid id);

        [Post("/productcomment")]
        Task<ApiResponse<WebApiResponse<ProductCommentResponse>>> Post(ProductCommentRequest request);

        [Put("/productcomment/{id}")]
        Task<ApiResponse<WebApiResponse<ProductCommentResponse>>> Put(Guid id, ProductCommentRequest request);

        [Delete("/productcomment/{id}")]
        Task<ApiResponse<WebApiResponse<ProductCommentResponse>>> Delete(Guid id);

        [Get("/productcomment/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/productcomment/getactive")]
        Task<ApiResponse<WebApiResponse<List<ProductCommentResponse>>>> GetActive();
    }
}
