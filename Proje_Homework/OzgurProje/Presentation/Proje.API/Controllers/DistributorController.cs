using AutoMapper;
using Proje.API.Controllers.Base;
using Proje.Common.DTOs.Distributor;
using Proje.Common.DTOs.User;
using Proje.Common.Models;
using Proje.Model.Entities;
using Proje.Service.Repository.Distributor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proje.API.Controllers
{
    [Route("distributor")]
    public class DistributorController : BaseApiController<DistributorController>
    {
        private readonly IDistributorRepository _distributorRepository;
        private readonly IMapper _mapper;

        public DistributorController(
            IDistributorRepository distributorRepository,
            IMapper mapper)
        {
            _distributorRepository = distributorRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<DistributorResponse>>>> GetDistributors()
        {
            UserResponse user = WorkContext.CurrentUser;

            var distributorResult = _mapper.Map<List<DistributorResponse>>
                (await _distributorRepository.TableNoTracking.ToListAsync());
            if (distributorResult.Count > 0)
            {
                return new WebApiResponse<List<DistributorResponse>>(true, "Success", distributorResult);
            }
            return new WebApiResponse<List<DistributorResponse>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<DistributorResponse>>> GetDistributors(Guid id)
        {
            var distributorResult = _mapper.Map<DistributorResponse>(await _distributorRepository.GetById(id));
            if (distributorResult != null)
            {
                return new WebApiResponse<DistributorResponse>(true, "Success", distributorResult);
            }
            return new WebApiResponse<DistributorResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<DistributorResponse>>> PostDistributor(DistributorRequest request)
        {
            Distributor entity = _mapper.Map<Distributor>(request);
            var insertResult = await _distributorRepository.Add(entity);
            if (insertResult != null)
            {
                DistributorResponse rm = _mapper.Map<DistributorResponse>(insertResult);
                return new WebApiResponse<DistributorResponse>(true, "Success", rm);
            }
            return new WebApiResponse<DistributorResponse>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<DistributorResponse>>> PutDistributor(Guid id, DistributorRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                Distributor entity = await _distributorRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _distributorRepository.Update(entity);
                if (updateResult != null)
                {
                    DistributorResponse rm = _mapper.Map<DistributorResponse>(updateResult);
                    return new WebApiResponse<DistributorResponse>(true, "Success", rm);
                }
                return new WebApiResponse<DistributorResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<DistributorResponse>>> DeleteDistributor(Guid id)
        {
            Distributor entity = await _distributorRepository.GetById(id);
            if (entity != null)
            {
                if (await _distributorRepository.Remove(entity))
                    return new WebApiResponse<DistributorResponse>
                        (true, "Success", _mapper.Map<DistributorResponse>(entity));
                else
                    return new WebApiResponse<DistributorResponse>(false, "Error");
            }
            return new WebApiResponse<DistributorResponse>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _distributorRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", true);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<DistributorResponse>>>> GetActive()
        {
            var distributorResult = _mapper.Map<List<DistributorResponse>>
                (await _distributorRepository.GetActive().ToListAsync());
            if (distributorResult.Count > 0)
            {
                return new WebApiResponse<List<DistributorResponse>>(true, "Success", distributorResult);
            }
            return new WebApiResponse<List<DistributorResponse>>(false, "Error");
        }

    }
}
