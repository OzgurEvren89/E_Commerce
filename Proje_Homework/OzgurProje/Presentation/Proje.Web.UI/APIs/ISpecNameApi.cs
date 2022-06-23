using Proje.Common.DTOs.SpecName;
using Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]

    public interface ISpecNameApi
    {
        [Get("/specname")]
        Task<ApiResponse<WebApiResponse<List<SpecNameResponse>>>> List();

        [Get("/specname/{id}")]
        Task<ApiResponse<WebApiResponse<SpecNameResponse>>> Get(Guid id);

        [Post("/specname")]
        Task<ApiResponse<WebApiResponse<SpecNameResponse>>> Post(SpecNameRequest request);

        [Put("/specname/{id}")]
        Task<ApiResponse<WebApiResponse<SpecNameResponse>>> Put(Guid id, SpecNameRequest request);

        [Delete("/specname/{id}")]
        Task<ApiResponse<WebApiResponse<SpecNameResponse>>> Delete(Guid id);

        [Get("/specname/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/specname/getactive")]
        Task<ApiResponse<WebApiResponse<List<SpecNameResponse>>>> GetActive();
    }
}
