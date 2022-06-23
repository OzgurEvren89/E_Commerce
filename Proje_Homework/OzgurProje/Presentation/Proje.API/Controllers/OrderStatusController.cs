using AutoMapper;
using Proje.API.Controllers.Base;
using Proje.Common.DTOs.OrderStatus;
using Proje.Common.DTOs.User;
using Proje.Common.Models;
using Proje.Model.Entities;
using Proje.Service.Repository.OrderStatus;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proje.API.Controllers
{
    [Route("orderstatus")]
    public class OrderStatusController : BaseApiController<OrderStatusController>
    {
        private readonly IOrderStatusRepository _orderStatusRepository;
        private readonly IMapper _mapper;

        public OrderStatusController(
            IOrderStatusRepository orderStatusRepository,
            IMapper mapper)
        {
            _orderStatusRepository = orderStatusRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<OrderStatusResponse>>>> GetOrderStatuss()
        {
            UserResponse user = WorkContext.CurrentUser;

            var orderStatusResult = _mapper.Map<List<OrderStatusResponse>>
                (await _orderStatusRepository.TableNoTracking.ToListAsync());
            if (orderStatusResult.Count > 0)
            {
                return new WebApiResponse<List<OrderStatusResponse>>(true, "Success", orderStatusResult);
            }
            return new WebApiResponse<List<OrderStatusResponse>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<OrderStatusResponse>>> GetOrderStatuss(Guid id)
        {
            var orderStatusResult = _mapper.Map<OrderStatusResponse>(await _orderStatusRepository.GetById(id));
            if (orderStatusResult != null)
            {
                return new WebApiResponse<OrderStatusResponse>(true, "Success", orderStatusResult);
            }
            return new WebApiResponse<OrderStatusResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<OrderStatusResponse>>> PostOrderStatus(OrderStatusRequest request)
        {
            OrderStatus entity = _mapper.Map<OrderStatus>(request);
            var insertResult = await _orderStatusRepository.Add(entity);
            if (insertResult != null)
            {
                OrderStatusResponse rm = _mapper.Map<OrderStatusResponse>(insertResult);
                return new WebApiResponse<OrderStatusResponse>(true, "Success", rm);
            }
            return new WebApiResponse<OrderStatusResponse>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<OrderStatusResponse>>> PutOrderStatus(Guid id, OrderStatusRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                OrderStatus entity = await _orderStatusRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _orderStatusRepository.Update(entity);
                if (updateResult != null)
                {
                    OrderStatusResponse rm = _mapper.Map<OrderStatusResponse>(updateResult);
                    return new WebApiResponse<OrderStatusResponse>(true, "Success", rm);
                }
                return new WebApiResponse<OrderStatusResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<OrderStatusResponse>>> DeleteOrderStatus(Guid id)
        {
            OrderStatus entity = await _orderStatusRepository.GetById(id);
            if (entity != null)
            {
                if (await _orderStatusRepository.Remove(entity))
                    return new WebApiResponse<OrderStatusResponse>
                        (true, "Success", _mapper.Map<OrderStatusResponse>(entity));
                else
                    return new WebApiResponse<OrderStatusResponse>(false, "Error");
            }
            return new WebApiResponse<OrderStatusResponse>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _orderStatusRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", true);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<OrderStatusResponse>>>> GetActive()
        {
            var orderStatusResult = _mapper.Map<List<OrderStatusResponse>>
                (await _orderStatusRepository.GetActive().ToListAsync());
            if (orderStatusResult.Count > 0)
            {
                return new WebApiResponse<List<OrderStatusResponse>>(true, "Success", orderStatusResult);
            }
            return new WebApiResponse<List<OrderStatusResponse>>(false, "Error");
        }

    }
}
