using AutoMapper;
using Proje.API.Controllers.Base;
using Proje.Common.DTOs.FavouritedProduct;
using Proje.Common.DTOs.User;
using Proje.Common.Models;
using Proje.Model.Entities;
using Proje.Service.Repository.FavouritedProduct;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Proje.Common.Enums;

namespace Proje.API.Controllers
{
    [Route("favouritedproduct")]
    public class FavouritedProductController : BaseApiController<FavouritedProductController>
    {
        private readonly IFavouritedProductRepository _favouritedProductRepository;
        private readonly IMapper _mapper;

        public FavouritedProductController(
            IFavouritedProductRepository favouritedProductRepository,
            IMapper mapper)
        {
            _favouritedProductRepository = favouritedProductRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<FavouritedProductResponse>>>> GetFavouritedProducts()
        {
            UserResponse user = WorkContext.CurrentUser;

            var favouritedProductResult = _mapper.Map<List<FavouritedProductResponse>>
                (await _favouritedProductRepository.TableNoTracking.ToListAsync());
            if (favouritedProductResult.Count > 0)
            {
                return new WebApiResponse<List<FavouritedProductResponse>>(true, "Success", favouritedProductResult);
            }
            return new WebApiResponse<List<FavouritedProductResponse>>(false, "Error");
        }

        [HttpGet("foruser"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<FavouritedProductResponse>>>> GetFavouritedProductsForUser()
        {
            UserResponse user = WorkContext.CurrentUser;


            var favouritedProductResult = _mapper.Map<List<FavouritedProductResponse>>
                (await _favouritedProductRepository.GetDefault(x=>x.CreatedUserId==user.Id).ToListAsync());

            if (favouritedProductResult.Count > 0)
            {
                return new WebApiResponse<List<FavouritedProductResponse>>(true, "Success", favouritedProductResult);
            }

            return new WebApiResponse<List<FavouritedProductResponse>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<FavouritedProductResponse>>> GetFavouritedProducts(Guid id)
        {
            var favouritedProductResult = _mapper.Map<FavouritedProductResponse>(await _favouritedProductRepository.GetById(id));
            if (favouritedProductResult != null)
            {
                return new WebApiResponse<FavouritedProductResponse>(true, "Success", favouritedProductResult);
            }
            return new WebApiResponse<FavouritedProductResponse>(false, "Error");
        }

        [HttpPost, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<FavouritedProductResponse>>> PostFavouritedProduct(FavouritedProductRequest request)
        {
            FavouritedProduct entity = _mapper.Map<FavouritedProduct>(request);
            var insertResult = await _favouritedProductRepository.Add(entity);
            if (insertResult != null)
            {
                FavouritedProductResponse rm = _mapper.Map<FavouritedProductResponse>(insertResult);
                return new WebApiResponse<FavouritedProductResponse>(true, "Success", rm);
            }
            return new WebApiResponse<FavouritedProductResponse>(false, "Error");
        }

        [HttpPut("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<FavouritedProductResponse>>> PutFavouritedProduct(Guid id, FavouritedProductRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                FavouritedProduct entity = await _favouritedProductRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _favouritedProductRepository.Update(entity);
                if (updateResult != null)
                {
                    FavouritedProductResponse rm = _mapper.Map<FavouritedProductResponse>(updateResult);
                    return new WebApiResponse<FavouritedProductResponse>(true, "Success", rm);
                }
                return new WebApiResponse<FavouritedProductResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<FavouritedProductResponse>>> DeleteFavouritedProduct(Guid id)
        {
            FavouritedProduct entity = await _favouritedProductRepository.GetById(id);
            if (entity != null)
            {
                if (await _favouritedProductRepository.Remove(entity))
                    return new WebApiResponse<FavouritedProductResponse>
                        (true, "Success", _mapper.Map<FavouritedProductResponse>(entity));
                else
                    return new WebApiResponse<FavouritedProductResponse>(false, "Error");
            }
            return new WebApiResponse<FavouritedProductResponse>(false, "Error");
        }

        [HttpGet("activate/{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _favouritedProductRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", true);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<FavouritedProductResponse>>>> GetActive()
        {
            var favouritedProductResult = _mapper.Map<List<FavouritedProductResponse>>
                (await _favouritedProductRepository.GetActive().ToListAsync());
            if (favouritedProductResult.Count > 0)
            {
                return new WebApiResponse<List<FavouritedProductResponse>>(true, "Success", favouritedProductResult);
            }
            return new WebApiResponse<List<FavouritedProductResponse>>(false, "Error");
        }

    }
}
