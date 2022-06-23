using AutoMapper;
using Proje.API.Controllers.Base;
using Proje.Common.DTOs.PhoneNumber;
using Proje.Common.DTOs.User;
using Proje.Common.Models;
using Proje.Model.Entities;
using Proje.Service.Repository.PhoneNumber;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proje.API.Controllers
{
    [Route("phonenumber")]
    public class PhoneNumberController : BaseApiController<PhoneNumberController>
    {
        private readonly IPhoneNumberRepository _phoneNumberRepository;
        private readonly IMapper _mapper;

        public PhoneNumberController(
            IPhoneNumberRepository phoneNumberRepository,
            IMapper mapper)
        {
            _phoneNumberRepository = phoneNumberRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<PhoneNumberResponse>>>> GetPhoneNumbers()
        {
            UserResponse user = WorkContext.CurrentUser;

            var phoneNumberResult = _mapper.Map<List<PhoneNumberResponse>>
                (await _phoneNumberRepository.TableNoTracking.ToListAsync());
            if (phoneNumberResult.Count > 0)
            {
                return new WebApiResponse<List<PhoneNumberResponse>>(true, "Success", phoneNumberResult);
            }
            return new WebApiResponse<List<PhoneNumberResponse>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<PhoneNumberResponse>>> GetPhoneNumbers(Guid id)
        {
            var phoneNumberResult = _mapper.Map<PhoneNumberResponse>(await _phoneNumberRepository.GetById(id));
            if (phoneNumberResult != null)
            {
                return new WebApiResponse<PhoneNumberResponse>(true, "Success", phoneNumberResult);
            }
            return new WebApiResponse<PhoneNumberResponse>(false, "Error");
        }

        [HttpPost, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<PhoneNumberResponse>>> PostPhoneNumber(PhoneNumberRequest request)
        {
            PhoneNumber entity = _mapper.Map<PhoneNumber>(request);
            var insertResult = await _phoneNumberRepository.Add(entity);
            if (insertResult != null)
            {
                PhoneNumberResponse rm = _mapper.Map<PhoneNumberResponse>(insertResult);
                return new WebApiResponse<PhoneNumberResponse>(true, "Success", rm);
            }
            return new WebApiResponse<PhoneNumberResponse>(false, "Error");
        }

        [HttpPut("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<PhoneNumberResponse>>> PutPhoneNumber(Guid id, PhoneNumberRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                PhoneNumber entity = await _phoneNumberRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _phoneNumberRepository.Update(entity);
                if (updateResult != null)
                {
                    PhoneNumberResponse rm = _mapper.Map<PhoneNumberResponse>(updateResult);
                    return new WebApiResponse<PhoneNumberResponse>(true, "Success", rm);
                }
                return new WebApiResponse<PhoneNumberResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<PhoneNumberResponse>>> DeletePhoneNumber(Guid id)
        {
            PhoneNumber entity = await _phoneNumberRepository.GetById(id);
            if (entity != null)
            {
                if (await _phoneNumberRepository.Remove(entity))
                    return new WebApiResponse<PhoneNumberResponse>
                        (true, "Success", _mapper.Map<PhoneNumberResponse>(entity));
                else
                    return new WebApiResponse<PhoneNumberResponse>(false, "Error");
            }
            return new WebApiResponse<PhoneNumberResponse>(false, "Error");
        }

        [HttpGet("activate/{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _phoneNumberRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", true);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<PhoneNumberResponse>>>> GetActive()
        {
            var phoneNumberResult = _mapper.Map<List<PhoneNumberResponse>>
                (await _phoneNumberRepository.GetActive().ToListAsync());
            if (phoneNumberResult.Count > 0)
            {
                return new WebApiResponse<List<PhoneNumberResponse>>(true, "Success", phoneNumberResult);
            }
            return new WebApiResponse<List<PhoneNumberResponse>>(false, "Error");
        }

    }
}
