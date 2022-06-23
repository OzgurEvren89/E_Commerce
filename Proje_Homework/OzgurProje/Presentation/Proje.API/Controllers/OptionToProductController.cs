using AutoMapper;
using Proje.API.Controllers.Base;
using Proje.Common.DTOs.OptionToProduct;
using Proje.Common.DTOs.User;
using Proje.Common.Models;
using Proje.Model.Entities;
using Proje.Service.Repository.OptionToProduct;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proje.API.Controllers
{
    [Route("optiontoproduct")]
    public class OptionToProductController : BaseApiController<OptionToProductController>
    {
        private readonly IOptionToProductRepository _optionToProductRepository;
        private readonly IMapper _mapper;

        public OptionToProductController(
            IOptionToProductRepository optionToProductRepository,
            IMapper mapper)
        {
            _optionToProductRepository = optionToProductRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<OptionToProductResponse>>>> GetOptionToProducts()
        {
            UserResponse user = WorkContext.CurrentUser;

            var optionToProductResult = _mapper.Map<List<OptionToProductResponse>>
                (await _optionToProductRepository.TableNoTracking.ToListAsync());
            if (optionToProductResult.Count > 0)
            {
                return new WebApiResponse<List<OptionToProductResponse>>(true, "Success", optionToProductResult);
            }
            return new WebApiResponse<List<OptionToProductResponse>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<OptionToProductResponse>>> GetOptionToProducts(Guid id)
        {
            var optionToProductResult = _mapper.Map<OptionToProductResponse>(await _optionToProductRepository.GetById(id));
            if (optionToProductResult != null)
            {
                return new WebApiResponse<OptionToProductResponse>(true, "Success", optionToProductResult);
            }
            return new WebApiResponse<OptionToProductResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<OptionToProductResponse>>> PostOptionToProduct(OptionToProductRequest request)
        {
            OptionToProduct entity = _mapper.Map<OptionToProduct>(request);
            var insertResult = await _optionToProductRepository.Add(entity);
            if (insertResult != null)
            {
                OptionToProductResponse rm = _mapper.Map<OptionToProductResponse>(insertResult);
                return new WebApiResponse<OptionToProductResponse>(true, "Success", rm);
            }
            return new WebApiResponse<OptionToProductResponse>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<OptionToProductResponse>>> PutOptionToProduct(Guid id, OptionToProductRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                OptionToProduct entity = await _optionToProductRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _optionToProductRepository.Update(entity);
                if (updateResult != null)
                {
                    OptionToProductResponse rm = _mapper.Map<OptionToProductResponse>(updateResult);
                    return new WebApiResponse<OptionToProductResponse>(true, "Success", rm);
                }
                return new WebApiResponse<OptionToProductResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<OptionToProductResponse>>> DeleteOptionToProduct(Guid id)
        {
            OptionToProduct entity = await _optionToProductRepository.GetById(id);
            if (entity != null)
            {
                if (await _optionToProductRepository.Remove(entity))
                    return new WebApiResponse<OptionToProductResponse>
                        (true, "Success", _mapper.Map<OptionToProductResponse>(entity));
                else
                    return new WebApiResponse<OptionToProductResponse>(false, "Error");
            }
            return new WebApiResponse<OptionToProductResponse>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _optionToProductRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", true);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<OptionToProductResponse>>>> GetActive()
        {
            var optionToProductResult = _mapper.Map<List<OptionToProductResponse>>
                (await _optionToProductRepository.GetActive().ToListAsync());
            if (optionToProductResult.Count > 0)
            {
                return new WebApiResponse<List<OptionToProductResponse>>(true, "Success", optionToProductResult);
            }
            return new WebApiResponse<List<OptionToProductResponse>>(false, "Error");
        }

    }
}
