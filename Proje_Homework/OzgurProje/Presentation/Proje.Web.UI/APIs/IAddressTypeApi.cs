using Proje.Common.DTOs.AddressType;
using Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]

    public interface IAddressTypeApi
    {
        [Get("/addresstype")]
        Task<ApiResponse<WebApiResponse<List<AddressTypeResponse>>>> List();

        [Get("/addresstype/{id}")]
        Task<ApiResponse<WebApiResponse<AddressTypeResponse>>> Get(Guid id);

        [Post("/addresstype")]
        Task<ApiResponse<WebApiResponse<AddressTypeResponse>>> Post(AddressTypeRequest request);

        [Put("/addresstype/{id}")]
        Task<ApiResponse<WebApiResponse<AddressTypeResponse>>> Put(Guid id, AddressTypeRequest request);

        [Delete("/addresstype/{id}")]
        Task<ApiResponse<WebApiResponse<AddressTypeResponse>>> Delete(Guid id);

        [Get("/addresstype/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/addresstype/getactive")]
        Task<ApiResponse<WebApiResponse<List<AddressTypeResponse>>>> GetActive();
    }
}
