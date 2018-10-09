using SEDC.Agency.BL.Interfaces.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Agency.DL.EFDAL
{
    public class EFDataRepository : IDataRepository
    {
        private AgencyContext context = new AgencyContext();
        public List<BL.Models.Property> GetAllProperties()
        {
            var list = context.Properties
                .Where(x=>x.IsDeleted == false)
                .Select(x=>x).ToList();

            List<BL.Models.Property> result = new List<BL.Models.Property>();

            foreach (var x in list)
            {
                result.Add(x.MapToBusinessModel());
            }

            return result;
        }

        public void Insert(BL.Models.Property p)
        {
            Property property =  Property.MapFromBusinessModel(p);

            context.Properties.Add(property);
            context.SaveChanges();
        }
    }
}
