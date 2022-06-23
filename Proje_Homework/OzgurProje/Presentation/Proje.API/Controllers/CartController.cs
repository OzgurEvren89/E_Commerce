using AutoMapper;
using Proje.API.Controllers.Base;
using Proje.Common.DTOs.Cart;
using Proje.Common.DTOs.User;
using Proje.Common.Models;
using Proje.Model.Entities;
using Proje.Service.Repository.Cart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proje.API.Controllers
{
    [Route("cart")]
    public class CartController : BaseApiController<CartController>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public CartController(
            ICartRepository cartRepository,
            IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<CartResponse>>>> GetCarts()
        {
            UserResponse user = WorkContext.CurrentUser;

            var cartResult = _mapper.Map<List<CartResponse>>
                (await _cartRepository.TableNoTracking.ToListAsync());
            if (cartResult.Count > 0)
            {
                return new WebApiResponse<List<CartResponse>>(true, "Success", cartResult);
            }
            return new WebApiResponse<List<CartResponse>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<CartResponse>>> GetCarts(Guid id)
        {
            var cartResult = _mapper.Map<CartResponse>(await _cartRepository.GetById(id));
            if (cartResult != null)
            {
                return new WebApiResponse<CartResponse>(true, "Success", cartResult);
            }
            return new WebApiResponse<CartResponse>(false, "Error");
        }

        [HttpPost, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<CartResponse>>> PostCart(CartRequest request)
        {
            Cart entity = _mapper.Map<Cart>(request);
            var insertResult = await _cartRepository.Add(entity);
            if (insertResult != null)
            {
                CartResponse rm = _mapper.Map<CartResponse>(insertResult);
                return new WebApiResponse<CartResponse>(true, "Success", rm);
            }
            return new WebApiResponse<CartResponse>(false, "Error");
        }

        [HttpPut("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<CartResponse>>> PutCart(Guid id, CartRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                Cart entity = await _cartRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _cartRepository.Update(entity);
                if (updateResult != null)
                {
                    CartResponse rm = _mapper.Map<CartResponse>(updateResult);
                    return new WebApiResponse<CartResponse>(true, "Success", rm);
                }
                return new WebApiResponse<CartResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<CartResponse>>> DeleteCart(Guid id)
        {
            Cart entity = await _cartRepository.GetById(id);
            if (entity != null)
            {
                if (await _cartRepository.Remove(entity))
                    return new WebApiResponse<CartResponse>
                        (true, "Success", _mapper.Map<CartResponse>(entity));
                else
                    return new WebApiResponse<CartResponse>(false, "Error");
            }
            return new WebApiResponse<CartResponse>(false, "Error");
        }

        [HttpGet("activate/{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _cartRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", true);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<CartResponse>>>> GetActive()
        {
            var cartResult = _mapper.Map<List<CartResponse>>
                (await _cartRepository.GetActive().ToListAsync());
            if (cartResult.Count > 0)
            {
                return new WebApiResponse<List<CartResponse>>(true, "Success", cartResult);
            }
            return new WebApiResponse<List<CartResponse>>(false, "Error");
        }

        
    }
}
