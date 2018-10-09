using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineAndDine.BL.ContractInterfaces;

namespace WineAndDine.TestMocks
{
    public class LoggerMock : ILogger
    {
        public void LogError(Exception ex)
        {

        }

        public void LogError(string message, Exception ex)
        {

        }

        public void LogInfo(string message)
        {

        }
    }
}
