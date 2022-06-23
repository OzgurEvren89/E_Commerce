using AutoMapper;
using Proje.API.Controllers.Base;
using Proje.Common.DTOs.ProductComment;
using Proje.Common.DTOs.User;
using Proje.Common.Models;
using Proje.Model.Entities;
using Proje.Service.Repository.ProductComment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proje.API.Controllers
{
    [Route("productcomment")]
    public class ProductCommentController : BaseApiController<ProductCommentController>
    {
        private readonly IProductCommentRepository _productCommentRepository;
        private readonly IMapper _mapper;

        public ProductCommentController(
            IProductCommentRepository productCommentRepository,
            IMapper mapper)
        {
            _productCommentRepository = productCommentRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<ProductCommentResponse>>>> GetProductComments()
        {
            UserResponse user = WorkContext.CurrentUser;

            var productCommentResult = _mapper.Map<List<ProductCommentResponse>>
                (await _productCommentRepository.TableNoTracking.ToListAsync());
            if (productCommentResult.Count > 0)
            {
                return new WebApiResponse<List<ProductCommentResponse>>(true, "Success", productCommentResult);
            }
            return new WebApiResponse<List<ProductCommentResponse>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<ProductCommentResponse>>> GetProductComments(Guid id)
        {
            var productCommentResult = _mapper.Map<ProductCommentResponse>(await _productCommentRepository.GetById(id));
            if (productCommentResult != null)
            {
                return new WebApiResponse<ProductCommentResponse>(true, "Success", productCommentResult);
            }
            return new WebApiResponse<ProductCommentResponse>(false, "Error");
        }

        [HttpPost, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<ProductCommentResponse>>> PostProductComment(ProductCommentRequest request)
        {
            ProductComment entity = _mapper.Map<ProductComment>(request);
            var insertResult = await _productCommentRepository.Add(entity);
            if (insertResult != null)
            {
                ProductCommentResponse rm = _mapper.Map<ProductCommentResponse>(insertResult);
                return new WebApiResponse<ProductCommentResponse>(true, "Success", rm);
            }
            return new WebApiResponse<ProductCommentResponse>(false, "Error");
        }

        [HttpPut("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<ProductCommentResponse>>> PutProductComment(Guid id, ProductCommentRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                ProductComment entity = await _productCommentRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _productCommentRepository.Update(entity);
                if (updateResult != null)
                {
                    ProductCommentResponse rm = _mapper.Map<ProductCommentResponse>(updateResult);
                    return new WebApiResponse<ProductCommentResponse>(true, "Success", rm);
                }
                return new WebApiResponse<ProductCommentResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<ProductCommentResponse>>> DeleteProductComment(Guid id)
        {
            ProductComment entity = await _productCommentRepository.GetById(id);
            if (entity != null)
            {
                if (await _productCommentRepository.Remove(entity))
                    return new WebApiResponse<ProductCommentResponse>
                        (true, "Success", _mapper.Map<ProductCommentResponse>(entity));
                else
                    return new WebApiResponse<ProductCommentResponse>(false, "Error");
            }
            return new WebApiResponse<ProductCommentResponse>(false, "Error");
        }

        [HttpGet("activate/{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _productCommentRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", true);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<ProductCommentResponse>>>> GetActive()
        {
            var productCommentResult = _mapper.Map<List<ProductCommentResponse>>
                (await _productCommentRepository.GetActive().ToListAsync());
            if (productCommentResult.Count > 0)
            {
                return new WebApiResponse<List<ProductCommentResponse>>(true, "Success", productCommentResult);
            }
            return new WebApiResponse<List<ProductCommentResponse>>(false, "Error");
        }

    }
}
