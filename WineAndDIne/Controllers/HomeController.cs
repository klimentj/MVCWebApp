using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WineAndDIne.Models;

namespace WineAndDIne.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GetNavbarRightMenu()
        {
            NavBarRightMenuModel model = new NavBarRightMenuModel();
            model.Name = "Kliment Jancheski";
            model.Title = "MVC developer";
            return PartialView("_NavbarRigthMenu", model);
        }
    }
}