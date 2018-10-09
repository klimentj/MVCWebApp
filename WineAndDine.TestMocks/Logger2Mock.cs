using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineAndDine.BL.ContractInterfaces;

namespace WineAndDine.TestMocks
{
    public class Logger2Mock : ILogger
    {
        public void LogError(Exception ex)
        {
            Debug.WriteLine(ex);
        }

        public void LogError(string message, Exception ex)
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
