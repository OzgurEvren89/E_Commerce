using AutoMapper;
using Proje.API.Controllers.Base;
using Proje.Common.DTOs.Brand;
using Proje.Common.DTOs.User;
using Proje.Common.Models;
using Proje.Model.Entities;
using Proje.Service.Repository.Brand;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proje.API.Controllers
{
    [Route("brand")]
    public class BrandController : BaseApiController<BrandController>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public BrandController(
            IBrandRepository brandRepository,
            IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<BrandResponse>>>> GetBrands()
        {
            UserResponse user = WorkContext.CurrentUser;

            var brandResult = _mapper.Map<List<BrandResponse>>
                (await _brandRepository.TableNoTracking.ToListAsync());
            if (brandResult.Count > 0)
            {
                return new WebApiResponse<List<BrandResponse>>(true, "Success", brandResult);
            }
            return new WebApiResponse<List<BrandResponse>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<BrandResponse>>> GetBrands(Guid id)
        {
            var brandResult = _mapper.Map<BrandResponse>(await _brandRepository.GetById(id));
            if (brandResult != null)
            {
                return new WebApiResponse<BrandResponse>(true, "Success", brandResult);
            }
            return new WebApiResponse<BrandResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<BrandResponse>>> PostBrand(BrandRequest request)
        {
            Brand entity = _mapper.Map<Brand>(request);
            var insertResult = await _brandRepository.Add(entity);
            if (insertResult != null)
            {
                BrandResponse rm = _mapper.Map<BrandResponse>(insertResult);
                return new WebApiResponse<BrandResponse>(true, "Success", rm);
            }
            return new WebApiResponse<BrandResponse>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<BrandResponse>>> PutBrand(Guid id, BrandRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                Brand entity = await _brandRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _brandRepository.Update(entity);
                if (updateResult != null)
                {
                    BrandResponse rm = _mapper.Map<BrandResponse>(updateResult);
                    return new WebApiResponse<BrandResponse>(true, "Success", rm);
                }
                return new WebApiResponse<BrandResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<BrandResponse>>> DeleteBrand(Guid id)
        {
            Brand entity = await _brandRepository.GetById(id);
            if (entity != null)
            {
                if (await _brandRepository.Remove(entity))
                    return new WebApiResponse<BrandResponse>
                        (true, "Success", _mapper.Map<BrandResponse>(entity));
                else
                    return new WebApiResponse<BrandResponse>(false, "Error");
            }
            return new WebApiResponse<BrandResponse>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _brandRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", true);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<BrandResponse>>>> GetActive()
        {
            var brandResult = _mapper.Map<List<BrandResponse>>
                (await _brandRepository.GetActive().ToListAsync());
            if (brandResult.Count > 0)
            {
                return new WebApiResponse<List<BrandResponse>>(true, "Success", brandResult);
            }
            return new WebApiResponse<List<BrandResponse>>(false, "Error");
        }

    }
}
