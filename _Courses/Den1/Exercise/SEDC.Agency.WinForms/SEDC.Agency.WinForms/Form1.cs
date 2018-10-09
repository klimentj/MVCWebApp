using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEDC.Agency.WinForms
{
    public partial class Form1 : Form
    {
        private static List<Property> _properties;
        public Form1()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            List<Property> records = new List<Property>();

            //https://joshclose.github.io/CsvHelper/
            //Install-Package CsvHelper
            using (TextReader reader = File.OpenText(@"Data.txt"))
            {
                var csv = new CsvReader(reader);
                records = csv.GetRecords<Property>().ToList();
                _properties = records;
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dgProperties.DataSource = _properties;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            Property p = new Property();
            int i = 0; decimal d = 0M;

            p.LocationAddress = txtLocation.Text;
            
            bool success = int.TryParse(txtSizeSq.Text, out i);
            if (!success)
            {
                MessageBox.Show("Invalid size!");
                return;
            }
            p.SizeSqMeter = i;

            success = decimal.TryParse(txtPriceRent.Text, out d);
            if (!success)
            {
                MessageBox.Show("Invalid price rent!");
                return;
            }
            p.PriceRent = d;

            success = decimal.TryParse(txtPriceSale.Text, out d);
            if (!success)
            {
                MessageBox.Show("Invalid size!");
                return;
            }
            p.PriceSale = d;


            //get current max PropertyId and assign new incremented
            int maxId = 0;
            if (_properties.Count > 0)
            {
                maxId = _properties.Max(x => x.PropertyId);
            }
            p.PropertyId = maxId + 1;
            _properties.Add(p);

            //add the new to the list and save to file 
            using (TextWriter tw = new StreamWriter("Data.txt", append: false))
            {
                List<Property> records = new List<Property> { p };
                var csv = new CsvWriter(tw);
                csv.WriteRecords(_properties);
            }

            //refresh grid
            dgProperties.DataSource = _properties;
            dgProperties.Update();
            dgProperties.Refresh();
        }

        private void btnTotal_Click(object sender, EventArgs e)
        {
            int totalSqMeters = 0;
            decimal totalRentPrice = 0;
            decimal totalSalePrice = 0;
            foreach (Property p in _properties)
            {
                totalSqMeters += p.SizeSqMeter;
                totalRentPrice += p.PriceRent;
                totalSalePrice += p.PriceSale;
            }
            int count = _properties.Count;
            lblTotal.Text = string.Format(@"We have {0} properties with total area {1} Sq Meters 
 for average rent price {2} and average sale price {3}",
                                                       count,
                                                       totalSqMeters,
                                                       totalRentPrice / count,
                                                       totalSalePrice / count);
        }
    }
}
