using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Models;
using api.Repositories;

namespace api.Services
{
    public class RestaurantServices : IRestaurantServices
    {
        private readonly IRestaurantRepository _repository;
        public RestaurantServices(IRestaurantRepository repository)
        {
            _repository = repository;
        }

        public async Task<RestaurantResponseDto> CreateAsync(RestaurantCreateDto dto)
        {
            Restaurant restaurant = new Restaurant();
            restaurant.Name = dto.Name;
            restaurant.Tagline = dto.Tagline;
            restaurant.Address = dto.Address;
            restaurant.Hours = dto.Hours;
            restaurant.Phone = dto.Phone;

            Restaurant saved = await _repository.AddRestaurantAsync(restaurant);
            return ToDto(saved);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Restaurant? restaurant = await _repository.GetByIdAsync(id);
            if(restaurant is null)
            {
                return false;
            }
            await _repository.DeleteAsync(restaurant);
            return true;
        }

        public async Task<List<RestaurantResponseDto>> GetAllAsync()
        {
            List<Restaurant> restaurants = await _repository.GetAllAsync();
            return restaurants.Select(ToDto).ToList();
        }

        public async Task<RestaurantResponseDto?> GetByIdAsync(int id)
        {
            Restaurant? restaurant = await _repository.GetByIdAsync(id);

            if(restaurant is null)
            {
                return null;
            }

            return ToDto(restaurant);
        }

        public async Task<RestaurantResponseDto?> UpdateAsync(int id, RestaurantUpdateDto dto)
        {
            Restaurant? restaurant = await _repository.GetByIdAsync(id);
            if(restaurant is null)
            {
                return null;
            }

            restaurant.Name = dto.Name;
            restaurant.Tagline = dto.Tagline;
            restaurant.Address = dto.Address;
            restaurant.Hours = dto.Hours;
            restaurant.Phone = dto.Phone;

            restaurant.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(restaurant);
            return ToDto(restaurant);
        }

        //HELPER FUNCTION
        private static RestaurantResponseDto ToDto(Restaurant restaurant)
        {
            return new RestaurantResponseDto
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Tagline = restaurant.Tagline,
                Address = restaurant.Address,
                Hours = restaurant.Hours,
                Phone = restaurant.Phone
            };
        }
    }
}