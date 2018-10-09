using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WineAndDine.BL.Models;

namespace WineAndDIne.Models
{
    public class RestaurantViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        internal Restaurant MapToBusinessModel()
        {
            Restaurant result = new Restaurant
            {
                Id = this.Id,
                Name = this.Name,
            };

            return result;
        }

        internal static RestaurantViewModel Map(Restaurant restaurant)
        {
            RestaurantViewModel r = new RestaurantViewModel
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
            };

            return r;
        }


    }
}