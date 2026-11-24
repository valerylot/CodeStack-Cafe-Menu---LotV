using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _services;
        public CategoryController(ICategoryServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryResponseDto>>> GetAll()
        {
            return Ok(await _services.GetAllAsync());
        }

        [HttpGet("getbyid/{id}")]
        public async Task<ActionResult<CategoryResponseDto>> GetById(int id)
        {
            CategoryResponseDto? category = await _services.GetByIdAsync(id);

            if(category is null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost("add")]
        public async Task<ActionResult<CategoryResponseDto>> AddCategory([FromBody] CategoryCreateDto dto)
        {
            CategoryResponseDto category = await _services.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new{id = category.Id},
                category
            );
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<CategoryResponseDto>> Update(int id, [FromBody] CategoryUpdateDto dto)
        {
            CategoryResponseDto? category = await _services.UpdateAsync(id, dto);

            if(category is null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool isDeleted = await _services.DeleteAsync(id);

            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}