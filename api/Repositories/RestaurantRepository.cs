using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {

        private readonly AppDbContext _db;
        public RestaurantRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Restaurant> AddRestaurantAsync(Restaurant restaurant)
        {
            _db.Restaurants.Add(restaurant);
            await _db.SaveChangesAsync();
            return restaurant;
        }

        public async Task DeleteAsync(Restaurant restaurant)
        {
            _db.Restaurants.Remove(restaurant);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Restaurant>> GetAllAsync()
        {
            return await _db.Restaurants.ToListAsync();
        }

        public async Task<Restaurant?> GetByIdAsync(int id)
        {
            return await _db.Restaurants.FindAsync(id);
        }

        public async Task UpdateAsync(Restaurant restaurant)
        {
            _db.Restaurants.Update(restaurant);
            await _db.SaveChangesAsync();
        }
    }
}