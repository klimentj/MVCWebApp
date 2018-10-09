using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineAndDine.BL.Models;

namespace WineAndDine.TestMocks
{
    public static class StaticRepository
    {
        public static List<Restaurant> Restaurants { get; set; }

        public static List<Menu> Menus { get; set; }
    }
}
