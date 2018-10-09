using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineAndDine.BL.Models
{
    public class Menu
    {
        public Menu()
        {
            Items = new List<MenuItem>();
        }
        public int Id { get; set; }
        public List<MenuItem> Items { get; set; }

        public string Name { get; set; }

        public int RestaurantId { get; set; }
    }
}
