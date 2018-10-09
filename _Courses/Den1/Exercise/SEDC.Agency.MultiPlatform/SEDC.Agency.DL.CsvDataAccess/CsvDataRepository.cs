using CsvHelper;
using SEDC.Agency.BL.Interfaces.DataAccess;
using SEDC.Agency.BL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Agency.DL.CsvDataAccess
{
    public class CsvDataRepository : IDataRepository
    {
        public List<Property> GetAllProperties()
        {
            List<Property> properties = null;
            using (TextReader reader = File.OpenText(@"Data.txt"))
            {
                var csv = new CsvReader(reader);
                properties = csv.GetRecords<Property>().ToList();
            }
            return properties;
        }


        public void Insert(Property p)
        {
            var properties = GetAllProperties();
            int maxId = 0;
            if (properties.Count > 0)
            {
                maxId = properties.Max(x => x.PropertyId);
            }
            p.PropertyId = maxId + 1;
            properties.Add(p);
            using (TextWriter tw = new StreamWriter("Data.txt", append: false))
            {
                List<Property> records = new List<Property> { p };
                var csv = new CsvWriter(tw);
                csv.WriteRecords(properties);
            }
        }
    }
}
