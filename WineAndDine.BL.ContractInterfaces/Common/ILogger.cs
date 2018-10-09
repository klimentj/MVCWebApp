using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineAndDine.BL.ContractInterfaces
{
    public interface ILogger
    {
        void LogError(Exception ex);
        void LogError(string message, Exception ex);

        void LogInfo(string message);
    }
}
