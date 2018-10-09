using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Agency.DL.EFDAL
{
    public class Property
    {
        public int PropertyId { get; set; }

        public string LocationAddress { get; set; }

        public int SizeSqMeter { get; set; }

        public decimal PriceRent { get; set; }

        public decimal PriceSale { get; set; }


        //01.01.0001
        public DateTime DateCreated { get; set; }

        public bool IsDeleted { get; set; }

        public BL.Models.Property MapToBusinessModel()
        {
            BL.Models.Property model = new BL.Models.Property
            {
                LocationAddress = this.LocationAddress,
                PriceRent = this.PriceRent,
                PriceSale = this.PriceSale,
                PropertyId = this.PropertyId,
                SizeSqMeter = this.SizeSqMeter,
            };

            return model;
        }

        public static Property MapFromBusinessModel(BL.Models.Property model)
        {
            Property p = new Property
            {
                SizeSqMeter = model.SizeSqMeter,
                PropertyId = model.PropertyId,
                PriceSale = model.PriceSale,
                PriceRent = model.PriceRent,
                LocationAddress = model.LocationAddress,
                IsDeleted = false,
            };

            return p;
        }
    }
}
