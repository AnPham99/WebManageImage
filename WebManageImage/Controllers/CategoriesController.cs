using AutoMapper;
using Contracts;
using Entities.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebManageImage.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        /* private readonly IRepositoryManager _repository;*/
        private readonly ICategoryService _categoryService;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, ILoggerManager logger, IMapper mapper)
        {
            _categoryService = categoryService;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet (Name = "GetCategories")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync(trackChanges: false);
            var categoriesDto = _mapper.Map < IEnumerable<CategoryDto>>(categories);
            return Ok(categoriesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int Id)
        {
            var categories = await _categoryService.GetCategoryByIdAsync(Id, trackChanges: false);
            if(categories == null)
            {
                _logger.LogInfo($"Category with Id {Id} doesn't exist in the database.");
                return NotFound();
            }
            var categoriesDto = _mapper.Map<CategoryDto>(categories);
            return Ok(categoriesDto);
        }
    }
}
