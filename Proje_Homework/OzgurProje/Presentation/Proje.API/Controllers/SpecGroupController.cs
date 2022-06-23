using AutoMapper;
using Proje.API.Controllers.Base;
using Proje.Common.DTOs.SpecGroup;
using Proje.Common.DTOs.User;
using Proje.Common.Models;
using Proje.Model.Entities;
using Proje.Service.Repository.SpecGroup;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proje.API.Controllers
{
    [Route("specgroup")]
    public class SpecGroupController : BaseApiController<SpecGroupController>
    {
        private readonly ISpecGroupRepository _specGroupRepository;
        private readonly IMapper _mapper;

        public SpecGroupController(
            ISpecGroupRepository specGroupRepository,
            IMapper mapper)
        {
            _specGroupRepository = specGroupRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<SpecGroupResponse>>>> GetSpecGroups()
        {
            UserResponse user = WorkContext.CurrentUser;

            var specGroupResult = _mapper.Map<List<SpecGroupResponse>>
                (await _specGroupRepository.TableNoTracking.ToListAsync());
            if (specGroupResult.Count > 0)
            {
                return new WebApiResponse<List<SpecGroupResponse>>(true, "Success", specGroupResult);
            }
            return new WebApiResponse<List<SpecGroupResponse>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<SpecGroupResponse>>> GetSpecGroups(Guid id)
        {
            var specGroupResult = _mapper.Map<SpecGroupResponse>(await _specGroupRepository.GetById(id));
            if (specGroupResult != null)
            {
                return new WebApiResponse<SpecGroupResponse>(true, "Success", specGroupResult);
            }
            return new WebApiResponse<SpecGroupResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<SpecGroupResponse>>> PostSpecGroup(SpecGroupRequest request)
        {
            SpecGroup entity = _mapper.Map<SpecGroup>(request);
            var insertResult = await _specGroupRepository.Add(entity);
            if (insertResult != null)
            {
                SpecGroupResponse rm = _mapper.Map<SpecGroupResponse>(insertResult);
                return new WebApiResponse<SpecGroupResponse>(true, "Success", rm);
            }
            return new WebApiResponse<SpecGroupResponse>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<SpecGroupResponse>>> PutSpecGroup(Guid id, SpecGroupRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                SpecGroup entity = await _specGroupRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _specGroupRepository.Update(entity);
                if (updateResult != null)
                {
                    SpecGroupResponse rm = _mapper.Map<SpecGroupResponse>(updateResult);
                    return new WebApiResponse<SpecGroupResponse>(true, "Success", rm);
                }
                return new WebApiResponse<SpecGroupResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<SpecGroupResponse>>> DeleteSpecGroup(Guid id)
        {
            SpecGroup entity = await _specGroupRepository.GetById(id);
            if (entity != null)
            {
                if (await _specGroupRepository.Remove(entity))
                    return new WebApiResponse<SpecGroupResponse>
                        (true, "Success", _mapper.Map<SpecGroupResponse>(entity));
                else
                    return new WebApiResponse<SpecGroupResponse>(false, "Error");
            }
            return new WebApiResponse<SpecGroupResponse>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _specGroupRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", true);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<SpecGroupResponse>>>> GetActive()
        {
            var specGroupResult = _mapper.Map<List<SpecGroupResponse>>
                (await _specGroupRepository.GetActive().ToListAsync());
            if (specGroupResult.Count > 0)
            {
                return new WebApiResponse<List<SpecGroupResponse>>(true, "Success", specGroupResult);
            }
            return new WebApiResponse<List<SpecGroupResponse>>(false, "Error");
        }

    }
}
