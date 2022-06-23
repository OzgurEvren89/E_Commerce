using AutoMapper;
using Proje.API.Controllers.Base;
using Proje.Common.DTOs.ShippingCompany;
using Proje.Common.DTOs.User;
using Proje.Common.Models;
using Proje.Model.Entities;
using Proje.Service.Repository.ShippingCompany;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proje.API.Controllers
{
    [Route("shippingcompany")]
    public class ShippingCompanyController : BaseApiController<ShippingCompanyController>
    {
        private readonly IShippingCompanyRepository _shippingCompanyRepository;
        private readonly IMapper _mapper;

        public ShippingCompanyController(
            IShippingCompanyRepository shippingCompanyRepository,
            IMapper mapper)
        {
            _shippingCompanyRepository = shippingCompanyRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<ShippingCompanyResponse>>>> GetShippingCompanys()
        {
            UserResponse user = WorkContext.CurrentUser;

            var shippingCompanyResult = _mapper.Map<List<ShippingCompanyResponse>>
                (await _shippingCompanyRepository.TableNoTracking.ToListAsync());
            if (shippingCompanyResult.Count > 0)
            {
                return new WebApiResponse<List<ShippingCompanyResponse>>(true, "Success", shippingCompanyResult);
            }
            return new WebApiResponse<List<ShippingCompanyResponse>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<ShippingCompanyResponse>>> GetShippingCompanys(Guid id)
        {
            var shippingCompanyResult = _mapper.Map<ShippingCompanyResponse>(await _shippingCompanyRepository.GetById(id));
            if (shippingCompanyResult != null)
            {
                return new WebApiResponse<ShippingCompanyResponse>(true, "Success", shippingCompanyResult);
            }
            return new WebApiResponse<ShippingCompanyResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<ShippingCompanyResponse>>> PostShippingCompany(ShippingCompanyRequest request)
        {
            ShippingCompany entity = _mapper.Map<ShippingCompany>(request);
            var insertResult = await _shippingCompanyRepository.Add(entity);
            if (insertResult != null)
            {
                ShippingCompanyResponse rm = _mapper.Map<ShippingCompanyResponse>(insertResult);
                return new WebApiResponse<ShippingCompanyResponse>(true, "Success", rm);
            }
            return new WebApiResponse<ShippingCompanyResponse>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<ShippingCompanyResponse>>> PutShippingCompany(Guid id, ShippingCompanyRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                ShippingCompany entity = await _shippingCompanyRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _shippingCompanyRepository.Update(entity);
                if (updateResult != null)
                {
                    ShippingCompanyResponse rm = _mapper.Map<ShippingCompanyResponse>(updateResult);
                    return new WebApiResponse<ShippingCompanyResponse>(true, "Success", rm);
                }
                return new WebApiResponse<ShippingCompanyResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<ShippingCompanyResponse>>> DeleteShippingCompany(Guid id)
        {
            ShippingCompany entity = await _shippingCompanyRepository.GetById(id);
            if (entity != null)
            {
                if (await _shippingCompanyRepository.Remove(entity))
                    return new WebApiResponse<ShippingCompanyResponse>
                        (true, "Success", _mapper.Map<ShippingCompanyResponse>(entity));
                else
                    return new WebApiResponse<ShippingCompanyResponse>(false, "Error");
            }
            return new WebApiResponse<ShippingCompanyResponse>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _shippingCompanyRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", true);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<ShippingCompanyResponse>>>> GetActive()
        {
            var shippingCompanyResult = _mapper.Map<List<ShippingCompanyResponse>>
                (await _shippingCompanyRepository.GetActive().ToListAsync());
            if (shippingCompanyResult.Count > 0)
            {
                return new WebApiResponse<List<ShippingCompanyResponse>>(true, "Success", shippingCompanyResult);
            }
            return new WebApiResponse<List<ShippingCompanyResponse>>(false, "Error");
        }

    }
}
