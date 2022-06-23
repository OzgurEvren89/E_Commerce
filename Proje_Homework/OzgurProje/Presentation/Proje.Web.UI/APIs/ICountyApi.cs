using Proje.Common.DTOs.County;
using Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]

    public interface ICountyApi
    {
        [Get("/county")]
        Task<ApiResponse<WebApiResponse<List<CountyResponse>>>> List();

        [Get("/county/{id}")]
        Task<ApiResponse<WebApiResponse<CountyResponse>>> Get(Guid id);

        [Post("/county")]
        Task<ApiResponse<WebApiResponse<CountyResponse>>> Post(CountyRequest request);

        [Put("/county/{id}")]
        Task<ApiResponse<WebApiResponse<CountyResponse>>> Put(Guid id, CountyRequest request);

        [Delete("/county/{id}")]
        Task<ApiResponse<WebApiResponse<CountyResponse>>> Delete(Guid id);

        [Get("/county/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/county/getactive")]
        Task<ApiResponse<WebApiResponse<List<CountyResponse>>>> GetActive();
    }
}
