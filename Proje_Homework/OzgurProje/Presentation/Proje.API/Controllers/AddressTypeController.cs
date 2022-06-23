using AutoMapper;
using Proje.API.Controllers.Base;
using Proje.Common.DTOs.AddressType;
using Proje.Common.DTOs.User;
using Proje.Common.Models;
using Proje.Model.Entities;
using Proje.Service.Repository.AddressType;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proje.API.Controllers
{
    [Route("addresstype")]
    public class AddressTypeController : BaseApiController<AddressTypeController>
    {
        private readonly IAddressTypeRepository _addressTypeRepository;
        private readonly IMapper _mapper;

        public AddressTypeController(
            IAddressTypeRepository addressTypeRepository,
            IMapper mapper)
        {
            _addressTypeRepository = addressTypeRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<AddressTypeResponse>>>> GetAddressTypes()
        {
            UserResponse user = WorkContext.CurrentUser;

            var addressTypeResult = _mapper.Map<List<AddressTypeResponse>>
                (await _addressTypeRepository.TableNoTracking.ToListAsync());
            if (addressTypeResult.Count > 0)
            {
                return new WebApiResponse<List<AddressTypeResponse>>(true, "Success", addressTypeResult);
            }
            return new WebApiResponse<List<AddressTypeResponse>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<AddressTypeResponse>>> GetAddressTypes(Guid id)
        {
            var addressTypeResult = _mapper.Map<AddressTypeResponse>(await _addressTypeRepository.GetById(id));
            if (addressTypeResult != null)
            {
                return new WebApiResponse<AddressTypeResponse>(true, "Success", addressTypeResult);
            }
            return new WebApiResponse<AddressTypeResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<AddressTypeResponse>>> PostAddressType(AddressTypeRequest request)
        {
            AddressType entity = _mapper.Map<AddressType>(request);
            var insertResult = await _addressTypeRepository.Add(entity);
            if (insertResult != null)
            {
                AddressTypeResponse rm = _mapper.Map<AddressTypeResponse>(insertResult);
                return new WebApiResponse<AddressTypeResponse>(true, "Success", rm);
            }
            return new WebApiResponse<AddressTypeResponse>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<AddressTypeResponse>>> PutAddressType(Guid id, AddressTypeRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                AddressType entity = await _addressTypeRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _addressTypeRepository.Update(entity);
                if (updateResult != null)
                {
                    AddressTypeResponse rm = _mapper.Map<AddressTypeResponse>(updateResult);
                    return new WebApiResponse<AddressTypeResponse>(true, "Success", rm);
                }
                return new WebApiResponse<AddressTypeResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<AddressTypeResponse>>> DeleteAddressType(Guid id)
        {
            AddressType entity = await _addressTypeRepository.GetById(id);
            if (entity != null)
            {
                if (await _addressTypeRepository.Remove(entity))
                    return new WebApiResponse<AddressTypeResponse>
                        (true, "Success", _mapper.Map<AddressTypeResponse>(entity));
                else
                    return new WebApiResponse<AddressTypeResponse>(false, "Error");
            }
            return new WebApiResponse<AddressTypeResponse>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _addressTypeRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", true);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<AddressTypeResponse>>>> GetActive()
        {
            var addressTypeResult = _mapper.Map<List<AddressTypeResponse>>
                (await _addressTypeRepository.GetActive().ToListAsync());
            if (addressTypeResult.Count > 0)
            {
                return new WebApiResponse<List<AddressTypeResponse>>(true, "Success", addressTypeResult);
            }
            return new WebApiResponse<List<AddressTypeResponse>>(false, "Error");
        }

    }
}
