using AutoMapper;
using Proje.API.Controllers.Base;
using Proje.Common.DTOs.PaymentType;
using Proje.Common.DTOs.User;
using Proje.Common.Models;
using Proje.Model.Entities;
using Proje.Service.Repository.PaymentType;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proje.API.Controllers
{
    [Route("paymenttype")]
    public class PaymentTypeController : BaseApiController<PaymentTypeController>
    {
        private readonly IPaymentTypeRepository _paymentTypeRepository;
        private readonly IMapper _mapper;

        public PaymentTypeController(
            IPaymentTypeRepository paymentTypeRepository,
            IMapper mapper)
        {
            _paymentTypeRepository = paymentTypeRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<PaymentTypeResponse>>>> GetPaymentTypes()
        {
            UserResponse user = WorkContext.CurrentUser;

            var paymentTypeResult = _mapper.Map<List<PaymentTypeResponse>>
                (await _paymentTypeRepository.TableNoTracking.ToListAsync());
            if (paymentTypeResult.Count > 0)
            {
                return new WebApiResponse<List<PaymentTypeResponse>>(true, "Success", paymentTypeResult);
            }
            return new WebApiResponse<List<PaymentTypeResponse>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<PaymentTypeResponse>>> GetPaymentTypes(Guid id)
        {
            var paymentTypeResult = _mapper.Map<PaymentTypeResponse>(await _paymentTypeRepository.GetById(id));
            if (paymentTypeResult != null)
            {
                return new WebApiResponse<PaymentTypeResponse>(true, "Success", paymentTypeResult);
            }
            return new WebApiResponse<PaymentTypeResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<PaymentTypeResponse>>> PostPaymentType(PaymentTypeRequest request)
        {
            PaymentType entity = _mapper.Map<PaymentType>(request);
            var insertResult = await _paymentTypeRepository.Add(entity);
            if (insertResult != null)
            {
                PaymentTypeResponse rm = _mapper.Map<PaymentTypeResponse>(insertResult);
                return new WebApiResponse<PaymentTypeResponse>(true, "Success", rm);
            }
            return new WebApiResponse<PaymentTypeResponse>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<PaymentTypeResponse>>> PutPaymentType(Guid id, PaymentTypeRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                PaymentType entity = await _paymentTypeRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _paymentTypeRepository.Update(entity);
                if (updateResult != null)
                {
                    PaymentTypeResponse rm = _mapper.Map<PaymentTypeResponse>(updateResult);
                    return new WebApiResponse<PaymentTypeResponse>(true, "Success", rm);
                }
                return new WebApiResponse<PaymentTypeResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<PaymentTypeResponse>>> DeletePaymentType(Guid id)
        {
            PaymentType entity = await _paymentTypeRepository.GetById(id);
            if (entity != null)
            {
                if (await _paymentTypeRepository.Remove(entity))
                    return new WebApiResponse<PaymentTypeResponse>
                        (true, "Success", _mapper.Map<PaymentTypeResponse>(entity));
                else
                    return new WebApiResponse<PaymentTypeResponse>(false, "Error");
            }
            return new WebApiResponse<PaymentTypeResponse>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _paymentTypeRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", true);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<PaymentTypeResponse>>>> GetActive()
        {
            var paymentTypeResult = _mapper.Map<List<PaymentTypeResponse>>
                (await _paymentTypeRepository.GetActive().ToListAsync());
            if (paymentTypeResult.Count > 0)
            {
                return new WebApiResponse<List<PaymentTypeResponse>>(true, "Success", paymentTypeResult);
            }
            return new WebApiResponse<List<PaymentTypeResponse>>(false, "Error");
        }

    }
}
