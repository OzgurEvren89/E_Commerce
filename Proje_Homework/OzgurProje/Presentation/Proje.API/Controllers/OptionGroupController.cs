using AutoMapper;
using Proje.API.Controllers.Base;
using Proje.Common.DTOs.OptionGroup;
using Proje.Common.DTOs.User;
using Proje.Common.Models;
using Proje.Model.Entities;
using Proje.Service.Repository.OptionGroup;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proje.API.Controllers
{
    [Route("optiongroup")]
    public class OptionGroupController : BaseApiController<OptionGroupController>
    {
        private readonly IOptionGroupRepository _optionGroupRepository;
        private readonly IMapper _mapper;

        public OptionGroupController(
            IOptionGroupRepository optionGroupRepository,
            IMapper mapper)
        {
            _optionGroupRepository = optionGroupRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<OptionGroupResponse>>>> GetOptionGroups()
        {
            UserResponse user = WorkContext.CurrentUser;

            var optionGroupResult = _mapper.Map<List<OptionGroupResponse>>
                (await _optionGroupRepository.TableNoTracking.ToListAsync());
            if (optionGroupResult.Count > 0)
            {
                return new WebApiResponse<List<OptionGroupResponse>>(true, "Success", optionGroupResult);
            }
            return new WebApiResponse<List<OptionGroupResponse>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<OptionGroupResponse>>> GetOptionGroups(Guid id)
        {
            var optionGroupResult = _mapper.Map<OptionGroupResponse>(await _optionGroupRepository.GetById(id));
            if (optionGroupResult != null)
            {
                return new WebApiResponse<OptionGroupResponse>(true, "Success", optionGroupResult);
            }
            return new WebApiResponse<OptionGroupResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<OptionGroupResponse>>> PostOptionGroup(OptionGroupRequest request)
        {
            OptionGroup entity = _mapper.Map<OptionGroup>(request);
            var insertResult = await _optionGroupRepository.Add(entity);
            if (insertResult != null)
            {
                OptionGroupResponse rm = _mapper.Map<OptionGroupResponse>(insertResult);
                return new WebApiResponse<OptionGroupResponse>(true, "Success", rm);
            }
            return new WebApiResponse<OptionGroupResponse>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<OptionGroupResponse>>> PutOptionGroup(Guid id, OptionGroupRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                OptionGroup entity = await _optionGroupRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _optionGroupRepository.Update(entity);
                if (updateResult != null)
                {
                    OptionGroupResponse rm = _mapper.Map<OptionGroupResponse>(updateResult);
                    return new WebApiResponse<OptionGroupResponse>(true, "Success", rm);
                }
                return new WebApiResponse<OptionGroupResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<OptionGroupResponse>>> DeleteOptionGroup(Guid id)
        {
            OptionGroup entity = await _optionGroupRepository.GetById(id);
            if (entity != null)
            {
                if (await _optionGroupRepository.Remove(entity))
                    return new WebApiResponse<OptionGroupResponse>
                        (true, "Success", _mapper.Map<OptionGroupResponse>(entity));
                else
                    return new WebApiResponse<OptionGroupResponse>(false, "Error");
            }
            return new WebApiResponse<OptionGroupResponse>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _optionGroupRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", true);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<OptionGroupResponse>>>> GetActive()
        {
            var optionGroupResult = _mapper.Map<List<OptionGroupResponse>>
                (await _optionGroupRepository.GetActive().ToListAsync());
            if (optionGroupResult.Count > 0)
            {
                return new WebApiResponse<List<OptionGroupResponse>>(true, "Success", optionGroupResult);
            }
            return new WebApiResponse<List<OptionGroupResponse>>(false, "Error");
        }

    }
}
