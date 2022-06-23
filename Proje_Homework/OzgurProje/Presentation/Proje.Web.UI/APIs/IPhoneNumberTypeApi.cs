using Proje.Common.DTOs.PhoneNumberType;
using Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]

    public interface IPhoneNumberTypeApi
    {
        [Get("/phonenumbertype")]
        Task<ApiResponse<WebApiResponse<List<PhoneNumberTypeResponse>>>> List();

        [Get("/phonenumbertype/{id}")]
        Task<ApiResponse<WebApiResponse<PhoneNumberTypeResponse>>> Get(Guid id);

        [Post("/phonenumbertype")]
        Task<ApiResponse<WebApiResponse<PhoneNumberTypeResponse>>> Post(PhoneNumberTypeRequest request);

        [Put("/phonenumbertype/{id}")]
        Task<ApiResponse<WebApiResponse<PhoneNumberTypeResponse>>> Put(Guid id, PhoneNumberTypeRequest request);

        [Delete("/phonenumbertype/{id}")]
        Task<ApiResponse<WebApiResponse<PhoneNumberTypeResponse>>> Delete(Guid id);

        [Get("/phonenumbertype/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/phonenumbertype/getactive")]
        Task<ApiResponse<WebApiResponse<List<PhoneNumberTypeResponse>>>> GetActive();
    }
}
