﻿using Proje.Common.DTOs.ShippingCompany;
using Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]

    public interface IShippingCompanyApi
    {
        [Get("/shippingcompany")]
        Task<ApiResponse<WebApiResponse<List<ShippingCompanyResponse>>>> List();

        [Get("/shippingcompany/{id}")]
        Task<ApiResponse<WebApiResponse<ShippingCompanyResponse>>> Get(Guid id);

        [Post("/shippingcompany")]
        Task<ApiResponse<WebApiResponse<ShippingCompanyResponse>>> Post(ShippingCompanyRequest request);

        [Put("/shippingcompany/{id}")]
        Task<ApiResponse<WebApiResponse<ShippingCompanyResponse>>> Put(Guid id, ShippingCompanyRequest request);

        [Delete("/shippingcompany/{id}")]
        Task<ApiResponse<WebApiResponse<ShippingCompanyResponse>>> Delete(Guid id);

        [Get("/shippingcompany/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/shippingcompany/getactive")]
        Task<ApiResponse<WebApiResponse<List<ShippingCompanyResponse>>>> GetActive();
    }
}
