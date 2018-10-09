using SEDC.Agency.BL.Interfaces;
using SEDC.Agency.BL.Interfaces.DataAccess;
using SEDC.Agency.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Agency.BL
{
    public class AgencyBLService : IAgencyService
    {

        private readonly IDataRepository _dataRepository;
        private readonly ILoggingRepository _logRepository;

        public AgencyBLService(IDataRepository dataRepository, ILoggingRepository log)
        {
            _dataRepository = dataRepository;
            _logRepository = log;
        }
        public string GetTotalString()
        {
            List<Property> properties = _dataRepository.GetAllProperties();

            int totalSqMeters = 0;
            decimal totalRentPrice = 0;
            decimal totalSalePrice = 0;
            foreach (Property p in properties)
            {
                totalSqMeters += p.SizeSqMeter;
                totalRentPrice += p.PriceRent;
                totalSalePrice += p.PriceSale;
            }
            int count = properties.Count;
            string result = string.Format(@"We have {0} properties with total area {1} Sq Meters 
 for average rent price {2} and average sale price {3}",
                                                       count,
                                                       totalSqMeters,
                                                       totalRentPrice / count,
                                                       totalSalePrice / count);

            return result;
        }

        public List<Property> GetAllProperties()
        {
            return _dataRepository.GetAllProperties();
        }

        public void AddNewProperty(Property p)
        {
            try
            {
                _dataRepository.Insert(p);
            }
            catch (Exception ex)
            {
                _logRepository.LogError(ex);
                throw;
            }
        }
    }
}
