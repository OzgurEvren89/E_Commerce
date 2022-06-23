using Proje.Common.DTOs.MemberAddress;
using Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]

    public interface IMemberAddressApi
    {
        [Get("/memberaddress")]
        Task<ApiResponse<WebApiResponse<List<MemberAddressResponse>>>> List();

        [Get("/memberaddress/{id}")]
        Task<ApiResponse<WebApiResponse<MemberAddressResponse>>> Get(Guid id);

        [Post("/memberaddress")]
        Task<ApiResponse<WebApiResponse<MemberAddressResponse>>> Post(MemberAddressRequest request);

        [Put("/memberaddress/{id}")]
        Task<ApiResponse<WebApiResponse<MemberAddressResponse>>> Put(Guid id, MemberAddressRequest request);

        [Delete("/memberaddress/{id}")]
        Task<ApiResponse<WebApiResponse<MemberAddressResponse>>> Delete(Guid id);

        [Get("/memberaddress/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/memberaddress/getactive")]
        Task<ApiResponse<WebApiResponse<List<MemberAddressResponse>>>> GetActive();
    }
}
