using AutoMapper;
using Proje.API.Controllers.Base;
using Proje.Common.DTOs.OrderRefundDemand;
using Proje.Common.DTOs.User;
using Proje.Common.Models;
using Proje.Model.Entities;
using Proje.Service.Repository.OrderRefundDemand;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proje.API.Controllers
{
    [Route("orderrefunddemand")]
    public class OrderRefundDemandController : BaseApiController<OrderRefundDemandController>
    {
        private readonly IOrderRefundDemandRepository _orderRefundDemandRepository;
        private readonly IMapper _mapper;

        public OrderRefundDemandController(
            IOrderRefundDemandRepository orderRefundDemandRepository,
            IMapper mapper)
        {
            _orderRefundDemandRepository = orderRefundDemandRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<OrderRefundDemandResponse>>>> GetOrderRefundDemands()
        {
            UserResponse user = WorkContext.CurrentUser;

            var orderRefundDemandResult = _mapper.Map<List<OrderRefundDemandResponse>>
                (await _orderRefundDemandRepository.TableNoTracking.ToListAsync());
            if (orderRefundDemandResult.Count > 0)
            {
                return new WebApiResponse<List<OrderRefundDemandResponse>>(true, "Success", orderRefundDemandResult);
            }
            return new WebApiResponse<List<OrderRefundDemandResponse>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<OrderRefundDemandResponse>>> GetOrderRefundDemands(Guid id)
        {
            var orderRefundDemandResult = _mapper.Map<OrderRefundDemandResponse>(await _orderRefundDemandRepository.GetById(id));
            if (orderRefundDemandResult != null)
            {
                return new WebApiResponse<OrderRefundDemandResponse>(true, "Success", orderRefundDemandResult);
            }
            return new WebApiResponse<OrderRefundDemandResponse>(false, "Error");
        }

        [HttpPost, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<OrderRefundDemandResponse>>> PostOrderRefundDemand(OrderRefundDemandRequest request)
        {
            OrderRefundDemand entity = _mapper.Map<OrderRefundDemand>(request);
            var insertResult = await _orderRefundDemandRepository.Add(entity);
            if (insertResult != null)
            {
                OrderRefundDemandResponse rm = _mapper.Map<OrderRefundDemandResponse>(insertResult);
                return new WebApiResponse<OrderRefundDemandResponse>(true, "Success", rm);
            }
            return new WebApiResponse<OrderRefundDemandResponse>(false, "Error");
        }

        [HttpPut("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<OrderRefundDemandResponse>>> PutOrderRefundDemand(Guid id, OrderRefundDemandRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                OrderRefundDemand entity = await _orderRefundDemandRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _orderRefundDemandRepository.Update(entity);
                if (updateResult != null)
                {
                    OrderRefundDemandResponse rm = _mapper.Map<OrderRefundDemandResponse>(updateResult);
                    return new WebApiResponse<OrderRefundDemandResponse>(true, "Success", rm);
                }
                return new WebApiResponse<OrderRefundDemandResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<OrderRefundDemandResponse>>> DeleteOrderRefundDemand(Guid id)
        {
            OrderRefundDemand entity = await _orderRefundDemandRepository.GetById(id);
            if (entity != null)
            {
                if (await _orderRefundDemandRepository.Remove(entity))
                    return new WebApiResponse<OrderRefundDemandResponse>
                        (true, "Success", _mapper.Map<OrderRefundDemandResponse>(entity));
                else
                    return new WebApiResponse<OrderRefundDemandResponse>(false, "Error");
            }
            return new WebApiResponse<OrderRefundDemandResponse>(false, "Error");
        }

        [HttpGet("activate/{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _orderRefundDemandRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", true);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<OrderRefundDemandResponse>>>> GetActive()
        {
            var orderRefundDemandResult = _mapper.Map<List<OrderRefundDemandResponse>>
                (await _orderRefundDemandRepository.GetActive().ToListAsync());
            if (orderRefundDemandResult.Count > 0)
            {
                return new WebApiResponse<List<OrderRefundDemandResponse>>(true, "Success", orderRefundDemandResult);
            }
            return new WebApiResponse<List<OrderRefundDemandResponse>>(false, "Error");
        }

    }
}
