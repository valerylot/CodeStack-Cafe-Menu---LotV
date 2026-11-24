using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;

namespace api.Services
{
    public interface IMenuItemServices
    {
        Task<List<MenuItemResponseDto>> GetAllAsync();
        Task<MenuItemResponseDto?> GetByIdAsync(int id);
        Task<MenuItemResponseDto> CreateAsync(MenuItemCreateDto dto);
        Task<MenuItemResponseDto?> UpdateAsync(int id, MenuItemUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}