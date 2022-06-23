using Proje.Common.DTOs.SpecValue;
using Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]

    public interface ISpecValueApi
    {
        [Get("/specvalue")]
        Task<ApiResponse<WebApiResponse<List<SpecValueResponse>>>> List();

        [Get("/specvalue/{id}")]
        Task<ApiResponse<WebApiResponse<SpecValueResponse>>> Get(Guid id);

        [Post("/specvalue")]
        Task<ApiResponse<WebApiResponse<SpecValueResponse>>> Post(SpecValueRequest request);

        [Put("/specvalue/{id}")]
        Task<ApiResponse<WebApiResponse<SpecValueResponse>>> Put(Guid id, SpecValueRequest request);

        [Delete("/specvalue/{id}")]
        Task<ApiResponse<WebApiResponse<SpecValueResponse>>> Delete(Guid id);

        [Get("/specvalue/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/specvalue/getactive")]
        Task<ApiResponse<WebApiResponse<List<SpecValueResponse>>>> GetActive();
    }
}
