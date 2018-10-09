using SEDC.Agency.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SEDC.Agency.WinForms
{
    public class Log2 : ILoggingRepository
    {
        public void LogError(Exception ex)
        {
            Debug.WriteLine(ex);
        }

        public void LogError(Exception ex, string message)
        {
            Debug.WriteLine(message);
            Debug.WriteLine(ex);
        }

        public void LogInfo(string message)
        {
            Debug.WriteLine(message);
        }
    }
}
