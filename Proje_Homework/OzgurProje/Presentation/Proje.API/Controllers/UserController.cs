using AutoMapper;
using Proje.API.Controllers.Base;
using Proje.Common.DTOs.User;
using Proje.Common.Models;
using Proje.Model.Entities;
using Proje.Service.Repository.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proje.API.Controllers
{
    [Route("user")]
    public class UserController : BaseApiController<UserController>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(
            IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<UserResponse>>>> GetUsers()
        {
            UserResponse user = WorkContext.CurrentUser;

            var userResult = _mapper.Map<List<UserResponse>>
                (await _userRepository.TableNoTracking.ToListAsync());
            if (userResult.Count > 0)
            {
                return new WebApiResponse<List<UserResponse>>(true, "Success", userResult);
            }
            return new WebApiResponse<List<UserResponse>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<UserResponse>>> GetUser(Guid id)
        {
            var userResult = _mapper.Map<UserResponse>(await _userRepository.GetById(id));
            if (userResult != null)
            {
                return new WebApiResponse<UserResponse>(true, "Success", userResult);
            }
            return new WebApiResponse<UserResponse>(false, "Error");
        }

        [HttpPost, AllowAnonymous]//dışarıdan bir kullanıcının kaydolamsı için e ticaret sitesine izin veriyorum. 
        public async Task<ActionResult<WebApiResponse<UserResponse>>> PostUser(UserRequest request)
        {
            if (request.Title==null)
            {
                request.Title = "Normal";
            }
            User entity = _mapper.Map<User>(request);
            var insertResult = await _userRepository.Add(entity);
            if (insertResult != null)
            {
                UserResponse rm = _mapper.Map<UserResponse>(insertResult);
                return new WebApiResponse<UserResponse>(true, "Success", rm);
            }
            return new WebApiResponse<UserResponse>(false, "Error");
        }

        [HttpPut("{id}"), AllowAnonymous]//e ticaret sitesinde,dışarıdan bir kullanıcının verilerini düzelmesi için izin veriyorum.
        public async Task<ActionResult<WebApiResponse<UserResponse>>> PutUser(Guid id, UserRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                User entity = await _userRepository.GetById(id);
                if (entity == null)
                    return NotFound();
               
                _mapper.Map(request, entity);

                var updateResult = await _userRepository.Update(entity);
                if (updateResult != null)
                {
                    UserResponse rm = _mapper.Map<UserResponse>(updateResult);
                    return new WebApiResponse<UserResponse>(true, "Success", rm);
                }
                return new WebApiResponse<UserResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}"), AllowAnonymous]//kullanıcının kendi hesabını kapatabilmesi için yetki verdim.
        public async Task<ActionResult<WebApiResponse<UserResponse>>> DeleteUser(Guid id)
        {
            User entity = await _userRepository.GetById(id);
            if (entity != null)
            {
                if (await _userRepository.Remove(entity))
                    return new WebApiResponse<UserResponse>
                        (true, "Success", _mapper.Map<UserResponse>(entity));
                else
                    return new WebApiResponse<UserResponse>(false, "Error");
            }
            return new WebApiResponse<UserResponse>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _userRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", true);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive")]
        public async Task<ActionResult<WebApiResponse<List<UserResponse>>>> GetActive()
        {
            var userResult = _mapper.Map<List<UserResponse>>
                (await _userRepository.GetActive().ToListAsync());
            if (userResult.Count > 0)
            {
                return new WebApiResponse<List<UserResponse>>(true, "Success", userResult);
            }
            return new WebApiResponse<List<UserResponse>>(false, "Error");
        }

        [HttpGet("getcartuser"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<UserResponse>>> GetCartUser()
        {
            
            UserResponse userResult = WorkContext.CurrentUser;


            var userResult2 = _mapper.Map<List<UserResponse>>
               (await _userRepository.GetActive().ToListAsync());

            if (userResult != null)
            {
               return   new WebApiResponse<UserResponse>(true, "Success", userResult);
            }
            return new WebApiResponse<UserResponse>(false, "Error");
        }
    }
}
