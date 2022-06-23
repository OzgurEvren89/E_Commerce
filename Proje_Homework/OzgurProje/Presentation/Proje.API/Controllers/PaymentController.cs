using AutoMapper;
using Proje.API.Controllers.Base;
using Proje.Common.DTOs.Payment;
using Proje.Common.DTOs.User;
using Proje.Common.Models;
using Proje.Model.Entities;
using Proje.Service.Repository.Payment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proje.API.Controllers
{
    [Route("payment")]
    public class PaymentController : BaseApiController<PaymentController>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public PaymentController(
            IPaymentRepository paymentRepository,
            IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<PaymentResponse>>>> GetPayments()
        {
            UserResponse user = WorkContext.CurrentUser;

            var paymentResult = _mapper.Map<List<PaymentResponse>>
                (await _paymentRepository.TableNoTracking.ToListAsync());
            if (paymentResult.Count > 0)
            {
                return new WebApiResponse<List<PaymentResponse>>(true, "Success", paymentResult);
            }
            return new WebApiResponse<List<PaymentResponse>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<PaymentResponse>>> GetPayments(Guid id)
        {
            var paymentResult = _mapper.Map<PaymentResponse>(await _paymentRepository.GetById(id));
            if (paymentResult != null)
            {
                return new WebApiResponse<PaymentResponse>(true, "Success", paymentResult);
            }
            return new WebApiResponse<PaymentResponse>(false, "Error");
        }

        [HttpPost, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<PaymentResponse>>> PostPayment(PaymentRequest request)
        {
            Payment entity = _mapper.Map<Payment>(request);
            var insertResult = await _paymentRepository.Add(entity);
            if (insertResult != null)
            {
                PaymentResponse rm = _mapper.Map<PaymentResponse>(insertResult);
                return new WebApiResponse<PaymentResponse>(true, "Success", rm);
            }
            return new WebApiResponse<PaymentResponse>(false, "Error");
        }

        [HttpPut("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<PaymentResponse>>> PutPayment(Guid id, PaymentRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                Payment entity = await _paymentRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _paymentRepository.Update(entity);
                if (updateResult != null)
                {
                    PaymentResponse rm = _mapper.Map<PaymentResponse>(updateResult);
                    return new WebApiResponse<PaymentResponse>(true, "Success", rm);
                }
                return new WebApiResponse<PaymentResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<PaymentResponse>>> DeletePayment(Guid id)
        {
            Payment entity = await _paymentRepository.GetById(id);
            if (entity != null)
            {
                if (await _paymentRepository.Remove(entity))
                    return new WebApiResponse<PaymentResponse>
                        (true, "Success", _mapper.Map<PaymentResponse>(entity));
                else
                    return new WebApiResponse<PaymentResponse>(false, "Error");
            }
            return new WebApiResponse<PaymentResponse>(false, "Error");
        }

        [HttpGet("activate/{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _paymentRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", true);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<PaymentResponse>>>> GetActive()
        {
            var paymentResult = _mapper.Map<List<PaymentResponse>>
                (await _paymentRepository.GetActive().ToListAsync());
            if (paymentResult.Count > 0)
            {
                return new WebApiResponse<List<PaymentResponse>>(true, "Success", paymentResult);
            }
            return new WebApiResponse<List<PaymentResponse>>(false, "Error");
        }

    }
}
