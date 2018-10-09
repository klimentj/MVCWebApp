using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineAndDine.BL.ContractInterfaces.DbContracts;
using WineAndDine.BL.Models;

namespace WineAndDine.TestMocks
{
    public class MenuRepositoryMock : IMenuRepository
    {
        public MenuRepositoryMock()
        {
            if (StaticRepository.Menus == null)
            {
                InitMenus();
            }
        }

        private void InitMenus()
        {
            StaticRepository.Menus = new List<Menu>();
            Menu m = new Menu
            {
                Id = 1,
                RestaurantId = 1,
                Name = "Restoran Mece Meni",
                Items = new List<MenuItem>(),
            };

            m.Items.Add(new MenuItem
            {
                Id =1,
                Name="Vesalica",
                FoodCategory=FoodCategoryEnum.MainCourse,
                FoodType=ItemTypeEnum.Food,
            });

            m.Items.Add(new MenuItem
            {
                Id = 2,
                Name = "Svinsko File",
                FoodType = ItemTypeEnum.Food,
                FoodCategory = FoodCategoryEnum.MainCourse,
            });

            StaticRepository.Menus.Add(m);

            //Belvedere
            m = new Menu
            {
                Id = 2,
                RestaurantId = 2,
                Name = "Belvedere Meni",
                Items = new List<MenuItem>(),
            };

            m.Items.Add(new MenuItem
            {
                Id = 3,
                Name = "Rakija",
                FoodType = ItemTypeEnum.Drinks,
                Price = 70,
                DrinkCategory = DrinkCategoryEnum.Alcohol,
            });

            m.Items.Add(new MenuItem
            {
                Id = 4,
                Name = "Vesalica",
                FoodType = ItemTypeEnum.Food,
                FoodCategory = FoodCategoryEnum.MainCourse,
                Price = 280,

            });

            m.Items.Add(new MenuItem
            {
                Id = 5,
                Name = "Skopsko Pivo",
                FoodType = ItemTypeEnum.Drinks,
                DrinkCategory = DrinkCategoryEnum.Alcohol,
                Price = 80,
            });
            m.Items.Add(new MenuItem
            {
                Id = 6,
                Name = "Amstel",
                FoodType = ItemTypeEnum.Drinks,
                DrinkCategory = DrinkCategoryEnum.Alcohol,
                Price = 100,
            });
            m.Items.Add(new MenuItem
            {
                Id = 7,
                Name = "Heineken",
                FoodType = ItemTypeEnum.Drinks,
                DrinkCategory = DrinkCategoryEnum.Alcohol,
                Price = 150,
            });
            m.Items.Add(new MenuItem
            {
                Id = 8,
                Name = "Konjak",
                FoodType = ItemTypeEnum.Drinks,
                DrinkCategory = DrinkCategoryEnum.Alcohol,
                Price = 100,
            });
            m.Items.Add(new MenuItem
            {
                Id = 9,
                Name = "Stock",
                FoodType = ItemTypeEnum.Drinks,
                DrinkCategory = DrinkCategoryEnum.Alcohol,
                Price = 120,
            });
            m.Items.Add(new MenuItem
            {
                Id = 10,
                Name = "Konjak",
                FoodType = ItemTypeEnum.Drinks,
                DrinkCategory = DrinkCategoryEnum.Alcohol,
                Price = 100,
            });
            m.Items.Add(new MenuItem
            {
                Id = 11,
                Name = "Vodka",
                FoodType = ItemTypeEnum.Drinks,
                DrinkCategory = DrinkCategoryEnum.Alcohol,
                Price = 100,
            });
            m.Items.Add(new MenuItem
            {
                Id = 12,
                Name = "Dzin",
                FoodType = ItemTypeEnum.Drinks,
                DrinkCategory = DrinkCategoryEnum.Alcohol,
                Price = 100,
            });
            m.Items.Add(new MenuItem
            {
                Id = 13,
                Name = "Vino-Smederevka",
                FoodType = ItemTypeEnum.Drinks,
                DrinkCategory = DrinkCategoryEnum.Alcohol,
                Price = 100,
            });
            m.Items.Add(new MenuItem
            {
                Id = 14,
                Name = "Vino - Temjanika",
                FoodType = ItemTypeEnum.Drinks,
                DrinkCategory = DrinkCategoryEnum.Alcohol,
                Price = 100,
            });
            m.Items.Add(new MenuItem
            {
                Id = 15,
                Name = "Vino - Roze",
                FoodType = ItemTypeEnum.Drinks,
                DrinkCategory = DrinkCategoryEnum.Alcohol,
                Price = 100,
            });
            StaticRepository.Menus.Add(m);
        }

        public void Delete(int id)
        {
            StaticRepository.Menus.RemoveAll(x => x.Id == id);
        }

        public void Delete(Menu entity)
        {
            if(entity == null)
            {
                return;
            }
            Delete(entity.Id);
        }

        public List<Menu> GetAll()
        {
            return StaticRepository.Menus;
        }

        public void Insert(Menu entity)
        {
            int maxId = StaticRepository.Restaurants.Max(x => x.Id);
            entity.Id = maxId + 1;
            StaticRepository.Menus.Add(entity);
        }
    }
}
