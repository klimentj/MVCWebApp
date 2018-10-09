using SEDC.Agency.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Agency.BL.Interfaces.DataAccess
{
    public interface IDataRepository
    {
        List<Property> GetAllProperties();

        void Insert(Property p);
    }
}
