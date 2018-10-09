using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WineAndDine.BL.ContractInterfaces;
using WineAndDine.BL.Models;
using WineAndDIne.Models;

namespace WineAndDIne.Controllers
{
    public class MenuController : Controller
    {
        //public MenuController()
        //{ }
        private readonly IRestaurantManagement _restaurantManagement;        
        private readonly ILogger _logger;

        //constructior with Injection
        public MenuController(
            IRestaurantManagement restaurantManagement
            , ILogger logger
            )
        {
            _restaurantManagement = restaurantManagement;
            _logger = logger;
        }

        // GET: Menu
        public ActionResult Index()
        {
            _logger.LogInfo("!!! Menus View Opened!!!");
            //List<Menu> menus = _restaurantManagement.GetMenus();
            //List<MenuViewModel> vmList = MenuViewModel.MapList(menus);

            return View();
        }

        public ActionResult GetMenuData(int iDisplayStart, int iDisplayLength)
        {
            List<Menu> menus = _restaurantManagement.GetMenus();
            List<MenuViewModel> vmList = MenuViewModel.MapList(menus);
            
            return Json(new
            {
                iTotalRecords = vmList.Count(),
                iTotalDisplayRecords = vmList.Count(),
                aaData = vmList
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetMenuItems(int id)
        {
            ViewBag.id = id;
            return View();
        }

        public ActionResult GetMenuItemsData(int id, int iDisplayStart, int iDisplayLength)
        {
            var data = _restaurantManagement.GetMenus()
                .FirstOrDefault(t => t.RestaurantId == id).Items.Skip(iDisplayStart).Take(iDisplayLength);

            var count = _restaurantManagement.GetMenus().FirstOrDefault(t => t.RestaurantId == id).Items.Count();

            return Json(new
            {
                iTotalRecords = iDisplayLength,
                iTotalDisplayRecords = count,
                aaData = data
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditMenuItem(int restaurantId, int menuId)
        {
            
            var menuItem = _restaurantManagement.GetMenus().
                FirstOrDefault(t => t.Id == restaurantId)
                .Items.FirstOrDefault(t => t.Id == menuId);
            var menu = MenuItemViewModel.Map(menuItem);

            ViewBag.RestaurantId = restaurantId;

            return PartialView("_EditMenuItem", menu);
        }

        
        public ActionResult UpdateMenuItem(int id, int restaurantId, string name, decimal price)
        {
            var menuItem = _restaurantManagement.GetMenus().
                FirstOrDefault(t => t.Id == restaurantId)
                .Items.FirstOrDefault(t => t.Id == id);

            menuItem.Name = name;
            menuItem.Price = price;

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            MenuViewModel model = new MenuViewModel();
            var allRestaurants = _restaurantManagement.GetRestaurants();
            foreach (var x in allRestaurants)
            {
                model.AllRestaurants.Add(new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            }
            

            return View(model);

            
        }

        [HttpPost]
        public ActionResult Create(MenuViewModel model)
        {
            try
            {
                _restaurantManagement.AddMenu(model.MapToBusinessModel());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                throw;
            }
            return RedirectToAction("Index");
        }

    }
}