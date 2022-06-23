using AutoMapper;
using Proje.API.Controllers.Base;
using Proje.Common.DTOs.County;
using Proje.Common.DTOs.User;
using Proje.Common.Models;
using Proje.Model.Entities;
using Proje.Service.Repository.County;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proje.API.Controllers
{
    [Route("county")]
    public class CountyController : BaseApiController<CountyController>
    {
        private readonly ICountyRepository _countyRepository;
        private readonly IMapper _mapper;

        public CountyController(
            ICountyRepository countyRepository,
            IMapper mapper)
        {
            _countyRepository = countyRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<CountyResponse>>>> GetCountys()
        {
            UserResponse user = WorkContext.CurrentUser;

            var countyResult = _mapper.Map<List<CountyResponse>>
                (await _countyRepository.TableNoTracking.ToListAsync());
            if (countyResult.Count > 0)
            {
                return new WebApiResponse<List<CountyResponse>>(true, "Success", countyResult);
            }
            return new WebApiResponse<List<CountyResponse>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<CountyResponse>>> GetCountys(Guid id)
        {
            var countyResult = _mapper.Map<CountyResponse>(await _countyRepository.GetById(id));
            if (countyResult != null)
            {
                return new WebApiResponse<CountyResponse>(true, "Success", countyResult);
            }
            return new WebApiResponse<CountyResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<CountyResponse>>> PostCounty(CountyRequest request)
        {
            County entity = _mapper.Map<County>(request);
            var insertResult = await _countyRepository.Add(entity);
            if (insertResult != null)
            {
                CountyResponse rm = _mapper.Map<CountyResponse>(insertResult);
                return new WebApiResponse<CountyResponse>(true, "Success", rm);
            }
            return new WebApiResponse<CountyResponse>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<CountyResponse>>> PutCounty(Guid id, CountyRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                County entity = await _countyRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _countyRepository.Update(entity);
                if (updateResult != null)
                {
                    CountyResponse rm = _mapper.Map<CountyResponse>(updateResult);
                    return new WebApiResponse<CountyResponse>(true, "Success", rm);
                }
                return new WebApiResponse<CountyResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<CountyResponse>>> DeleteCounty(Guid id)
        {
            County entity = await _countyRepository.GetById(id);
            if (entity != null)
            {
                if (await _countyRepository.Remove(entity))
                    return new WebApiResponse<CountyResponse>
                        (true, "Success", _mapper.Map<CountyResponse>(entity));
                else
                    return new WebApiResponse<CountyResponse>(false, "Error");
            }
            return new WebApiResponse<CountyResponse>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _countyRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", true);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<CountyResponse>>>> GetActive()
        {
            var countyResult = _mapper.Map<List<CountyResponse>>
                (await _countyRepository.GetActive().ToListAsync());
            if (countyResult.Count > 0)
            {
                return new WebApiResponse<List<CountyResponse>>(true, "Success", countyResult);
            }
            return new WebApiResponse<List<CountyResponse>>(false, "Error");
        }

    }
}
