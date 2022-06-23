using Proje.Common.DTOs.PhoneNumber;
using Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]

    public interface IPhoneNumberApi
    {
        [Get("/phonenumber")]
        Task<ApiResponse<WebApiResponse<List<PhoneNumberResponse>>>> List();

        [Get("/phonenumber/{id}")]
        Task<ApiResponse<WebApiResponse<PhoneNumberResponse>>> Get(Guid id);

        [Post("/phonenumber")]
        Task<ApiResponse<WebApiResponse<PhoneNumberResponse>>> Post(PhoneNumberRequest request);

        [Put("/phonenumber/{id}")]
        Task<ApiResponse<WebApiResponse<PhoneNumberResponse>>> Put(Guid id, PhoneNumberRequest request);

        [Delete("/phonenumber/{id}")]
        Task<ApiResponse<WebApiResponse<PhoneNumberResponse>>> Delete(Guid id);

        [Get("/phonenumber/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/phonenumber/getactive")]
        Task<ApiResponse<WebApiResponse<List<PhoneNumberResponse>>>> GetActive();
    }
}
