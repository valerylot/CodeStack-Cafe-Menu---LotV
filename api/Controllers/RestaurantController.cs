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
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantServices _services;
        public RestaurantController(IRestaurantServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<ActionResult<List<RestaurantResponseDto>>> GetAll()
        {
            return Ok(await _services.GetAllAsync());
        }

        [HttpGet("getbyid/{id}")]
        public async Task<ActionResult<RestaurantResponseDto>> GetById(int id)
        {
            RestaurantResponseDto? restaurant = await _services.GetByIdAsync(id);

            if(restaurant is null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }

        [HttpPost("add")]
        public async Task<ActionResult<RestaurantResponseDto>> AddRestaurant([FromBody] RestaurantCreateDto dto)
        {
            RestaurantResponseDto restaurant = await _services.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new{id = restaurant.Id},
                restaurant
            );
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<RestaurantResponseDto>> Update(int id, [FromBody] RestaurantUpdateDto dto)
        {
            RestaurantResponseDto? restaurant = await _services.UpdateAsync(id, dto);

            if(restaurant is null)
            {
                return NotFound();
            }
            return Ok(restaurant);
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