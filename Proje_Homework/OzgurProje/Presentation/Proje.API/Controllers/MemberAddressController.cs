using AutoMapper;
using Proje.API.Controllers.Base;
using Proje.Common.DTOs.MemberAddress;
using Proje.Common.DTOs.User;
using Proje.Common.Models;
using Proje.Model.Entities;
using Proje.Service.Repository.MemberAddress;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proje.API.Controllers
{
    [Route("memberaddress")]
    public class MemberAddressController : BaseApiController<MemberAddressController>
    {
        private readonly IMemberAddressRepository _memberAddressRepository;
        private readonly IMapper _mapper;

        public MemberAddressController(
            IMemberAddressRepository memberAddressRepository,
            IMapper mapper)
        {
            _memberAddressRepository = memberAddressRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<MemberAddressResponse>>>> GetMemberAddresss()
        {
            UserResponse user = WorkContext.CurrentUser;

            var memberAddressResult = _mapper.Map<List<MemberAddressResponse>>
                (await _memberAddressRepository.TableNoTracking.ToListAsync());
            if (memberAddressResult.Count > 0)
            {
                return new WebApiResponse<List<MemberAddressResponse>>(true, "Success", memberAddressResult);
            }
            return new WebApiResponse<List<MemberAddressResponse>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<MemberAddressResponse>>> GetMemberAddresss(Guid id)
        {
            var memberAddressResult = _mapper.Map<MemberAddressResponse>(await _memberAddressRepository.GetById(id));
            if (memberAddressResult != null)
            {
                return new WebApiResponse<MemberAddressResponse>(true, "Success", memberAddressResult);
            }
            return new WebApiResponse<MemberAddressResponse>(false, "Error");
        }

        [HttpPost, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<MemberAddressResponse>>> PostMemberAddress(MemberAddressRequest request)
        {
            MemberAddress entity = _mapper.Map<MemberAddress>(request);
            var insertResult = await _memberAddressRepository.Add(entity);
            if (insertResult != null)
            {
                MemberAddressResponse rm = _mapper.Map<MemberAddressResponse>(insertResult);
                return new WebApiResponse<MemberAddressResponse>(true, "Success", rm);
            }
            return new WebApiResponse<MemberAddressResponse>(false, "Error");
        }

        [HttpPut("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<MemberAddressResponse>>> PutMemberAddress(Guid id, MemberAddressRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                MemberAddress entity = await _memberAddressRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _memberAddressRepository.Update(entity);
                if (updateResult != null)
                {
                    MemberAddressResponse rm = _mapper.Map<MemberAddressResponse>(updateResult);
                    return new WebApiResponse<MemberAddressResponse>(true, "Success", rm);
                }
                return new WebApiResponse<MemberAddressResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<MemberAddressResponse>>> DeleteMemberAddress(Guid id)
        {
            MemberAddress entity = await _memberAddressRepository.GetById(id);
            if (entity != null)
            {
                if (await _memberAddressRepository.Remove(entity))
                    return new WebApiResponse<MemberAddressResponse>
                        (true, "Success", _mapper.Map<MemberAddressResponse>(entity));
                else
                    return new WebApiResponse<MemberAddressResponse>(false, "Error");
            }
            return new WebApiResponse<MemberAddressResponse>(false, "Error");
        }

        [HttpGet("activate/{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _memberAddressRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", true);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<MemberAddressResponse>>>> GetActive()
        {
            var memberAddressResult = _mapper.Map<List<MemberAddressResponse>>
                (await _memberAddressRepository.GetActive().ToListAsync());
            if (memberAddressResult.Count > 0)
            {
                return new WebApiResponse<List<MemberAddressResponse>>(true, "Success", memberAddressResult);
            }
            return new WebApiResponse<List<MemberAddressResponse>>(false, "Error");
        }

    }
}
