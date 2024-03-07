using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantRaterMVC.Data;
using Microsoft.EntityFrameworkCore;
using RestaurantRaterMVC.Models.Restaurant;

namespace RestaurantRaterMVC.Services.Restaurants
{
    public class RestaurantService : IRestaurantService
    {
        private RestaurantDbContext _context;
        public RestaurantService(RestaurantDbContext context) 
        {
            _context = context;
        }
        public async Task<List<RestaurantListItem>> GetAllRestaurantsAsync() 
        {
        
            List<RestaurantListItem> restaurants = await _context.Restaurants
            .Include(r => r.Ratings)
            .Select(r => new RestaurantListItem()
        {
            Id = r.Id,
            Name = r.Name,
            Score = (float)r.AverageRating
        })
        .ToListAsync();

        return restaurants;
        }

    // Restaurant Detail Get
    public async Task<RestaurantDetail?> GetRestaurantAsync(int id)
{
    Restaurant? restaurant = await _context.Restaurants
        .Include(r => r.Ratings)
        .FirstOrDefaultAsync(r => r.Id == id);

    return restaurant is null ? null : new()
    {
        Id = restaurant.Id,
        Name = restaurant.Name,
        Location = restaurant.Location,
        Score = restaurant.AverageRating
    };
}

        // Create Restaurant
    public async Task<bool> CreateRestaurantAsync(RestaurantCreate model)
    {
        Restaurant entity = new()
        {
            Name = model.Name,
            Location = model.Location
        };
        _context.Restaurants.Add(entity);
        return await _context.SaveChangesAsync() == 1;
    }
    }
}