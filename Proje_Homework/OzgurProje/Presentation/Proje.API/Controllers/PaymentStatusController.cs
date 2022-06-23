using AutoMapper;
using Proje.API.Controllers.Base;
using Proje.Common.DTOs.PaymentStatus;
using Proje.Common.DTOs.User;
using Proje.Common.Models;
using Proje.Model.Entities;
using Proje.Service.Repository.PaymentStatus;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proje.API.Controllers
{
    [Route("paymentstatus")]
    public class PaymentStatusController : BaseApiController<PaymentStatusController>
    {
        private readonly IPaymentStatusRepository _paymentStatusRepository;
        private readonly IMapper _mapper;

        public PaymentStatusController(
            IPaymentStatusRepository paymentStatusRepository,
            IMapper mapper)
        {
            _paymentStatusRepository = paymentStatusRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<PaymentStatusResponse>>>> GetPaymentStatuss()
        {
            UserResponse user = WorkContext.CurrentUser;

            var paymentStatusResult = _mapper.Map<List<PaymentStatusResponse>>
                (await _paymentStatusRepository.TableNoTracking.ToListAsync());
            if (paymentStatusResult.Count > 0)
            {
                return new WebApiResponse<List<PaymentStatusResponse>>(true, "Success", paymentStatusResult);
            }
            return new WebApiResponse<List<PaymentStatusResponse>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<PaymentStatusResponse>>> GetPaymentStatuss(Guid id)
        {
            var paymentStatusResult = _mapper.Map<PaymentStatusResponse>(await _paymentStatusRepository.GetById(id));
            if (paymentStatusResult != null)
            {
                return new WebApiResponse<PaymentStatusResponse>(true, "Success", paymentStatusResult);
            }
            return new WebApiResponse<PaymentStatusResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<PaymentStatusResponse>>> PostPaymentStatus(PaymentStatusRequest request)
        {
            PaymentStatus entity = _mapper.Map<PaymentStatus>(request);
            var insertResult = await _paymentStatusRepository.Add(entity);
            if (insertResult != null)
            {
                PaymentStatusResponse rm = _mapper.Map<PaymentStatusResponse>(insertResult);
                return new WebApiResponse<PaymentStatusResponse>(true, "Success", rm);
            }
            return new WebApiResponse<PaymentStatusResponse>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<PaymentStatusResponse>>> PutPaymentStatus(Guid id, PaymentStatusRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                PaymentStatus entity = await _paymentStatusRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _paymentStatusRepository.Update(entity);
                if (updateResult != null)
                {
                    PaymentStatusResponse rm = _mapper.Map<PaymentStatusResponse>(updateResult);
                    return new WebApiResponse<PaymentStatusResponse>(true, "Success", rm);
                }
                return new WebApiResponse<PaymentStatusResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<PaymentStatusResponse>>> DeletePaymentStatus(Guid id)
        {
            PaymentStatus entity = await _paymentStatusRepository.GetById(id);
            if (entity != null)
            {
                if (await _paymentStatusRepository.Remove(entity))
                    return new WebApiResponse<PaymentStatusResponse>
                        (true, "Success", _mapper.Map<PaymentStatusResponse>(entity));
                else
                    return new WebApiResponse<PaymentStatusResponse>(false, "Error");
            }
            return new WebApiResponse<PaymentStatusResponse>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _paymentStatusRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", true);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<PaymentStatusResponse>>>> GetActive()
        {
            var paymentStatusResult = _mapper.Map<List<PaymentStatusResponse>>
                (await _paymentStatusRepository.GetActive().ToListAsync());
            if (paymentStatusResult.Count > 0)
            {
                return new WebApiResponse<List<PaymentStatusResponse>>(true, "Success", paymentStatusResult);
            }
            return new WebApiResponse<List<PaymentStatusResponse>>(false, "Error");
        }

    }
}
