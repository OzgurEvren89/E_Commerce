using Proje.Common.DTOs.Options;
using Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]

    public interface IOptionsApi
    {
        [Get("/options")]
        Task<ApiResponse<WebApiResponse<List<OptionsResponse>>>> List();

        [Get("/options/{id}")]
        Task<ApiResponse<WebApiResponse<OptionsResponse>>> Get(Guid id);

        [Post("/options")]
        Task<ApiResponse<WebApiResponse<OptionsResponse>>> Post(OptionsRequest request);

        [Put("/options/{id}")]
        Task<ApiResponse<WebApiResponse<OptionsResponse>>> Put(Guid id, OptionsRequest request);

        [Delete("/options/{id}")]
        Task<ApiResponse<WebApiResponse<OptionsResponse>>> Delete(Guid id);

        [Get("/options/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/options/getactive")]
        Task<ApiResponse<WebApiResponse<List<OptionsResponse>>>> GetActive();
    }
}
