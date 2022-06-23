using AutoMapper;
using Proje.API.Controllers.Base;
using Proje.Common.DTOs.Order;
using Proje.Common.DTOs.User;
using Proje.Common.Models;
using Proje.Model.Entities;
using Proje.Service.Repository.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proje.API.Controllers
{
    [Route("order")]
    public class OrderController : BaseApiController<OrderController>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderController(
            IOrderRepository orderRepository,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<OrderResponse>>>> GetOrders()
        {
           

            var orderResult = _mapper.Map<List<OrderResponse>>
                (await _orderRepository.TableNoTracking.ToListAsync());
            if (orderResult.Count > 0)
            {
                return new WebApiResponse<List<OrderResponse>>(true, "Success", orderResult);
            }
            return new WebApiResponse<List<OrderResponse>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<OrderResponse>>> GetOrders(Guid id)
        {
            var orderResult = _mapper.Map<OrderResponse>(await _orderRepository.GetById(id));
            if (orderResult != null)
            {
                return new WebApiResponse<OrderResponse>(true, "Success", orderResult);
            }
            return new WebApiResponse<OrderResponse>(false, "Error");
        }

        [HttpPost, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<OrderResponse>>> PostOrder(OrderRequest request)
        {
            Order entity = _mapper.Map<Order>(request);
            var insertResult = await _orderRepository.Add(entity);
            if (insertResult != null)
            {
                OrderResponse rm = _mapper.Map<OrderResponse>(insertResult);
                return new WebApiResponse<OrderResponse>(true, "Success", rm);
            }
            return new WebApiResponse<OrderResponse>(false, "Error");
        }

        [HttpPut("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<OrderResponse>>> PutOrder(Guid id, OrderRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                Order entity = await _orderRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _orderRepository.Update(entity);
                if (updateResult != null)
                {
                    OrderResponse rm = _mapper.Map<OrderResponse>(updateResult);
                    return new WebApiResponse<OrderResponse>(true, "Success", rm);
                }
                return new WebApiResponse<OrderResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<OrderResponse>>> DeleteOrder(Guid id)
        {
            Order entity = await _orderRepository.GetById(id);
            if (entity != null)
            {
                if (await _orderRepository.Remove(entity))
                    return new WebApiResponse<OrderResponse>
                        (true, "Success", _mapper.Map<OrderResponse>(entity));
                else
                    return new WebApiResponse<OrderResponse>(false, "Error");
            }
            return new WebApiResponse<OrderResponse>(false, "Error");
        }

        [HttpGet("activate/{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _orderRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", true);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<OrderResponse>>>> GetActive()
        {
            var orderResult = _mapper.Map<List<OrderResponse>>
                (await _orderRepository.GetActive().ToListAsync());
            if (orderResult.Count > 0)
            {
                return new WebApiResponse<List<OrderResponse>>(true, "Success", orderResult);
            }
            return new WebApiResponse<List<OrderResponse>>(false, "Error");
        }

    }
}
