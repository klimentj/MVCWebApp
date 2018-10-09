using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineAndDine.BL.Models;

namespace WineAndDine.DL.DataEntities
{
    public class MenuDbModel
    {
        public int Id { get; set; }

        public int RestaurantId { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public virtual List<MenuItemDbModel> MenuItems { get; set; }

        internal Menu MapToBusinessModel()
        {
            Menu result = new Menu
            {
                Id = this.Id,
                RestaurantId = this.RestaurantId,
                Name = this.Name,
                Items = new List<MenuItem>(),
            };

            foreach(var x in this.MenuItems)
            {
                MenuItem mi = x.MapToBusinessModel();
                result.Items.Add(mi);
            }

            return result;
        }

        internal static MenuDbModel Map(Menu menu)
        {
            MenuDbModel dm = new MenuDbModel
            {
                Id = menu.Id,
                RestaurantId = menu.RestaurantId,
                Name = menu.Name,
                MenuItems = new List<MenuItemDbModel>(),
            };

            foreach (var x in menu.Items)
            {
                dm.MenuItems.Add(MenuItemDbModel.Map(x));
            }

            return dm;
        }
    }
}
