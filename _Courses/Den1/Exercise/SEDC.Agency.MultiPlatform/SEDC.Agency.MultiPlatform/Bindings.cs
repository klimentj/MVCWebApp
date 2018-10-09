using Ninject.Modules;
using SEDC.Agency.BL;
using SEDC.Agency.BL.Interfaces;
using SEDC.Agency.BL.Interfaces.DataAccess;
using SEDC.Agency.DL.CsvDataAccess;
using SEDC.Agency.DL.EFDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Agency.WinForms
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            //Bind<IMailSender>().To<MockMailSender>();
            //
            Bind<IDataRepository>().To<EFDataRepository>();
            Bind<ILoggingRepository>().To<Log2>();


            //BL dependency
            Bind<IAgencyService>().To<AgencyBLService>();
        }
    }
}
