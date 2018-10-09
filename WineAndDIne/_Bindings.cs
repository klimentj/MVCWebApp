using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WineAndDine.BL;
using WineAndDine.BL.ContractInterfaces;
using WineAndDine.BL.ContractInterfaces.DbContracts;
using WineAndDine.TestMocks;

namespace WineAndDIne
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            //Repositories
            Bind<IRestaurantRepository>().To<RestaurantRepositoryMock>();
            Bind<IMenuRepository>().To<MenuRepositoryMock>();
            Bind<ILogger>().To<Logger2Mock>();

            //Buisiness services
            Bind<IRestaurantManagement>().To<RestaurantManagement>();
        }
    }
}