using AutoMapper;
using Proje.API.Controllers.Base;
using Proje.Common.DTOs.CartItem;
using Proje.Common.DTOs.User;
using Proje.Common.Models;
using Proje.Model.Entities;
using Proje.Service.Repository.CartItem;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Proje.API.Controllers
{
    [Route("cartitem")]
    public class CartItemController : BaseApiController<CartItemController>
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IMapper _mapper;

        public CartItemController(
            ICartItemRepository cartItemRepository,
            IMapper mapper)
        {
            _cartItemRepository = cartItemRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<CartItemResponse>>>> GetCartItems()
        {
            UserResponse user = WorkContext.CurrentUser;

            var cartItemResult = _mapper.Map<List<CartItemResponse>>
                (await _cartItemRepository.TableNoTracking.ToListAsync());
            if (cartItemResult.Count > 0)
            {
                return new WebApiResponse<List<CartItemResponse>>(true, "Success", cartItemResult);
            }
            return new WebApiResponse<List<CartItemResponse>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<CartItemResponse>>> GetCartItems(Guid id)
        {
            var cartItemResult = _mapper.Map<CartItemResponse>(await _cartItemRepository.GetById(id));
            if (cartItemResult != null)
            {
                return new WebApiResponse<CartItemResponse>(true, "Success", cartItemResult);
            }
            return new WebApiResponse<CartItemResponse>(false, "Error");
        }

        [HttpPost, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<CartItemResponse>>> PostCartItem(CartItemRequest request)
        {
            CartItem entity = _mapper.Map<CartItem>(request);
            var insertResult = await _cartItemRepository.Add(entity);
            if (insertResult != null)
            {
                CartItemResponse rm = _mapper.Map<CartItemResponse>(insertResult);
                return new WebApiResponse<CartItemResponse>(true, "Success", rm);
            }
            return new WebApiResponse<CartItemResponse>(false, "Error");
        }

        [HttpPut("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<CartItemResponse>>> PutCartItem(Guid id, CartItemRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                CartItem entity = await _cartItemRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _cartItemRepository.Update(entity);
                if (updateResult != null)
                {
                    CartItemResponse rm = _mapper.Map<CartItemResponse>(updateResult);
                    return new WebApiResponse<CartItemResponse>(true, "Success", rm);
                }
                return new WebApiResponse<CartItemResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<CartItemResponse>>> DeleteCartItem(Guid id)
        {
            CartItem entity = await _cartItemRepository.GetById(id);
            if (entity != null)
            {
                if (await _cartItemRepository.Remove(entity))
                    return new WebApiResponse<CartItemResponse>
                        (true, "Success", _mapper.Map<CartItemResponse>(entity));
                else
                    return new WebApiResponse<CartItemResponse>(false, "Error");
            }
            return new WebApiResponse<CartItemResponse>(false, "Error");
        }

        [HttpGet("activate/{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _cartItemRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", true);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<CartItemResponse>>>> GetActive()
        {
            var cartItemResult = _mapper.Map<List<CartItemResponse>>
                (await _cartItemRepository.GetActive().ToListAsync());
            if (cartItemResult.Count > 0)
            {
                return new WebApiResponse<List<CartItemResponse>>(true, "Success", cartItemResult);
            }
            return new WebApiResponse<List<CartItemResponse>>(false, "Error");
        }

    }
}
