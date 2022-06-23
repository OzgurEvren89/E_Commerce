using Proje.Common.DTOs.City;
using Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]

    public interface ICityApi
    {
        [Get("/city")]
        Task<ApiResponse<WebApiResponse<List<CityResponse>>>> List();

        [Get("/city/{id}")]
        Task<ApiResponse<WebApiResponse<CityResponse>>> Get(Guid id);

        [Post("/city")]
        Task<ApiResponse<WebApiResponse<CityResponse>>> Post(CityRequest request);

        [Put("/city/{id}")]
        Task<ApiResponse<WebApiResponse<CityResponse>>> Put(Guid id, CityRequest request);

        [Delete("/city/{id}")]
        Task<ApiResponse<WebApiResponse<CityResponse>>> Delete(Guid id);

        [Get("/city/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/city/getactive")]
        Task<ApiResponse<WebApiResponse<List<CityResponse>>>> GetActive();
    }
}
