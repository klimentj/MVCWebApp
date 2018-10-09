using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineAndDine.BL.Models;

namespace WineAndDine.BL.ContractInterfaces
{
    public interface IRestaurantManagement
    {
        List<Restaurant> GetRestaurants();

        List<Restaurant> GetRestaurantsByLocation(string location);

        List<Menu> GetMenus();

        void AddMenu(Menu menu);

        List<MenuItem> GetItemsByRestaurant(int restaurantId);

        List<MenuItem> GetItemsByMenu(int menuId);

        decimal RateExpensivenessRestaurant(int restaurantId);


    }
}
