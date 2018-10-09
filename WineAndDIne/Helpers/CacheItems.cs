using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WineAndDIne.Models;

namespace WineAndDIne
{
    public class CacheItems
    {
        private static List<RestaurantViewModel> _restaurants;
        public static List<RestaurantViewModel> Restaurants
        {
            get
            {
                if (_restaurants == null)
                {
                    //TODO
                    _restaurants = new List<RestaurantViewModel>();
                }
                return _restaurants;
            }
        }
    }
}