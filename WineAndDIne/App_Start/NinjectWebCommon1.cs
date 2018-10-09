using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using WineAndDine.BL;
using WineAndDine.BL.ContractInterfaces;
using WineAndDine.BL.ContractInterfaces.DbContracts;
using WineAndDine.TestMocks;

namespace WineAndDIne.App_Start
{
    public static class NinjectWebCommon1
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                //kernel.Bind<iemployeerepository>().To<employeerepository>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.
        private static void RegisterServices(IKernel kernel)
        {            
            kernel.Load(Assembly.GetExecutingAssembly());
        }
    }

    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IMenuRepository>().To<MenuRepositoryMock>();
            Bind<IRestaurantRepository>().To<RestaurantRepositoryMock>();
            Bind<ILogger>().To<LoggerMock>();

            //services
            Bind<IRestaurantManagement>().To<RestaurantManagement>();
        }
    }
}