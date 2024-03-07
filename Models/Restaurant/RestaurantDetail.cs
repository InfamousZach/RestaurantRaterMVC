using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RestaurantRaterMVC.Models.Restaurant
{
    public class RestaurantDetail
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }

        [Display(Name = "Average Score")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double Score { get; set; }
    }
}