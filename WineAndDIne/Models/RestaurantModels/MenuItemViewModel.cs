using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WineAndDine.BL.Models;

namespace WineAndDIne.Models
{
    public class MenuItemViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ItemTypeEnum FoodType { get; set; }

        public FoodCategoryEnum FoodCategory { get; set; }

        public DrinkCategoryEnum DrinkCategory { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int MenuId { get; set; }

        internal MenuItem MapToBusinessModel()
        {
            MenuItem item = new MenuItem
            {
                Id = this.Id,
                Name = this.Name,
                FoodCategory = this.FoodCategory,
                FoodType = this.FoodType,
                DrinkCategory = this.DrinkCategory,
                Description = this.Description,
                Price = this.Price,
            };

            return item;
        }

        internal static MenuItemViewModel Map(MenuItem item)
        {
            MenuItemViewModel vm = new MenuItemViewModel
            {
                Id = item.Id,
                Name = item.Name,
                FoodCategory = item.FoodCategory,
                FoodType = item.FoodType,
                DrinkCategory = item.DrinkCategory,
                Description = item.Description,
                Price = item.Price,
            };

            return vm;
        }
    }
}