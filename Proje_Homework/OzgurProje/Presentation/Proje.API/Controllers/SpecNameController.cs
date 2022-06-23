using AutoMapper;
using Proje.API.Controllers.Base;
using Proje.Common.DTOs.SpecName;
using Proje.Common.DTOs.User;
using Proje.Common.Models;
using Proje.Model.Entities;
using Proje.Service.Repository.SpecName;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proje.API.Controllers
{
    [Route("specname")]
    public class SpecNameController : BaseApiController<SpecNameController>
    {
        private readonly ISpecNameRepository _specnameRepository;
        private readonly IMapper _mapper;

        public SpecNameController(
            ISpecNameRepository specNameRepository,
            IMapper mapper)
        {
            _specnameRepository = specNameRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<SpecNameResponse>>>> GetSpecNames()
        {
            UserResponse user = WorkContext.CurrentUser;

            var specnameResult = _mapper.Map<List<SpecNameResponse>>
                (await _specnameRepository.TableNoTracking.ToListAsync());
            if (specnameResult.Count > 0)
            {
                return new WebApiResponse<List<SpecNameResponse>>(true, "Success", specnameResult);
            }
            return new WebApiResponse<List<SpecNameResponse>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<SpecNameResponse>>> GetSpecNames(Guid id)
        {
            var specnameResult = _mapper.Map<SpecNameResponse>(await _specnameRepository.GetById(id));
            if (specnameResult != null)
            {
                return new WebApiResponse<SpecNameResponse>(true, "Success", specnameResult);
            }
            return new WebApiResponse<SpecNameResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<SpecNameResponse>>> PostSpecName(SpecNameRequest request)
        {
            SpecName entity = _mapper.Map<SpecName>(request);
            var insertResult = await _specnameRepository.Add(entity);
            if (insertResult != null)
            {
                SpecNameResponse rm = _mapper.Map<SpecNameResponse>(insertResult);
                return new WebApiResponse<SpecNameResponse>(true, "Success", rm);
            }
            return new WebApiResponse<SpecNameResponse>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<SpecNameResponse>>> PutSpecName(Guid id, SpecNameRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                SpecName entity = await _specnameRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _specnameRepository.Update(entity);
                if (updateResult != null)
                {
                    SpecNameResponse rm = _mapper.Map<SpecNameResponse>(updateResult);
                    return new WebApiResponse<SpecNameResponse>(true, "Success", rm);
                }
                return new WebApiResponse<SpecNameResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<SpecNameResponse>>> DeleteSpecName(Guid id)
        {
            SpecName entity = await _specnameRepository.GetById(id);
            if (entity != null)
            {
                if (await _specnameRepository.Remove(entity))
                    return new WebApiResponse<SpecNameResponse>
                        (true, "Success", _mapper.Map<SpecNameResponse>(entity));
                else
                    return new WebApiResponse<SpecNameResponse>(false, "Error");
            }
            return new WebApiResponse<SpecNameResponse>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _specnameRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", true);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<SpecNameResponse>>>> GetActive()
        {
            var specnameResult = _mapper.Map<List<SpecNameResponse>>
                (await _specnameRepository.GetActive().ToListAsync());
            if (specnameResult.Count > 0)
            {
                return new WebApiResponse<List<SpecNameResponse>>(true, "Success", specnameResult);
            }
            return new WebApiResponse<List<SpecNameResponse>>(false, "Error");
        }

    }
}
