using AutoMapper;
using Proje.API.Controllers.Base;
using Proje.Common.DTOs.CurrencyValue;
using Proje.Common.DTOs.User;
using Proje.Common.Models;
using Proje.Model.Entities;
using Proje.Service.Repository.CurrencyValue;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proje.API.Controllers
{
    [Route("currencyvalue")]
    public class CurrencyValueController : BaseApiController<CurrencyValueController>
    {
        private readonly ICurrencyValueRepository _currencyValueRepository;
        private readonly IMapper _mapper;

        public CurrencyValueController(
            ICurrencyValueRepository currencyValueRepository,
            IMapper mapper)
        {
            _currencyValueRepository = currencyValueRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<CurrencyValueResponse>>>> GetCurrencyValues()
        {
            UserResponse user = WorkContext.CurrentUser;

            var currencyValueResult = _mapper.Map<List<CurrencyValueResponse>>
                (await _currencyValueRepository.TableNoTracking.ToListAsync());
            if (currencyValueResult.Count > 0)
            {
                return new WebApiResponse<List<CurrencyValueResponse>>(true, "Success", currencyValueResult);
            }
            return new WebApiResponse<List<CurrencyValueResponse>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<CurrencyValueResponse>>> GetCurrencyValues(Guid id)
        {
            var currencyValueResult = _mapper.Map<CurrencyValueResponse>(await _currencyValueRepository.GetById(id));
            if (currencyValueResult != null)
            {
                return new WebApiResponse<CurrencyValueResponse>(true, "Success", currencyValueResult);
            }
            return new WebApiResponse<CurrencyValueResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<CurrencyValueResponse>>> PostCurrencyValue(CurrencyValueRequest request)
        {
            CurrencyValue entity = _mapper.Map<CurrencyValue>(request);
            var insertResult = await _currencyValueRepository.Add(entity);
            if (insertResult != null)
            {
                CurrencyValueResponse rm = _mapper.Map<CurrencyValueResponse>(insertResult);
                return new WebApiResponse<CurrencyValueResponse>(true, "Success", rm);
            }
            return new WebApiResponse<CurrencyValueResponse>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<CurrencyValueResponse>>> PutCurrencyValue(Guid id, CurrencyValueRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                CurrencyValue entity = await _currencyValueRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _currencyValueRepository.Update(entity);
                if (updateResult != null)
                {
                    CurrencyValueResponse rm = _mapper.Map<CurrencyValueResponse>(updateResult);
                    return new WebApiResponse<CurrencyValueResponse>(true, "Success", rm);
                }
                return new WebApiResponse<CurrencyValueResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<CurrencyValueResponse>>> DeleteCurrencyValue(Guid id)
        {
            CurrencyValue entity = await _currencyValueRepository.GetById(id);
            if (entity != null)
            {
                if (await _currencyValueRepository.Remove(entity))
                    return new WebApiResponse<CurrencyValueResponse>
                        (true, "Success", _mapper.Map<CurrencyValueResponse>(entity));
                else
                    return new WebApiResponse<CurrencyValueResponse>(false, "Error");
            }
            return new WebApiResponse<CurrencyValueResponse>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _currencyValueRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", true);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<CurrencyValueResponse>>>> GetActive()
        {
            var currencyValueResult = _mapper.Map<List<CurrencyValueResponse>>
                (await _currencyValueRepository.GetActive().ToListAsync());
            if (currencyValueResult.Count > 0)
            {
                return new WebApiResponse<List<CurrencyValueResponse>>(true, "Success", currencyValueResult);
            }
            return new WebApiResponse<List<CurrencyValueResponse>>(false, "Error");
        }

    }
}
