using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RestaurantRaterMVC.Data
{
    public class Restaurant
    {
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string Location { get; set; } = string.Empty;
    
    public List<Rating> Ratings { get; set; } = new();
    public double AverageRating
    {
        get
        {
            if (Ratings.Count == 0)
                return 0;

            return Ratings.Select(r => r.Score).Sum() / Ratings.Count;
        }
    }
    }
}