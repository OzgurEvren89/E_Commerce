using AutoMapper;
using Proje.API.Controllers.Base;
using Proje.Common.DTOs.DemandReason;
using Proje.Common.DTOs.User;
using Proje.Common.Models;
using Proje.Model.Entities;
using Proje.Service.Repository.DemandReason;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proje.API.Controllers
{
    [Route("demandreason")]
    public class DemandReasonController : BaseApiController<DemandReasonController>
    {
        private readonly IDemandReasonRepository _demandReasonRepository;
        private readonly IMapper _mapper;

        public DemandReasonController(
            IDemandReasonRepository demandReasonRepository,
            IMapper mapper)
        {
            _demandReasonRepository = demandReasonRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<DemandReasonResponse>>>> GetDemandReasons()
        {
            UserResponse user = WorkContext.CurrentUser;

            var demandReasonResult = _mapper.Map<List<DemandReasonResponse>>
                (await _demandReasonRepository.TableNoTracking.ToListAsync());
            if (demandReasonResult.Count > 0)
            {
                return new WebApiResponse<List<DemandReasonResponse>>(true, "Success", demandReasonResult);
            }
            return new WebApiResponse<List<DemandReasonResponse>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<DemandReasonResponse>>> GetDemandReasons(Guid id)
        {
            var demandReasonResult = _mapper.Map<DemandReasonResponse>(await _demandReasonRepository.GetById(id));
            if (demandReasonResult != null)
            {
                return new WebApiResponse<DemandReasonResponse>(true, "Success", demandReasonResult);
            }
            return new WebApiResponse<DemandReasonResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<DemandReasonResponse>>> PostDemandReason(DemandReasonRequest request)
        {
            DemandReason entity = _mapper.Map<DemandReason>(request);
            var insertResult = await _demandReasonRepository.Add(entity);
            if (insertResult != null)
            {
                DemandReasonResponse rm = _mapper.Map<DemandReasonResponse>(insertResult);
                return new WebApiResponse<DemandReasonResponse>(true, "Success", rm);
            }
            return new WebApiResponse<DemandReasonResponse>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<DemandReasonResponse>>> PutDemandReason(Guid id, DemandReasonRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                DemandReason entity = await _demandReasonRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _demandReasonRepository.Update(entity);
                if (updateResult != null)
                {
                    DemandReasonResponse rm = _mapper.Map<DemandReasonResponse>(updateResult);
                    return new WebApiResponse<DemandReasonResponse>(true, "Success", rm);
                }
                return new WebApiResponse<DemandReasonResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<DemandReasonResponse>>> DeleteDemandReason(Guid id)
        {
            DemandReason entity = await _demandReasonRepository.GetById(id);
            if (entity != null)
            {
                if (await _demandReasonRepository.Remove(entity))
                    return new WebApiResponse<DemandReasonResponse>
                        (true, "Success", _mapper.Map<DemandReasonResponse>(entity));
                else
                    return new WebApiResponse<DemandReasonResponse>(false, "Error");
            }
            return new WebApiResponse<DemandReasonResponse>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _demandReasonRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", true);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<DemandReasonResponse>>>> GetActive()
        {
            var demandReasonResult = _mapper.Map<List<DemandReasonResponse>>
                (await _demandReasonRepository.GetActive().ToListAsync());
            if (demandReasonResult.Count > 0)
            {
                return new WebApiResponse<List<DemandReasonResponse>>(true, "Success", demandReasonResult);
            }
            return new WebApiResponse<List<DemandReasonResponse>>(false, "Error");
        }

    }
}
