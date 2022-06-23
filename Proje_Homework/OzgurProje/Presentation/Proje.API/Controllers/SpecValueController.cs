using AutoMapper;
using Proje.API.Controllers.Base;
using Proje.Common.DTOs.SpecValue;
using Proje.Common.DTOs.User;
using Proje.Common.Models;
using Proje.Model.Entities;
using Proje.Service.Repository.SpecValue;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proje.API.Controllers
{
    [Route("specvalue")]
    public class SpecValueController : BaseApiController<SpecValueController>
    {
        private readonly ISpecValueRepository _specValueRepository;
        private readonly IMapper _mapper;

        public SpecValueController(
            ISpecValueRepository specValueRepository,
            IMapper mapper)
        {
            _specValueRepository = specValueRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<SpecValueResponse>>>> GetSpecValues()
        {
            UserResponse user = WorkContext.CurrentUser;

            var specValueResult = _mapper.Map<List<SpecValueResponse>>
                (await _specValueRepository.TableNoTracking.ToListAsync());
            if (specValueResult.Count > 0)
            {
                return new WebApiResponse<List<SpecValueResponse>>(true, "Success", specValueResult);
            }
            return new WebApiResponse<List<SpecValueResponse>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<SpecValueResponse>>> GetSpecValues(Guid id)
        {
            var specValueResult = _mapper.Map<SpecValueResponse>(await _specValueRepository.GetById(id));
            if (specValueResult != null)
            {
                return new WebApiResponse<SpecValueResponse>(true, "Success", specValueResult);
            }
            return new WebApiResponse<SpecValueResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<SpecValueResponse>>> PostSpecValue(SpecValueRequest request)
        {
            SpecValue entity = _mapper.Map<SpecValue>(request);
            var insertResult = await _specValueRepository.Add(entity);
            if (insertResult != null)
            {
                SpecValueResponse rm = _mapper.Map<SpecValueResponse>(insertResult);
                return new WebApiResponse<SpecValueResponse>(true, "Success", rm);
            }
            return new WebApiResponse<SpecValueResponse>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<SpecValueResponse>>> PutSpecValue(Guid id, SpecValueRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                SpecValue entity = await _specValueRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _specValueRepository.Update(entity);
                if (updateResult != null)
                {
                    SpecValueResponse rm = _mapper.Map<SpecValueResponse>(updateResult);
                    return new WebApiResponse<SpecValueResponse>(true, "Success", rm);
                }
                return new WebApiResponse<SpecValueResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<SpecValueResponse>>> DeleteSpecValue(Guid id)
        {
            SpecValue entity = await _specValueRepository.GetById(id);
            if (entity != null)
            {
                if (await _specValueRepository.Remove(entity))
                    return new WebApiResponse<SpecValueResponse>
                        (true, "Success", _mapper.Map<SpecValueResponse>(entity));
                else
                    return new WebApiResponse<SpecValueResponse>(false, "Error");
            }
            return new WebApiResponse<SpecValueResponse>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _specValueRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", true);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<SpecValueResponse>>>> GetActive()
        {
            var specValueResult = _mapper.Map<List<SpecValueResponse>>
                (await _specValueRepository.GetActive().ToListAsync());
            if (specValueResult.Count > 0)
            {
                return new WebApiResponse<List<SpecValueResponse>>(true, "Success", specValueResult);
            }
            return new WebApiResponse<List<SpecValueResponse>>(false, "Error");
        }

    }
}
