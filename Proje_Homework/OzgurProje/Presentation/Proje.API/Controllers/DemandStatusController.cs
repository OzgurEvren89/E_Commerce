using AutoMapper;
using Proje.API.Controllers.Base;
using Proje.Common.DTOs.DemandStatus;
using Proje.Common.DTOs.User;
using Proje.Common.Models;
using Proje.Model.Entities;
using Proje.Service.Repository.DemandStatus;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proje.API.Controllers
{
    [Route("demandstatus")]
    public class DemandStatusController : BaseApiController<DemandStatusController>
    {
        private readonly IDemandStatusRepository _demandStatusRepository;
        private readonly IMapper _mapper;

        public DemandStatusController(
            IDemandStatusRepository demandStatusRepository,
            IMapper mapper)
        {
            _demandStatusRepository = demandStatusRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<DemandStatusResponse>>>> GetDemandStatuss()
        {
            UserResponse user = WorkContext.CurrentUser;

            var demandStatusResult = _mapper.Map<List<DemandStatusResponse>>
                (await _demandStatusRepository.TableNoTracking.ToListAsync());
            if (demandStatusResult.Count > 0)
            {
                return new WebApiResponse<List<DemandStatusResponse>>(true, "Success", demandStatusResult);
            }
            return new WebApiResponse<List<DemandStatusResponse>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<DemandStatusResponse>>> GetDemandStatuss(Guid id)
        {
            var demandStatusResult = _mapper.Map<DemandStatusResponse>(await _demandStatusRepository.GetById(id));
            if (demandStatusResult != null)
            {
                return new WebApiResponse<DemandStatusResponse>(true, "Success", demandStatusResult);
            }
            return new WebApiResponse<DemandStatusResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<DemandStatusResponse>>> PostDemandStatus(DemandStatusRequest request)
        {
            DemandStatus entity = _mapper.Map<DemandStatus>(request);
            var insertResult = await _demandStatusRepository.Add(entity);
            if (insertResult != null)
            {
                DemandStatusResponse rm = _mapper.Map<DemandStatusResponse>(insertResult);
                return new WebApiResponse<DemandStatusResponse>(true, "Success", rm);
            }
            return new WebApiResponse<DemandStatusResponse>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<DemandStatusResponse>>> PutDemandStatus(Guid id, DemandStatusRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                DemandStatus entity = await _demandStatusRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _demandStatusRepository.Update(entity);
                if (updateResult != null)
                {
                    DemandStatusResponse rm = _mapper.Map<DemandStatusResponse>(updateResult);
                    return new WebApiResponse<DemandStatusResponse>(true, "Success", rm);
                }
                return new WebApiResponse<DemandStatusResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<DemandStatusResponse>>> DeleteDemandStatus(Guid id)
        {
            DemandStatus entity = await _demandStatusRepository.GetById(id);
            if (entity != null)
            {
                if (await _demandStatusRepository.Remove(entity))
                    return new WebApiResponse<DemandStatusResponse>
                        (true, "Success", _mapper.Map<DemandStatusResponse>(entity));
                else
                    return new WebApiResponse<DemandStatusResponse>(false, "Error");
            }
            return new WebApiResponse<DemandStatusResponse>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _demandStatusRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", true);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<DemandStatusResponse>>>> GetActive()
        {
            var demandStatusResult = _mapper.Map<List<DemandStatusResponse>>
                (await _demandStatusRepository.GetActive().ToListAsync());
            if (demandStatusResult.Count > 0)
            {
                return new WebApiResponse<List<DemandStatusResponse>>(true, "Success", demandStatusResult);
            }
            return new WebApiResponse<List<DemandStatusResponse>>(false, "Error");
        }

    }
}
