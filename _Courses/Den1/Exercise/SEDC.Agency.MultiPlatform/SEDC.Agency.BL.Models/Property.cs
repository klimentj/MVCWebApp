using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Agency.BL.Models
{
    public class Property
    {
        public int PropertyId { get; set; }

        public string LocationAddress { get; set; }

        public int SizeSqMeter { get; set; }

        public decimal PriceRent { get; set; }

        public decimal PriceSale { get; set; }
    }
}
