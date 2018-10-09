using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineAndDine.BL.ContractInterfaces.DbContracts;
using WineAndDine.BL.Models;

namespace WineAndDine.TestMocks
{
    public class RestaurantRepositoryMock : IRestaurantRepository
    {
        public RestaurantRepositoryMock()
        {
            if (StaticRepository.Restaurants == null)
            {
                InitRestaurants();
            }
        }

        private void InitRestaurants()
        {
            StaticRepository.Restaurants = new List<Restaurant>();

            StaticRepository.Restaurants.Add(new Restaurant { Id = 1, Name = "Kaj Mece" });
            StaticRepository.Restaurants.Add(new Restaurant { Id = 2, Name = "Belvedere" });
            StaticRepository.Restaurants.Add(new Restaurant { Id = 3, Name = "Tino" });
            StaticRepository.Restaurants.Add(new Restaurant { Id = 4, Name = "Delikates" });
            StaticRepository.Restaurants.Add(new Restaurant { Id = 5, Name = "Gurman" });
            StaticRepository.Restaurants.Add(new Restaurant { Id = 6, Name = "Kj Divono" });
            StaticRepository.Restaurants.Add(new Restaurant { Id = 7, Name = "Stacione" });
            StaticRepository.Restaurants.Add(new Restaurant { Id = 8, Name = "Biljanini" });
            StaticRepository.Restaurants.Add(new Restaurant { Id = 9, Name = "Via Ignatia" });
            StaticRepository.Restaurants.Add(new Restaurant { Id = 10, Name = "Sv. Nikola" });
            StaticRepository.Restaurants.Add(new Restaurant { Id = 11, Name = "Sv. Sofia" });
            StaticRepository.Restaurants.Add(new Restaurant { Id = 12, Name = "Kaneo" });
            StaticRepository.Restaurants.Add(new Restaurant { Id = 13, Name = "Podpesh" });

        }

        public void Delete(int id)
        {
            StaticRepository.Restaurants.RemoveAll(x => x.Id == id);
        }

        public void Delete(Restaurant entity)
        {
            if (entity == null)
            {
                return;
            }
            StaticRepository.Restaurants.RemoveAll(x => x.Id == entity.Id);
        }

        public List<Restaurant> GetAll()
        {
            return StaticRepository.Restaurants;
        }

        public void Insert(Restaurant entity)
        {
            int maxId = StaticRepository.Restaurants.Max(x => x.Id);
            entity.Id = maxId + 1;
            StaticRepository.Restaurants.Add(entity);
        }
    }
}
