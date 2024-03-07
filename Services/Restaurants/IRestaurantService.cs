using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantRaterMVC.Models.Restaurant;

namespace RestaurantRaterMVC.Services.Restaurants
{
    public interface IRestaurantService
    {
        Task<List<RestaurantListItem>> GetAllRestaurantsAsync();
        Task<bool> CreateRestaurantAsync(RestaurantCreate model);
        Task<RestaurantDetail?> GetRestaurantAsync(int id);
    }
}