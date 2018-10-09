using SEDC.Agency.BL;
using SEDC.Agency.BL.Interfaces;
using SEDC.Agency.BL.Interfaces.DataAccess;
using SEDC.Agency.BL.Models;
using SEDC.Agency.DL.CsvDataAccess;
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
        private IAgencyService _agencyService;
        public Form1(IAgencyService agencyService)
        {
            InitializeComponent();

            _agencyService = agencyService;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgProperties.DataSource = _agencyService.GetAllProperties();
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
            _agencyService.AddNewProperty(p);

            //refresh grid
            dgProperties.DataSource = _agencyService.GetAllProperties();
        }

        private void btnTotal_Click(object sender, EventArgs e)
        {
            lblTotal.Text = _agencyService.GetTotalString();
        }
    }
}
