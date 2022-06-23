using AutoMapper;
using Proje.API.Controllers.Base;
using Proje.Common.DTOs.SpecToProduct;
using Proje.Common.DTOs.User;
using Proje.Common.Models;
using Proje.Model.Entities;
using Proje.Service.Repository.SpecToProduct;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proje.API.Controllers
{
    [Route("spectoproduct")]
    public class SpecToProductController : BaseApiController<SpecToProductController>
    {
        private readonly ISpecToProductRepository _specToProductRepository;
        private readonly IMapper _mapper;

        public SpecToProductController(
            ISpecToProductRepository specToProductRepository,
            IMapper mapper)
        {
            _specToProductRepository = specToProductRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<SpecToProductResponse>>>> GetSpecToProducts()
        {
            UserResponse user = WorkContext.CurrentUser;

            var specToProductResult = _mapper.Map<List<SpecToProductResponse>>
                (await _specToProductRepository.TableNoTracking.ToListAsync());
            if (specToProductResult.Count > 0)
            {
                return new WebApiResponse<List<SpecToProductResponse>>(true, "Success", specToProductResult);
            }
            return new WebApiResponse<List<SpecToProductResponse>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<SpecToProductResponse>>> GetSpecToProducts(Guid id)
        {
            var specToProductResult = _mapper.Map<SpecToProductResponse>(await _specToProductRepository.GetById(id));
            if (specToProductResult != null)
            {
                return new WebApiResponse<SpecToProductResponse>(true, "Success", specToProductResult);
            }
            return new WebApiResponse<SpecToProductResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<SpecToProductResponse>>> PostSpecToProduct(SpecToProductRequest request)
        {
            SpecToProduct entity = _mapper.Map<SpecToProduct>(request);
            var insertResult = await _specToProductRepository.Add(entity);
            if (insertResult != null)
            {
                SpecToProductResponse rm = _mapper.Map<SpecToProductResponse>(insertResult);
                return new WebApiResponse<SpecToProductResponse>(true, "Success", rm);
            }
            return new WebApiResponse<SpecToProductResponse>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<SpecToProductResponse>>> PutSpecToProduct(Guid id, SpecToProductRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                SpecToProduct entity = await _specToProductRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _specToProductRepository.Update(entity);
                if (updateResult != null)
                {
                    SpecToProductResponse rm = _mapper.Map<SpecToProductResponse>(updateResult);
                    return new WebApiResponse<SpecToProductResponse>(true, "Success", rm);
                }
                return new WebApiResponse<SpecToProductResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<SpecToProductResponse>>> DeleteSpecToProduct(Guid id)
        {
            SpecToProduct entity = await _specToProductRepository.GetById(id);
            if (entity != null)
            {
                if (await _specToProductRepository.Remove(entity))
                    return new WebApiResponse<SpecToProductResponse>
                        (true, "Success", _mapper.Map<SpecToProductResponse>(entity));
                else
                    return new WebApiResponse<SpecToProductResponse>(false, "Error");
            }
            return new WebApiResponse<SpecToProductResponse>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _specToProductRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", true);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<SpecToProductResponse>>>> GetActive()
        {
            var specToProductResult = _mapper.Map<List<SpecToProductResponse>>
                (await _specToProductRepository.GetActive().ToListAsync());
            if (specToProductResult.Count > 0)
            {
                return new WebApiResponse<List<SpecToProductResponse>>(true, "Success", specToProductResult);
            }
            return new WebApiResponse<List<SpecToProductResponse>>(false, "Error");
        }

    }
}
