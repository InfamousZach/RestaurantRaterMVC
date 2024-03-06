using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantRaterApi.Data;

namespace RestaurantRaterMVC.Services.Restaurants
{
    public class RestaurantService : IRestaurantService
    {
        private RestaurantDbContext _context;
        public RestaurantService(RestaurantDbContext context) 
        {
            _context = context
        }
    }
}