using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineAndDine.BL.Models;

namespace WineAndDine.DL.DataEntities
{
    public class MenuItemDbModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ItemTypeEnum FoodType { get; set; }

        public FoodCategoryEnum FoodCategory { get; set; }

        public DrinkCategoryEnum DrinkCategory { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }
        

        public int MenuId { get; set; }

        public virtual MenuDbModel MenuDb { get; set; }

        public MenuItem MapToBusinessModel()
        {
            MenuItem result = new MenuItem
            {
                Id = this.Id,
                FoodType = this.FoodType,
                FoodCategory = this.FoodCategory,
                DrinkCategory = this.DrinkCategory,
                Name = this.Name,
                Price = this.Price,
                Description = this.Description,          
            };

            return result;
            
            
        }

        public static MenuItemDbModel Map(MenuItem item)
        {
            MenuItemDbModel dm = new MenuItemDbModel
            {
                Id = item.Id,
                FoodType = item.FoodType,
                FoodCategory = item.FoodCategory,
                DrinkCategory = item.DrinkCategory,
                Name = item.Name,
                Price = item.Price,
                Description = item.Description,
            };

            return dm;
        }
    }
}
