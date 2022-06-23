using AutoMapper;
using Proje.API.Controllers.Base;
using Proje.Common.DTOs.OrderItem;
using Proje.Common.DTOs.User;
using Proje.Common.Models;
using Proje.Model.Entities;
using Proje.Service.Repository.OrderItem;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proje.API.Controllers
{
    [Route("orderitem")]
    public class OrderItemController : BaseApiController<OrderItemController>
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMapper _mapper;

        public OrderItemController(
            IOrderItemRepository orderItemRepository,
            IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<OrderItemResponse>>>> GetOrderItems()
        {
            UserResponse user = WorkContext.CurrentUser;

            var orderItemResult = _mapper.Map<List<OrderItemResponse>>
                (await _orderItemRepository.TableNoTracking.ToListAsync());
            if (orderItemResult.Count > 0)
            {
                return new WebApiResponse<List<OrderItemResponse>>(true, "Success", orderItemResult);
            }
            return new WebApiResponse<List<OrderItemResponse>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<OrderItemResponse>>> GetOrderItems(Guid id)
        {
            var orderItemResult = _mapper.Map<OrderItemResponse>(await _orderItemRepository.GetById(id));
            if (orderItemResult != null)
            {
                return new WebApiResponse<OrderItemResponse>(true, "Success", orderItemResult);
            }
            return new WebApiResponse<OrderItemResponse>(false, "Error");
        }

        [HttpPost, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<OrderItemResponse>>> PostOrderItem(OrderItemRequest request)
        {
            OrderItem entity = _mapper.Map<OrderItem>(request);
            var insertResult = await _orderItemRepository.Add(entity);
            if (insertResult != null)
            {
                OrderItemResponse rm = _mapper.Map<OrderItemResponse>(insertResult);
                return new WebApiResponse<OrderItemResponse>(true, "Success", rm);
            }
            return new WebApiResponse<OrderItemResponse>(false, "Error");
        }

        [HttpPut("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<OrderItemResponse>>> PutOrderItem(Guid id, OrderItemRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                OrderItem entity = await _orderItemRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _orderItemRepository.Update(entity);
                if (updateResult != null)
                {
                    OrderItemResponse rm = _mapper.Map<OrderItemResponse>(updateResult);
                    return new WebApiResponse<OrderItemResponse>(true, "Success", rm);
                }
                return new WebApiResponse<OrderItemResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<OrderItemResponse>>> DeleteOrderItem(Guid id)
        {
            OrderItem entity = await _orderItemRepository.GetById(id);
            if (entity != null)
            {
                if (await _orderItemRepository.Remove(entity))
                    return new WebApiResponse<OrderItemResponse>
                        (true, "Success", _mapper.Map<OrderItemResponse>(entity));
                else
                    return new WebApiResponse<OrderItemResponse>(false, "Error");
            }
            return new WebApiResponse<OrderItemResponse>(false, "Error");
        }

        [HttpGet("activate/{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _orderItemRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", true);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<OrderItemResponse>>>> GetActive()
        {
            var orderItemResult = _mapper.Map<List<OrderItemResponse>>
                (await _orderItemRepository.GetActive().ToListAsync());
            if (orderItemResult.Count > 0)
            {
                return new WebApiResponse<List<OrderItemResponse>>(true, "Success", orderItemResult);
            }
            return new WebApiResponse<List<OrderItemResponse>>(false, "Error");
        }

    }
}
