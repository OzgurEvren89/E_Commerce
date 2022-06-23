using AutoMapper;
using Proje.API.Controllers.Base;
using Proje.Common.DTOs.Category;
using Proje.Common.DTOs.User;
using Proje.Common.Models;
using Proje.Model.Entities;
using Proje.Service.Repository.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proje.API.Controllers
{
    [Route("category")]
    public class CategoryController : BaseApiController<CategoryController>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<CategoryResponse>>>> GetCategories()
        {
            UserResponse user = WorkContext.CurrentUser;
            
            var categoryResult = _mapper.Map<List<CategoryResponse>>
                (await _categoryRepository.TableNoTracking.ToListAsync());
            if (categoryResult.Count > 0)
            {
                return new WebApiResponse<List<CategoryResponse>>(true, "Success", categoryResult);
            }
            return new WebApiResponse<List<CategoryResponse>>(false, "Error");
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<CategoryResponse>>> GetCategory(Guid id)
        {
            var categoryResult = _mapper.Map<CategoryResponse>(await _categoryRepository.GetById(id));
            if (categoryResult != null)
            {
                return new WebApiResponse<CategoryResponse>(true, "Success", categoryResult);
            }
            return new WebApiResponse<CategoryResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<CategoryResponse>>> PostCategory(CategoryRequest request)
        {
            Category entity = _mapper.Map<Category>(request);
            var insertResult = await _categoryRepository.Add(entity);
            if (insertResult != null)
            {
                CategoryResponse rm = _mapper.Map<CategoryResponse>(insertResult);
                return new WebApiResponse<CategoryResponse>(true, "Success", rm);
            }
            return new WebApiResponse<CategoryResponse>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<CategoryResponse>>> PutCategory(Guid id, CategoryRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                Category entity = await _categoryRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _categoryRepository.Update(entity);
                if (updateResult != null)
                {
                    CategoryResponse rm = _mapper.Map<CategoryResponse>(updateResult);
                    return new WebApiResponse<CategoryResponse>(true, "Success", rm);
                }
                return new WebApiResponse<CategoryResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<CategoryResponse>>> DeleteCategory(Guid id)
        {
            Category entity = await _categoryRepository.GetById(id);
            if (entity != null)
            {
                if (await _categoryRepository.Remove(entity))
                    return new WebApiResponse<CategoryResponse>
                        (true, "Success", _mapper.Map<CategoryResponse>(entity));
                else
                    return new WebApiResponse<CategoryResponse>(false, "Error");
            }
            return new WebApiResponse<CategoryResponse>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _categoryRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", true);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive"), AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<CategoryResponse>>>> GetActive()
        {
            var categoryResult = _mapper.Map<List<CategoryResponse>>
                (await _categoryRepository.GetActive().ToListAsync());
            if (categoryResult.Count > 0)
            {
                return new WebApiResponse<List<CategoryResponse>>(true, "Success", categoryResult);
            }
            return new WebApiResponse<List<CategoryResponse>>(false, "Error");
        }

    }
}
