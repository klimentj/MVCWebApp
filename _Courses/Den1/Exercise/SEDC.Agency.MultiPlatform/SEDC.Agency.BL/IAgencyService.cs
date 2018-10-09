using SEDC.Agency.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Agency.BL
{
    public interface IAgencyService
    {
        string GetTotalString();

        List<Property> GetAllProperties();

        void AddNewProperty(Property p);
    }
}
