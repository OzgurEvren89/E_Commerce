using AutoMapper;
using Proje.API.Controllers.Base;
using Proje.Common.DTOs.ProductDetail;
using Proje.Common.DTOs.User;
using Proje.Common.Models;
using Proje.Model.Entities;
using Proje.Service.Repository.ProductDetail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proje.API.Controllers
{
    [Route("productdetail")]
    public class ProductDetailController : BaseApiController<ProductDetailController>
    {
        private readonly IProductDetailRepository _productDetailRepository;
        private readonly IMapper _mapper;

        public ProductDetailController(
            IProductDetailRepository productDetailRepository,
            IMapper mapper)
        {
            _productDetailRepository = productDetailRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<ProductDetailResponse>>>> GetProductDetails()
        {
            UserResponse user = WorkContext.CurrentUser;

            var productDetailResult = _mapper.Map<List<ProductDetailResponse>>
                (await _productDetailRepository.TableNoTracking.ToListAsync());
            if (productDetailResult.Count > 0)
            {
                return new WebApiResponse<List<ProductDetailResponse>>(true, "Success", productDetailResult);
            }
            return new WebApiResponse<List<ProductDetailResponse>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<ProductDetailResponse>>> GetProductDetails(Guid id)
        {
            var productDetailResult = _mapper.Map<ProductDetailResponse>(await _productDetailRepository.GetById(id));
            if (productDetailResult != null)
            {
                return new WebApiResponse<ProductDetailResponse>(true, "Success", productDetailResult);
            }
            return new WebApiResponse<ProductDetailResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<ProductDetailResponse>>> PostProductDetail(ProductDetailRequest request)
        {
            ProductDetail entity = _mapper.Map<ProductDetail>(request);
            var insertResult = await _productDetailRepository.Add(entity);
            if (insertResult != null)
            {
                ProductDetailResponse rm = _mapper.Map<ProductDetailResponse>(insertResult);
                return new WebApiResponse<ProductDetailResponse>(true, "Success", rm);
            }
            return new WebApiResponse<ProductDetailResponse>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<ProductDetailResponse>>> PutProductDetail(Guid id, ProductDetailRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                ProductDetail entity = await _productDetailRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _productDetailRepository.Update(entity);
                if (updateResult != null)
                {
                    ProductDetailResponse rm = _mapper.Map<ProductDetailResponse>(updateResult);
                    return new WebApiResponse<ProductDetailResponse>(true, "Success", rm);
                }
                return new WebApiResponse<ProductDetailResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<ProductDetailResponse>>> DeleteProductDetail(Guid id)
        {
            ProductDetail entity = await _productDetailRepository.GetById(id);
            if (entity != null)
            {
                if (await _productDetailRepository.Remove(entity))
                    return new WebApiResponse<ProductDetailResponse>
                        (true, "Success", _mapper.Map<ProductDetailResponse>(entity));
                else
                    return new WebApiResponse<ProductDetailResponse>(false, "Error");
            }
            return new WebApiResponse<ProductDetailResponse>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _productDetailRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", true);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<ProductDetailResponse>>>> GetActive()
        {
            var productDetailResult = _mapper.Map<List<ProductDetailResponse>>
                (await _productDetailRepository.GetActive().ToListAsync());
            if (productDetailResult.Count > 0)
            {
                return new WebApiResponse<List<ProductDetailResponse>>(true, "Success", productDetailResult);
            }
            return new WebApiResponse<List<ProductDetailResponse>>(false, "Error");
        }

    }
}
