using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineAndDine.BL.Models
{
    public class MenuItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ItemTypeEnum FoodType { get; set; }

        public FoodCategoryEnum FoodCategory { get; set; }

        public DrinkCategoryEnum DrinkCategory { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}
