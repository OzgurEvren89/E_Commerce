using AutoMapper;
using Proje.API.Controllers.Base;
using Proje.Common.DTOs.Options;
using Proje.Common.DTOs.User;
using Proje.Common.Models;
using Proje.Model.Entities;
using Proje.Service.Repository.Options;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proje.API.Controllers
{
    [Route("options")]
    public class OptionsController : BaseApiController<OptionsController>
    {
        private readonly IOptionsRepository _optionsRepository;
        private readonly IMapper _mapper;

        public OptionsController(
            IOptionsRepository optionsRepository,
            IMapper mapper)
        {
            _optionsRepository = optionsRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<OptionsResponse>>>> GetOptionss()
        {
            UserResponse user = WorkContext.CurrentUser;

            var optionsResult = _mapper.Map<List<OptionsResponse>>
                (await _optionsRepository.TableNoTracking.ToListAsync());
            if (optionsResult.Count > 0)
            {
                return new WebApiResponse<List<OptionsResponse>>(true, "Success", optionsResult);
            }
            return new WebApiResponse<List<OptionsResponse>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<OptionsResponse>>> GetOptionss(Guid id)
        {
            var optionsResult = _mapper.Map<OptionsResponse>(await _optionsRepository.GetById(id));
            if (optionsResult != null)
            {
                return new WebApiResponse<OptionsResponse>(true, "Success", optionsResult);
            }
            return new WebApiResponse<OptionsResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<OptionsResponse>>> PostOptions(OptionsRequest request)
        {
            Options entity = _mapper.Map<Options>(request);
            var insertResult = await _optionsRepository.Add(entity);
            if (insertResult != null)
            {
                OptionsResponse rm = _mapper.Map<OptionsResponse>(insertResult);
                return new WebApiResponse<OptionsResponse>(true, "Success", rm);
            }
            return new WebApiResponse<OptionsResponse>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<OptionsResponse>>> PutOptions(Guid id, OptionsRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                Options entity = await _optionsRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _optionsRepository.Update(entity);
                if (updateResult != null)
                {
                    OptionsResponse rm = _mapper.Map<OptionsResponse>(updateResult);
                    return new WebApiResponse<OptionsResponse>(true, "Success", rm);
                }
                return new WebApiResponse<OptionsResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<OptionsResponse>>> DeleteOptions(Guid id)
        {
            Options entity = await _optionsRepository.GetById(id);
            if (entity != null)
            {
                if (await _optionsRepository.Remove(entity))
                    return new WebApiResponse<OptionsResponse>
                        (true, "Success", _mapper.Map<OptionsResponse>(entity));
                else
                    return new WebApiResponse<OptionsResponse>(false, "Error");
            }
            return new WebApiResponse<OptionsResponse>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _optionsRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", true);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<OptionsResponse>>>> GetActive()
        {
            var optionsResult = _mapper.Map<List<OptionsResponse>>
                (await _optionsRepository.GetActive().ToListAsync());
            if (optionsResult.Count > 0)
            {
                return new WebApiResponse<List<OptionsResponse>>(true, "Success", optionsResult);
            }
            return new WebApiResponse<List<OptionsResponse>>(false, "Error");
        }

    }
}
