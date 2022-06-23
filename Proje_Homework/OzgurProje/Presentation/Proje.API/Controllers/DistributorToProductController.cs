using AutoMapper;
using Proje.API.Controllers.Base;
using Proje.Common.DTOs.DistributorToProduct;
using Proje.Common.DTOs.User;
using Proje.Common.Models;
using Proje.Model.Entities;
using Proje.Service.Repository.DistributorToProduct;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proje.API.Controllers
{
    [Route("distributortoproduct")]
    public class DistributorToProductController : BaseApiController<DistributorToProductController>
    {
        private readonly IDistributorToProductRepository _distributorToProductRepository;
        private readonly IMapper _mapper;

        public DistributorToProductController(
            IDistributorToProductRepository distributorToProductRepository,
            IMapper mapper)
        {
            _distributorToProductRepository = distributorToProductRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<DistributorToProductResponse>>>> GetDistributorToProducts()
        {
            UserResponse user = WorkContext.CurrentUser;

            var distributorToProductResult = _mapper.Map<List<DistributorToProductResponse>>
                (await _distributorToProductRepository.TableNoTracking.ToListAsync());
            if (distributorToProductResult.Count > 0)
            {
                return new WebApiResponse<List<DistributorToProductResponse>>(true, "Success", distributorToProductResult);
            }
            return new WebApiResponse<List<DistributorToProductResponse>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<DistributorToProductResponse>>> GetDistributorToProducts(Guid id)
        {
            var distributorToProductResult = _mapper.Map<DistributorToProductResponse>(await _distributorToProductRepository.GetById(id));
            if (distributorToProductResult != null)
            {
                return new WebApiResponse<DistributorToProductResponse>(true, "Success", distributorToProductResult);
            }
            return new WebApiResponse<DistributorToProductResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<DistributorToProductResponse>>> PostDistributorToProduct(DistributorToProductRequest request)
        {
            DistributorToProduct entity = _mapper.Map<DistributorToProduct>(request);
            var insertResult = await _distributorToProductRepository.Add(entity);
            if (insertResult != null)
            {
                DistributorToProductResponse rm = _mapper.Map<DistributorToProductResponse>(insertResult);
                return new WebApiResponse<DistributorToProductResponse>(true, "Success", rm);
            }
            return new WebApiResponse<DistributorToProductResponse>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<DistributorToProductResponse>>> PutDistributorToProduct(Guid id, DistributorToProductRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                DistributorToProduct entity = await _distributorToProductRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _distributorToProductRepository.Update(entity);
                if (updateResult != null)
                {
                    DistributorToProductResponse rm = _mapper.Map<DistributorToProductResponse>(updateResult);
                    return new WebApiResponse<DistributorToProductResponse>(true, "Success", rm);
                }
                return new WebApiResponse<DistributorToProductResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<DistributorToProductResponse>>> DeleteDistributorToProduct(Guid id)
        {
            DistributorToProduct entity = await _distributorToProductRepository.GetById(id);
            if (entity != null)
            {
                if (await _distributorToProductRepository.Remove(entity))
                    return new WebApiResponse<DistributorToProductResponse>
                        (true, "Success", _mapper.Map<DistributorToProductResponse>(entity));
                else
                    return new WebApiResponse<DistributorToProductResponse>(false, "Error");
            }
            return new WebApiResponse<DistributorToProductResponse>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _distributorToProductRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", true);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<DistributorToProductResponse>>>> GetActive()
        {
            var distributorToProductResult = _mapper.Map<List<DistributorToProductResponse>>
                (await _distributorToProductRepository.GetActive().ToListAsync());
            if (distributorToProductResult.Count > 0)
            {
                return new WebApiResponse<List<DistributorToProductResponse>>(true, "Success", distributorToProductResult);
            }
            return new WebApiResponse<List<DistributorToProductResponse>>(false, "Error");
        }

    }
}
