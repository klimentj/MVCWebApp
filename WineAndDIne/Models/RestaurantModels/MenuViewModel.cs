using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WineAndDine.BL.Models;

namespace WineAndDIne.Models
{
    public class MenuViewModel
    {
        //The view model is focused at the User Interface
        //It can have different fields, depending the needs of the UI
        //As in this concrete case there is RestaurantName field

        public MenuViewModel()
        {
            Items = new List<MenuItemViewModel>();
            AllRestaurants = new List<SelectListItem>();
        }
        public int Id { get; set; }

        public int RestaurantId { get; set; }

        public string RestaurantName { get; set; }

        public string Name { get; set; }

        public List<MenuItemViewModel> Items { get; set; }
        internal Menu MapToBusinessModel()
        {
            Menu menu = new Menu
            {
                Id = this.Id,
                RestaurantId = this.RestaurantId,
                Name = this.Name,
                Items = new List<MenuItem>(),
            };

            foreach (var x in this.Items)
            {
                menu.Items.Add(x.MapToBusinessModel());
            }

            return menu;
        }

        internal static MenuViewModel Map(Menu menu)
        {
            MenuViewModel vm = new MenuViewModel
            {
                Id = menu.Id,
                RestaurantId = menu.RestaurantId,
                RestaurantName = CacheItems.Restaurants.Select(x=>x.Name).FirstOrDefault(),
                Name = menu.Name,
                Items = new List<MenuItemViewModel>(),
            };

            foreach (var x in menu.Items)
            {
                vm.Items.Add(MenuItemViewModel.Map(x));
            }

            return vm;
        }

        internal static List<MenuViewModel> MapList(List<Menu> list)
        {
            List<MenuViewModel> vmList = new List<MenuViewModel>();
            foreach (var x in list)
            {
                vmList.Add(MenuViewModel.Map(x));
            }

            return vmList;
        }

        public List<SelectListItem> AllRestaurants { get; set; }

    }
}
