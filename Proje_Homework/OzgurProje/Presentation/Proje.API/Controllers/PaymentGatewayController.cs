using AutoMapper;
using Proje.API.Controllers.Base;
using Proje.Common.DTOs.PaymentGateway;
using Proje.Common.DTOs.User;
using Proje.Common.Models;
using Proje.Model.Entities;
using Proje.Service.Repository.PaymentGateway;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proje.API.Controllers
{
    [Route("paymentgateway")]
    public class PaymentGatewayController : BaseApiController<PaymentGatewayController>
    {
        private readonly IPaymentGatewayRepository _paymentGatewayRepository;
        private readonly IMapper _mapper;

        public PaymentGatewayController(
            IPaymentGatewayRepository paymentGatewayRepository,
            IMapper mapper)
        {
            _paymentGatewayRepository = paymentGatewayRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<PaymentGatewayResponse>>>> GetPaymentGateways()
        {
            UserResponse user = WorkContext.CurrentUser;

            var paymentGatewayResult = _mapper.Map<List<PaymentGatewayResponse>>
                (await _paymentGatewayRepository.TableNoTracking.ToListAsync());
            if (paymentGatewayResult.Count > 0)
            {
                return new WebApiResponse<List<PaymentGatewayResponse>>(true, "Success", paymentGatewayResult);
            }
            return new WebApiResponse<List<PaymentGatewayResponse>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<PaymentGatewayResponse>>> GetPaymentGateways(Guid id)
        {
            var paymentGatewayResult = _mapper.Map<PaymentGatewayResponse>(await _paymentGatewayRepository.GetById(id));
            if (paymentGatewayResult != null)
            {
                return new WebApiResponse<PaymentGatewayResponse>(true, "Success", paymentGatewayResult);
            }
            return new WebApiResponse<PaymentGatewayResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<PaymentGatewayResponse>>> PostPaymentGateway(PaymentGatewayRequest request)
        {
            PaymentGateway entity = _mapper.Map<PaymentGateway>(request);
            var insertResult = await _paymentGatewayRepository.Add(entity);
            if (insertResult != null)
            {
                PaymentGatewayResponse rm = _mapper.Map<PaymentGatewayResponse>(insertResult);
                return new WebApiResponse<PaymentGatewayResponse>(true, "Success", rm);
            }
            return new WebApiResponse<PaymentGatewayResponse>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<PaymentGatewayResponse>>> PutPaymentGateway(Guid id, PaymentGatewayRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                PaymentGateway entity = await _paymentGatewayRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _paymentGatewayRepository.Update(entity);
                if (updateResult != null)
                {
                    PaymentGatewayResponse rm = _mapper.Map<PaymentGatewayResponse>(updateResult);
                    return new WebApiResponse<PaymentGatewayResponse>(true, "Success", rm);
                }
                return new WebApiResponse<PaymentGatewayResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<PaymentGatewayResponse>>> DeletePaymentGateway(Guid id)
        {
            PaymentGateway entity = await _paymentGatewayRepository.GetById(id);
            if (entity != null)
            {
                if (await _paymentGatewayRepository.Remove(entity))
                    return new WebApiResponse<PaymentGatewayResponse>
                        (true, "Success", _mapper.Map<PaymentGatewayResponse>(entity));
                else
                    return new WebApiResponse<PaymentGatewayResponse>(false, "Error");
            }
            return new WebApiResponse<PaymentGatewayResponse>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _paymentGatewayRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", true);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<PaymentGatewayResponse>>>> GetActive()
        {
            var paymentGatewayResult = _mapper.Map<List<PaymentGatewayResponse>>
                (await _paymentGatewayRepository.GetActive().ToListAsync());
            if (paymentGatewayResult.Count > 0)
            {
                return new WebApiResponse<List<PaymentGatewayResponse>>(true, "Success", paymentGatewayResult);
            }
            return new WebApiResponse<List<PaymentGatewayResponse>>(false, "Error");
        }

    }
}
