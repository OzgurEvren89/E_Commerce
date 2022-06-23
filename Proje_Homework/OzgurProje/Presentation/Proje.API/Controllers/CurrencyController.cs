using AutoMapper;
using Proje.API.Controllers.Base;
using Proje.Common.DTOs.Currency;
using Proje.Common.DTOs.User;
using Proje.Common.Models;
using Proje.Model.Entities;
using Proje.Service.Repository.Currency;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proje.API.Controllers
{
    [Route("currency")]
    public class CurrencyController : BaseApiController<CurrencyController>
    {
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IMapper _mapper;

        public CurrencyController(
            ICurrencyRepository currencyRepository,
            IMapper mapper)
        {
            _currencyRepository = currencyRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<CurrencyResponse>>>> GetCurrencys()
        {
            UserResponse user = WorkContext.CurrentUser;

            var currencyResult = _mapper.Map<List<CurrencyResponse>>
                (await _currencyRepository.TableNoTracking.ToListAsync());
            if (currencyResult.Count > 0)
            {
                return new WebApiResponse<List<CurrencyResponse>>(true, "Success", currencyResult);
            }
            return new WebApiResponse<List<CurrencyResponse>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<CurrencyResponse>>> GetCurrencys(Guid id)
        {
            var currencyResult = _mapper.Map<CurrencyResponse>(await _currencyRepository.GetById(id));
            if (currencyResult != null)
            {
                return new WebApiResponse<CurrencyResponse>(true, "Success", currencyResult);
            }
            return new WebApiResponse<CurrencyResponse>(false, "Error");
        }

        [HttpPost, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<CurrencyResponse>>> PostCurrency(CurrencyRequest request)
        {
            Currency entity = _mapper.Map<Currency>(request);
            var insertResult = await _currencyRepository.Add(entity);
            if (insertResult != null)
            {
                CurrencyResponse rm = _mapper.Map<CurrencyResponse>(insertResult);
                return new WebApiResponse<CurrencyResponse>(true, "Success", rm);
            }
            return new WebApiResponse<CurrencyResponse>(false, "Error");
        }

        [HttpPut("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<CurrencyResponse>>> PutCurrency(Guid id, CurrencyRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                Currency entity = await _currencyRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _currencyRepository.Update(entity);
                if (updateResult != null)
                {
                    CurrencyResponse rm = _mapper.Map<CurrencyResponse>(updateResult);
                    return new WebApiResponse<CurrencyResponse>(true, "Success", rm);
                }
                return new WebApiResponse<CurrencyResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<CurrencyResponse>>> DeleteCurrency(Guid id)
        {
            Currency entity = await _currencyRepository.GetById(id);
            if (entity != null)
            {
                if (await _currencyRepository.Remove(entity))
                    return new WebApiResponse<CurrencyResponse>
                        (true, "Success", _mapper.Map<CurrencyResponse>(entity));
                else
                    return new WebApiResponse<CurrencyResponse>(false, "Error");
            }
            return new WebApiResponse<CurrencyResponse>(false, "Error");
        }

        [HttpGet("activate/{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _currencyRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", true);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<CurrencyResponse>>>> GetActive()
        {
            var currencyResult = _mapper.Map<List<CurrencyResponse>>
                (await _currencyRepository.GetActive().ToListAsync());
            if (currencyResult.Count > 0)
            {
                return new WebApiResponse<List<CurrencyResponse>>(true, "Success", currencyResult);
            }
            return new WebApiResponse<List<CurrencyResponse>>(false, "Error");
        }

    }
}
