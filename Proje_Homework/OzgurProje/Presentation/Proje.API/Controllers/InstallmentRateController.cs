using AutoMapper;
using Proje.API.Controllers.Base;
using Proje.Common.DTOs.InstallmentRate;
using Proje.Common.DTOs.User;
using Proje.Common.Models;
using Proje.Model.Entities;
using Proje.Service.Repository.InstallmentRate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proje.API.Controllers
{
    [Route("installmentrate")]
    public class InstallmentRateController : BaseApiController<InstallmentRateController>
    {
        private readonly IInstallmentRateRepository _installmentRateRepository;
        private readonly IMapper _mapper;

        public InstallmentRateController(
            IInstallmentRateRepository installmentRateRepository,
            IMapper mapper)
        {
            _installmentRateRepository = installmentRateRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<InstallmentRateResponse>>>> GetInstallmentRates()
        {
            UserResponse user = WorkContext.CurrentUser;

            var installmentRateResult = _mapper.Map<List<InstallmentRateResponse>>
                (await _installmentRateRepository.TableNoTracking.ToListAsync());
            if (installmentRateResult.Count > 0)
            {
                return new WebApiResponse<List<InstallmentRateResponse>>(true, "Success", installmentRateResult);
            }
            return new WebApiResponse<List<InstallmentRateResponse>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<InstallmentRateResponse>>> GetInstallmentRates(Guid id)
        {
            var installmentRateResult = _mapper.Map<InstallmentRateResponse>(await _installmentRateRepository.GetById(id));
            if (installmentRateResult != null)
            {
                return new WebApiResponse<InstallmentRateResponse>(true, "Success", installmentRateResult);
            }
            return new WebApiResponse<InstallmentRateResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<InstallmentRateResponse>>> PostInstallmentRate(InstallmentRateRequest request)
        {
            InstallmentRate entity = _mapper.Map<InstallmentRate>(request);
            var insertResult = await _installmentRateRepository.Add(entity);
            if (insertResult != null)
            {
                InstallmentRateResponse rm = _mapper.Map<InstallmentRateResponse>(insertResult);
                return new WebApiResponse<InstallmentRateResponse>(true, "Success", rm);
            }
            return new WebApiResponse<InstallmentRateResponse>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<InstallmentRateResponse>>> PutInstallmentRate(Guid id, InstallmentRateRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                InstallmentRate entity = await _installmentRateRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _installmentRateRepository.Update(entity);
                if (updateResult != null)
                {
                    InstallmentRateResponse rm = _mapper.Map<InstallmentRateResponse>(updateResult);
                    return new WebApiResponse<InstallmentRateResponse>(true, "Success", rm);
                }
                return new WebApiResponse<InstallmentRateResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<InstallmentRateResponse>>> DeleteInstallmentRate(Guid id)
        {
            InstallmentRate entity = await _installmentRateRepository.GetById(id);
            if (entity != null)
            {
                if (await _installmentRateRepository.Remove(entity))
                    return new WebApiResponse<InstallmentRateResponse>
                        (true, "Success", _mapper.Map<InstallmentRateResponse>(entity));
                else
                    return new WebApiResponse<InstallmentRateResponse>(false, "Error");
            }
            return new WebApiResponse<InstallmentRateResponse>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _installmentRateRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", true);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<InstallmentRateResponse>>>> GetActive()
        {
            var installmentRateResult = _mapper.Map<List<InstallmentRateResponse>>
                (await _installmentRateRepository.GetActive().ToListAsync());
            if (installmentRateResult.Count > 0)
            {
                return new WebApiResponse<List<InstallmentRateResponse>>(true, "Success", installmentRateResult);
            }
            return new WebApiResponse<List<InstallmentRateResponse>>(false, "Error");
        }
    }
}
