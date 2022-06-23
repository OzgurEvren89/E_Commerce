using Proje.Common.DTOs.OptionGroup;
using Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]

    public interface IOptionGroupApi
    {
        [Get("/optiongroup")]
        Task<ApiResponse<WebApiResponse<List<OptionGroupResponse>>>> List();

        [Get("/optiongroup/{id}")]
        Task<ApiResponse<WebApiResponse<OptionGroupResponse>>> Get(Guid id);

        [Post("/optiongroup")]
        Task<ApiResponse<WebApiResponse<OptionGroupResponse>>> Post(OptionGroupRequest request);

        [Put("/optiongroup/{id}")]
        Task<ApiResponse<WebApiResponse<OptionGroupResponse>>> Put(Guid id, OptionGroupRequest request);

        [Delete("/optiongroup/{id}")]
        Task<ApiResponse<WebApiResponse<OptionGroupResponse>>> Delete(Guid id);

        [Get("/optiongroup/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/optiongroup/getactive")]
        Task<ApiResponse<WebApiResponse<List<OptionGroupResponse>>>> GetActive();
    }
}
