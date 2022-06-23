using Proje.Common.DTOs.OptionToProduct;
using Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]

    public interface IOptionToProductApi
    {
        [Get("/optiontoproduct")]
        Task<ApiResponse<WebApiResponse<List<OptionToProductResponse>>>> List();

        [Get("/optiontoproduct/{id}")]
        Task<ApiResponse<WebApiResponse<OptionToProductResponse>>> Get(Guid id);

        [Post("/optiontoproduct")]
        Task<ApiResponse<WebApiResponse<OptionToProductResponse>>> Post(OptionToProductRequest request);

        [Put("/optiontoproduct/{id}")]
        Task<ApiResponse<WebApiResponse<OptionToProductResponse>>> Put(Guid id, OptionToProductRequest request);

        [Delete("/optiontoproduct/{id}")]
        Task<ApiResponse<WebApiResponse<OptionToProductResponse>>> Delete(Guid id);

        [Get("/optiontoproduct/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/optiontoproduct/getactive")]
        Task<ApiResponse<WebApiResponse<List<OptionToProductResponse>>>> GetActive();
    }
}
