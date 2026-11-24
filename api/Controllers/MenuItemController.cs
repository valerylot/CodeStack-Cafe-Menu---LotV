using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Repositories;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuItemController : ControllerBase
    {
        private readonly IMenuItemServices _services;
        public MenuItemController(IMenuItemServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<ActionResult<List<MenuItemResponseDto>>> GetAll()
        {
            return Ok(await _services.GetAllAsync());
        }

        [HttpGet("getbyid/{id}")]
        public async Task<ActionResult<MenuItemResponseDto>> GetById(int id)
        {
            MenuItemResponseDto? menuItem = await _services.GetByIdAsync(id);

            if(menuItem is null)
            {
                return NotFound();
            }
            return Ok(menuItem);
        }

        [HttpPost("add")]
        public async Task<ActionResult<MenuItemResponseDto>> AddMenuItem([FromBody] MenuItemCreateDto dto)
        {
            MenuItemResponseDto menuItem = await _services.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new{id = menuItem.Id},
                menuItem
            );
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<MenuItemResponseDto>> Update(int id, [FromBody] MenuItemUpdateDto dto)
        {
            MenuItemResponseDto? menuItem = await _services.UpdateAsync(id, dto);

            if(menuItem is null)
            {
                return NotFound();
            }
            return Ok(menuItem);
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