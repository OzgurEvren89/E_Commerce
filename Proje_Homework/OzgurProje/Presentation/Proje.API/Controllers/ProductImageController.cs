using AutoMapper;
using Proje.API.Controllers.Base;
using Proje.Common.DTOs.ProductImage;
using Proje.Common.DTOs.User;
using Proje.Common.Models;
using Proje.Model.Entities;
using Proje.Service.Repository.ProductImage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proje.API.Controllers
{
    [Route("productImage")]
    public class ProductImageController : BaseApiController<ProductImageController>
    {
        private readonly IProductImageRepository _productImageRepository;
        private readonly IMapper _mapper;

        public ProductImageController(
            IProductImageRepository productImageRepository,
            IMapper mapper)
        {
            _productImageRepository = productImageRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<ProductImageResponse>>>> GetProductImages()
        {
            UserResponse user = WorkContext.CurrentUser;

            var productImageResult = _mapper.Map<List<ProductImageResponse>>
                (await _productImageRepository.TableNoTracking.ToListAsync());
            if (productImageResult.Count > 0)
            {
                return new WebApiResponse<List<ProductImageResponse>>(true, "Success", productImageResult);
            }
            return new WebApiResponse<List<ProductImageResponse>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<ProductImageResponse>>> GetProductImages(Guid id)
        {
            var productImageResult = _mapper.Map<ProductImageResponse>(await _productImageRepository.GetById(id));
            if (productImageResult != null)
            {
                return new WebApiResponse<ProductImageResponse>(true, "Success", productImageResult);
            }
            return new WebApiResponse<ProductImageResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<ProductImageResponse>>> PostProductImage(ProductImageRequest request)
        {
            ProductImage entity = _mapper.Map<ProductImage>(request);
            var insertResult = await _productImageRepository.Add(entity);
            if (insertResult != null)
            {
                ProductImageResponse rm = _mapper.Map<ProductImageResponse>(insertResult);
                return new WebApiResponse<ProductImageResponse>(true, "Success", rm);
            }
            return new WebApiResponse<ProductImageResponse>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<ProductImageResponse>>> PutProductImage(Guid id, ProductImageRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                ProductImage entity = await _productImageRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _productImageRepository.Update(entity);
                if (updateResult != null)
                {
                    ProductImageResponse rm = _mapper.Map<ProductImageResponse>(updateResult);
                    return new WebApiResponse<ProductImageResponse>(true, "Success", rm);
                }
                return new WebApiResponse<ProductImageResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<ProductImageResponse>>> DeleteProductImage(Guid id)
        {
            ProductImage entity = await _productImageRepository.GetById(id);
            if (entity != null)
            {
                if (await _productImageRepository.Remove(entity))
                    return new WebApiResponse<ProductImageResponse>
                        (true, "Success", _mapper.Map<ProductImageResponse>(entity));
                else
                    return new WebApiResponse<ProductImageResponse>(false, "Error");
            }
            return new WebApiResponse<ProductImageResponse>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _productImageRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", true);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<ProductImageResponse>>>> GetActive()
        {
            var productImageResult = _mapper.Map<List<ProductImageResponse>>
                (await _productImageRepository.GetActive().ToListAsync());
            if (productImageResult.Count > 0)
            {
                return new WebApiResponse<List<ProductImageResponse>>(true, "Success", productImageResult);
            }
            return new WebApiResponse<List<ProductImageResponse>>(false, "Error");
        }

    }
}
