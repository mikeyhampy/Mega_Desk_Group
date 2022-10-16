using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mega_Desk_Hampton
{
    public partial class DisplayDetails : Form
    {
        
        public DisplayDetails()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okayBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DisplayDetails_Leave(object sender, EventArgs e)
        {
            this.Close();
        }

        public void displayDetails(DeskQuote quote)
        {
            this.Show();

            CustomerName2.Text = $"{quote.CustomerName}";
            MaterialCost2.Text = $"{quote.surfaceMaterial}";
            DrawerCost2.Text = $"${quote.DrawerCost.ToString()}";
            BasePrice2.Text =$"$200";
            ShippingCost2.Text = $"${quote.ShipPrice}";
            SurfaceCost2.Text = $"${quote.SurfaceAreaPrice}";
            totalPrice.Text = $"${quote.FinalPrice}";
        }
    }
}
