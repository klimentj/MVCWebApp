using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Agency.BL.Interfaces
{
    public interface ILoggingRepository
    {
        void LogError(Exception ex);

        void LogError(Exception ex, string message);

        void LogInfo(string message);
    }
}
