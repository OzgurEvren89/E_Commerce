using Proje.Common.DTOs.FavouritedProduct;
using Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]

    public interface IFavouritedProductApi
    {
        [Get("/favouritedproduct")]
        Task<ApiResponse<WebApiResponse<List<FavouritedProductResponse>>>> List();

        [Get("/favouritedproduct/foruser")]
        Task<ApiResponse<WebApiResponse<List<FavouritedProductResponse>>>> GetForUser();

        [Get("/favouritedproduct/{id}")]
        Task<ApiResponse<WebApiResponse<FavouritedProductResponse>>> Get(Guid id);

        [Post("/favouritedproduct")]
        Task<ApiResponse<WebApiResponse<FavouritedProductResponse>>> Post(FavouritedProductRequest request);

        [Put("/favouritedproduct/{id}")]
        Task<ApiResponse<WebApiResponse<FavouritedProductResponse>>> Put(Guid id, FavouritedProductRequest request);

        [Delete("/favouritedproduct/{id}")]
        Task<ApiResponse<WebApiResponse<FavouritedProductResponse>>> Delete(Guid id);

        [Get("/favouritedproduct/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/favouritedproduct/getactive")]
        Task<ApiResponse<WebApiResponse<List<FavouritedProductResponse>>>> GetActive();
    }
}
