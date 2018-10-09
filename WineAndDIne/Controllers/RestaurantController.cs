using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WineAndDine.BL.ContractInterfaces;
using WineAndDIne.Models;

namespace WineAndDIne.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IRestaurantManagement _restaurantManagement;
        private readonly ILogger _logger;

        // GET: Restaurant
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult AddMenu(MenuViewModel model)
        {
            try
            {
                _restaurantManagement.AddMenu(model.MapToBusinessModel());
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}