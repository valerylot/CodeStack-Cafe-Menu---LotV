using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;

namespace api.Services
{
    public interface IRestaurantServices
    {
        Task<List<RestaurantResponseDto>> GetAllAsync();
        Task<RestaurantResponseDto?> GetByIdAsync(int id);
        Task<RestaurantResponseDto> CreateAsync(RestaurantCreateDto dto);
        Task<RestaurantResponseDto?> UpdateAsync(int id, RestaurantUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}