using Proje.Common.DTOs.SpecGroup;
using Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]

    public interface ISpecGroupApi
    {
        [Get("/specgroup")]
        Task<ApiResponse<WebApiResponse<List<SpecGroupResponse>>>> List();

        [Get("/specgroup/{id}")]
        Task<ApiResponse<WebApiResponse<SpecGroupResponse>>> Get(Guid id);

        [Post("/specgroup")]
        Task<ApiResponse<WebApiResponse<SpecGroupResponse>>> Post(SpecGroupRequest request);

        [Put("/specgroup/{id}")]
        Task<ApiResponse<WebApiResponse<SpecGroupResponse>>> Put(Guid id, SpecGroupRequest request);

        [Delete("/specgroup/{id}")]
        Task<ApiResponse<WebApiResponse<SpecGroupResponse>>> Delete(Guid id);

        [Get("/specgroup/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/specgroup/getactive")]
        Task<ApiResponse<WebApiResponse<List<SpecGroupResponse>>>> GetActive();
    }
}
