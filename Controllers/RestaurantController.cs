using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestaurantRaterMVC.Services.Restaurants;
using RestaurantRaterMVC.Models.Restaurant;

namespace RestaurantRaterMVC.Controllers
{
    public class RestaurantController : Controller
    {
    private IRestaurantService _service;
    public RestaurantController(IRestaurantService service)
    {
        _service = service;
    }
    
    // Index endpoint method
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        List<RestaurantListItem> restaurants = await _service.GetAllRestaurantsAsync();
        return View(restaurants);
    }
// Restaurant Create Get
[HttpGet]
public IActionResult Create()
{
    return View();
}

// Restaurant Create Post
[HttpPost]
public async Task<IActionResult> Create(RestaurantCreate model)
{
    if (!ModelState.IsValid)
        return View(model);

    await _service.CreateRestaurantAsync(model);

    return RedirectToAction(nameof(Index));
}

    public async Task<IActionResult> Details(int id)
{
    RestaurantDetail? model = await _service.GetRestaurantAsync(id);

    if (model is null)
        return NotFound();
    
    return View(model);
}

    // Restaurant Edit Get
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        RestaurantDetail? restaurant = await _service.GetRestaurantAsync(id);
        if (restaurant is null)
            return NotFound();

        RestaurantEdit model = new()
        {
            Id = restaurant.Id,
            Name = restaurant.Name ?? "",
            Location = restaurant.Location ?? ""
        };

        return View(model);
    }

    // Restaurant Edit Post
    [HttpPost]
    public async Task<IActionResult> Edit(int id, RestaurantEdit model)
    {
        if (!ModelState.IsValid)
            return View(model);

        if (await _service.UpdateRestaurantAsync(model))
            return RedirectToAction(nameof(Details), new { id = id });

        ModelState.AddModelError("Save Error", "Could not update the Restaurant. Please try again.");
        return View(model);
    }
    }
}