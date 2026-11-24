using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Models;
using api.Repositories;

namespace api.Services
{
    public class MenuItemServices : IMenuItemServices
    {
        private readonly IMenuItemRepository _repository;
        public MenuItemServices(IMenuItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<MenuItemResponseDto> CreateAsync(MenuItemCreateDto dto)
        {
            MenuItem menuItem = new MenuItem();
            menuItem.Name = dto.Name;
            menuItem.Category_Id = dto.Category_Id;
            menuItem.Price = dto.Price;
            menuItem.Description = dto.Description;
            menuItem.Image_Url = dto.Image_Url;
            menuItem.Tag = dto.Tag;

            MenuItem saved = await _repository.AddAsync(menuItem);
            return ToDto(saved);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            MenuItem? menuItem = await _repository.GetByIdAsync(id);
            if(menuItem is null)
            {
                return false;
            }
            await _repository.DeleteAsync(menuItem);
            return true;
        }

        public async Task<List<MenuItemResponseDto>> GetAllAsync()
        {
            List<MenuItem> menuItems = await _repository.GetAllAsync();
            return menuItems.Select(ToDto).ToList();
        }

        public async Task<MenuItemResponseDto?> GetByIdAsync(int id)
        {
            MenuItem? menuItem = await _repository.GetByIdAsync(id);

            if(menuItem is null)
            {
                return null;
            }
            return ToDto(menuItem);
        }

        public async Task<MenuItemResponseDto?> UpdateAsync(int id, MenuItemUpdateDto dto)
        {
            MenuItem? menuItem = await _repository.GetByIdAsync(id);
            if(menuItem is null)
            {
                return null;
            }
            
            menuItem.Name = dto.Name;
            menuItem.Category_Id = dto.Category_Id;
            menuItem.Price = dto.Price;
            menuItem.Description = dto.Description;
            menuItem.Image_Url = dto.Image_Url;
            menuItem.Tag = dto.Tag;

            menuItem.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(menuItem);
            return ToDto(menuItem);
        }

        //HELPER FUNCTION
        private static MenuItemResponseDto ToDto(MenuItem menuItem)
        {
            return new MenuItemResponseDto
            {
                Id = menuItem.Id,
                Name = menuItem.Name,
                Category_Id = menuItem.Category_Id,
                Price = menuItem.Price,
                Description = menuItem.Description,
                Image_Url = menuItem.Image_Url,
                Tag = menuItem.Tag
            };
        }
    }
}