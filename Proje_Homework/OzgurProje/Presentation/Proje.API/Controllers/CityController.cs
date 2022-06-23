using AutoMapper;
using Proje.API.Controllers.Base;
using Proje.Common.DTOs.City;
using Proje.Common.DTOs.User;
using Proje.Common.Models;
using Proje.Model.Entities;
using Proje.Service.Repository.City;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proje.API.Controllers
{
    [Route("city")]
    public class CityController : BaseApiController<CityController>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CityController(
            ICityRepository cityRepository,
            IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<CityResponse>>>> GetCitys()
        {
            UserResponse user = WorkContext.CurrentUser;

            var cityResult = _mapper.Map<List<CityResponse>>
                (await _cityRepository.TableNoTracking.ToListAsync());
            if (cityResult.Count > 0)
            {
                return new WebApiResponse<List<CityResponse>>(true, "Success", cityResult);
            }
            return new WebApiResponse<List<CityResponse>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<CityResponse>>> GetCitys(Guid id)
        {
            var cityResult = _mapper.Map<CityResponse>(await _cityRepository.GetById(id));
            if (cityResult != null)
            {
                return new WebApiResponse<CityResponse>(true, "Success", cityResult);
            }
            return new WebApiResponse<CityResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<CityResponse>>> PostCity(CityRequest request)
        {
            City entity = _mapper.Map<City>(request);
            var insertResult = await _cityRepository.Add(entity);
            if (insertResult != null)
            {
                CityResponse rm = _mapper.Map<CityResponse>(insertResult);
                return new WebApiResponse<CityResponse>(true, "Success", rm);
            }
            return new WebApiResponse<CityResponse>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<CityResponse>>> PutCity(Guid id, CityRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                City entity = await _cityRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _cityRepository.Update(entity);
                if (updateResult != null)
                {
                    CityResponse rm = _mapper.Map<CityResponse>(updateResult);
                    return new WebApiResponse<CityResponse>(true, "Success", rm);
                }
                return new WebApiResponse<CityResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<CityResponse>>> DeleteCity(Guid id)
        {
            City entity = await _cityRepository.GetById(id);
            if (entity != null)
            {
                if (await _cityRepository.Remove(entity))
                    return new WebApiResponse<CityResponse>
                        (true, "Success", _mapper.Map<CityResponse>(entity));
                else
                    return new WebApiResponse<CityResponse>(false, "Error");
            }
            return new WebApiResponse<CityResponse>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _cityRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", true);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<CityResponse>>>> GetActive()
        {
            var cityResult = _mapper.Map<List<CityResponse>>
                (await _cityRepository.GetActive().ToListAsync());
            if (cityResult.Count > 0)
            {
                return new WebApiResponse<List<CityResponse>>(true, "Success", cityResult);
            }
            return new WebApiResponse<List<CityResponse>>(false, "Error");
        }

    }
}
