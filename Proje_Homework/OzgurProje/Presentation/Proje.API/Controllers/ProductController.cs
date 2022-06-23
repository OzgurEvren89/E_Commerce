using AutoMapper;
using Proje.API.Controllers.Base;
using Proje.Common.DTOs.Product;
using Proje.Common.DTOs.User;
using Proje.Common.Models;
using Proje.Model.Entities;
using Proje.Service.Repository.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proje.API.Controllers
{
    [Route("product")]
    public class ProductController : BaseApiController<ProductController>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductController(
            IProductRepository productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<ProductResponse>>>> GetProducts()
        {
            UserResponse user = WorkContext.CurrentUser;

            var productResult = _mapper.Map<List<ProductResponse>>
                (await _productRepository.TableNoTracking.ToListAsync());
            if (productResult.Count > 0)
            {
                return new WebApiResponse<List<ProductResponse>>(true, "Success", productResult);
            }
            return new WebApiResponse<List<ProductResponse>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<ProductResponse>>> GetProducts(Guid id)
        {
            var productResult = _mapper.Map<ProductResponse>(await _productRepository.GetById(id));
            if (productResult != null)
            {
                return new WebApiResponse<ProductResponse>(true, "Success", productResult);
            }
            return new WebApiResponse<ProductResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<ProductResponse>>> PostProduct(ProductRequest request)
        {
            Product entity = _mapper.Map<Product>(request);
            var insertResult = await _productRepository.Add(entity);
            if (insertResult != null)
            {
                ProductResponse rm = _mapper.Map<ProductResponse>(insertResult);
                return new WebApiResponse<ProductResponse>(true, "Success", rm);
            }
            return new WebApiResponse<ProductResponse>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<ProductResponse>>> PutProduct(Guid id, ProductRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                Product entity = await _productRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _productRepository.Update(entity);
                if (updateResult != null)
                {
                    ProductResponse rm = _mapper.Map<ProductResponse>(updateResult);
                    return new WebApiResponse<ProductResponse>(true, "Success", rm);
                }
                return new WebApiResponse<ProductResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<ProductResponse>>> DeleteProduct(Guid id)
        {
            Product entity = await _productRepository.GetById(id);
            if (entity != null)
            {
                if (await _productRepository.Remove(entity))
                    return new WebApiResponse<ProductResponse>
                        (true, "Success", _mapper.Map<ProductResponse>(entity));
                else
                    return new WebApiResponse<ProductResponse>(false, "Error");
            }
            return new WebApiResponse<ProductResponse>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _productRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", true);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<ProductResponse>>>> GetActive()
        {
            var productResult = _mapper.Map<List<ProductResponse>>
                (await _productRepository.GetActive().ToListAsync());
            if (productResult.Count > 0)
            {
                return new WebApiResponse<List<ProductResponse>>(true, "Success", productResult);
            }
            return new WebApiResponse<List<ProductResponse>>(false, "Error");
        }

    }
}
