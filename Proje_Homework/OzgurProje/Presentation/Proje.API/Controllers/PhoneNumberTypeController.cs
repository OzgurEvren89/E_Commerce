using AutoMapper;
using Proje.API.Controllers.Base;
using Proje.Common.DTOs.PhoneNumberType;
using Proje.Common.DTOs.User;
using Proje.Common.Models;
using Proje.Model.Entities;
using Proje.Service.Repository.PhoneNumberType;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proje.API.Controllers
{
    [Route("phonenumbertype")]
    public class PhoneNumberTypeController : BaseApiController<PhoneNumberTypeController>
    {
        private readonly IPhoneNumberTypeRepository _phoneNumberTypeRepository;
        private readonly IMapper _mapper;

        public PhoneNumberTypeController(
            IPhoneNumberTypeRepository phoneNumberTypeRepository,
            IMapper mapper)
        {
            _phoneNumberTypeRepository = phoneNumberTypeRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<PhoneNumberTypeResponse>>>> GetPhoneNumberTypes()
        {
            UserResponse user = WorkContext.CurrentUser;

            var phoneNumberTypeResult = _mapper.Map<List<PhoneNumberTypeResponse>>
                (await _phoneNumberTypeRepository.TableNoTracking.ToListAsync());
            if (phoneNumberTypeResult.Count > 0)
            {
                return new WebApiResponse<List<PhoneNumberTypeResponse>>(true, "Success", phoneNumberTypeResult);
            }
            return new WebApiResponse<List<PhoneNumberTypeResponse>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<PhoneNumberTypeResponse>>> GetPhoneNumberTypes(Guid id)
        {
            var phoneNumberTypeResult = _mapper.Map<PhoneNumberTypeResponse>(await _phoneNumberTypeRepository.GetById(id));
            if (phoneNumberTypeResult != null)
            {
                return new WebApiResponse<PhoneNumberTypeResponse>(true, "Success", phoneNumberTypeResult);
            }
            return new WebApiResponse<PhoneNumberTypeResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<PhoneNumberTypeResponse>>> PostPhoneNumberType(PhoneNumberTypeRequest request)
        {
            PhoneNumberType entity = _mapper.Map<PhoneNumberType>(request);
            var insertResult = await _phoneNumberTypeRepository.Add(entity);
            if (insertResult != null)
            {
                PhoneNumberTypeResponse rm = _mapper.Map<PhoneNumberTypeResponse>(insertResult);
                return new WebApiResponse<PhoneNumberTypeResponse>(true, "Success", rm);
            }
            return new WebApiResponse<PhoneNumberTypeResponse>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<PhoneNumberTypeResponse>>> PutPhoneNumberType(Guid id, PhoneNumberTypeRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                PhoneNumberType entity = await _phoneNumberTypeRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _phoneNumberTypeRepository.Update(entity);
                if (updateResult != null)
                {
                    PhoneNumberTypeResponse rm = _mapper.Map<PhoneNumberTypeResponse>(updateResult);
                    return new WebApiResponse<PhoneNumberTypeResponse>(true, "Success", rm);
                }
                return new WebApiResponse<PhoneNumberTypeResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<PhoneNumberTypeResponse>>> DeletePhoneNumberType(Guid id)
        {
            PhoneNumberType entity = await _phoneNumberTypeRepository.GetById(id);
            if (entity != null)
            {
                if (await _phoneNumberTypeRepository.Remove(entity))
                    return new WebApiResponse<PhoneNumberTypeResponse>
                        (true, "Success", _mapper.Map<PhoneNumberTypeResponse>(entity));
                else
                    return new WebApiResponse<PhoneNumberTypeResponse>(false, "Error");
            }
            return new WebApiResponse<PhoneNumberTypeResponse>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _phoneNumberTypeRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", true);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<PhoneNumberTypeResponse>>>> GetActive()
        {
            var phoneNumberTypeResult = _mapper.Map<List<PhoneNumberTypeResponse>>
                (await _phoneNumberTypeRepository.GetActive().ToListAsync());
            if (phoneNumberTypeResult.Count > 0)
            {
                return new WebApiResponse<List<PhoneNumberTypeResponse>>(true, "Success", phoneNumberTypeResult);
            }
            return new WebApiResponse<List<PhoneNumberTypeResponse>>(false, "Error");
        }

    }
}
