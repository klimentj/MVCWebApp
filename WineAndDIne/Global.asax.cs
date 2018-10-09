using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WineAndDine.BL;
using WineAndDine.BL.ContractInterfaces;
using WineAndDine.BL.ContractInterfaces.DbContracts;
using WineAndDine.TestMocks;

namespace WineAndDIne
{
    public class MvcApplication : System.Web.HttpApplication
    {
        //private static StandardKernel _kernel;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //NinjectWebCommon1.Start();
        }
    }
}
