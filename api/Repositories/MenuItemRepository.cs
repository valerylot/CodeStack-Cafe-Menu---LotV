using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly AppDbContext _db;
        public MenuItemRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<MenuItem> AddAsync(MenuItem menuItem)
        {
            _db.MenuItems.Add(menuItem);
            await _db.SaveChangesAsync();
            return menuItem;
        }

        public async Task DeleteAsync(MenuItem menuItem)
        {
            _db.MenuItems.Remove(menuItem);
            await _db.SaveChangesAsync();
        }

        public async Task<List<MenuItem>> GetAllAsync()
        {
            return await _db.MenuItems.ToListAsync();
        }

        public async Task<MenuItem?> GetByIdAsync(int id)
        {
            return await _db.MenuItems.FindAsync(id);
        }

        public async Task UpdateAsync(MenuItem menuItem)
        {
            _db.MenuItems.Update(menuItem);
            await _db.SaveChangesAsync();
        }
    }
}