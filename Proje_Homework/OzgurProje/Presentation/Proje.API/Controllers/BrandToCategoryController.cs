using AutoMapper;
using Proje.API.Controllers.Base;
using Proje.Common.DTOs.BrandToCategory;
using Proje.Common.DTOs.User;
using Proje.Common.Models;
using Proje.Model.Entities;
using Proje.Service.Repository.BrandToCategory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proje.API.Controllers
{
    [Route("brandtocategory")]
    public class BrandToCategoryController : BaseApiController<BrandToCategoryController>
    {
        private readonly IBrandToCategoryRepository _brandtocategoryRepository;
        private readonly IMapper _mapper;

        public BrandToCategoryController(
            IBrandToCategoryRepository brandtocategoryRepository,
            IMapper mapper)
        {
            _brandtocategoryRepository = brandtocategoryRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<BrandToCategoryResponse>>>> GetBrandToCategories()
        {
            UserResponse user = WorkContext.CurrentUser;

            var brandtocategoryResult = _mapper.Map<List<BrandToCategoryResponse>>
                (await _brandtocategoryRepository.TableNoTracking.ToListAsync());
            if (brandtocategoryResult.Count > 0)
            {
                return new WebApiResponse<List<BrandToCategoryResponse>>(true, "Success", brandtocategoryResult);
            }
            return new WebApiResponse<List<BrandToCategoryResponse>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<BrandToCategoryResponse>>> GetBrandToCategories(Guid id)
        {
            var brandtocategoryResult = _mapper.Map<BrandToCategoryResponse>(await _brandtocategoryRepository.GetById(id));
            if (brandtocategoryResult != null)
            {
                return new WebApiResponse<BrandToCategoryResponse>(true, "Success", brandtocategoryResult);
            }
            return new WebApiResponse<BrandToCategoryResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<BrandToCategoryResponse>>> PostBrandToCategory(BrandToCategoryRequest request)
        {
            BrandToCategory entity = _mapper.Map<BrandToCategory>(request);
            var insertResult = await _brandtocategoryRepository.Add(entity);
            if (insertResult != null)
            {
                BrandToCategoryResponse rm = _mapper.Map<BrandToCategoryResponse>(insertResult);
                return new WebApiResponse<BrandToCategoryResponse>(true, "Success", rm);
            }
            return new WebApiResponse<BrandToCategoryResponse>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<BrandToCategoryResponse>>> PutBrandToCategory(Guid id, BrandToCategoryRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                BrandToCategory entity = await _brandtocategoryRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _brandtocategoryRepository.Update(entity);
                if (updateResult != null)
                {
                    BrandToCategoryResponse rm = _mapper.Map<BrandToCategoryResponse>(updateResult);
                    return new WebApiResponse<BrandToCategoryResponse>(true, "Success", rm);
                }
                return new WebApiResponse<BrandToCategoryResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<BrandToCategoryResponse>>> DeleteBrandToCategory(Guid id)
        {
            BrandToCategory entity = await _brandtocategoryRepository.GetById(id);
            if (entity != null)
            {
                if (await _brandtocategoryRepository.Remove(entity))
                    return new WebApiResponse<BrandToCategoryResponse>
                        (true, "Success", _mapper.Map<BrandToCategoryResponse>(entity));
                else
                    return new WebApiResponse<BrandToCategoryResponse>(false, "Error");
            }
            return new WebApiResponse<BrandToCategoryResponse>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _brandtocategoryRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", true);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<BrandToCategoryResponse>>>> GetActive()
        {
            var brandtocategoryResult = _mapper.Map<List<BrandToCategoryResponse>>
                (await _brandtocategoryRepository.GetActive().ToListAsync());
            if (brandtocategoryResult.Count > 0)
            {
                return new WebApiResponse<List<BrandToCategoryResponse>>(true, "Success", brandtocategoryResult);
            }
            return new WebApiResponse<List<BrandToCategoryResponse>>(false, "Error");
        }

    }
}
