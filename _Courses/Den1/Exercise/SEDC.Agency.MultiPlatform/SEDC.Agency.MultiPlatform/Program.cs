using Ninject;
using SEDC.Agency.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEDC.Agency.WinForms
{
    static class Program
    {
        static StandardKernel _kernel;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Standard Ninject initialization
            StandardKernel kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            _kernel = kernel;


            //this is only for WinForms app
            IAgencyService service = kernel.Get<IAgencyService>();
            Application.Run(new Form1(service));  //Constructor injection in new Form1

        }
    }
}
