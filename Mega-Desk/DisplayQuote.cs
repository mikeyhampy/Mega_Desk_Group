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
    public partial class DisplayQuote : Form
    {
        public DeskQuote __deskQuote;
        public DisplayQuote(DeskQuote _deskquote)
        {
            __deskQuote = _deskquote;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var addQuote = (AddQuote)Tag;
            addQuote.Show();
            Close();
        }

        private void DisplayQuote_FormClosed(object sender, FormClosedEventArgs e)
        {
            var addQuote = (AddQuote)Tag;
            addQuote.Show();
        }

        private void DisplayQuote_Load(object sender, EventArgs e)
        {
            CustomerName.Text = __deskQuote.CustomerName;
            MaterialCost.Text = "$" + (string)__deskQuote.SurfaceMaterialPrice.ToString();
            DrawerCost.Text = "$" + (string)__deskQuote.DrawerCost.ToString();
            TotalCost.Text = "$" + (string)__deskQuote.FinalPrice.ToString();
            MaterialLabel.Text = __deskQuote.surfaceMaterial + "Cost:";
            ShippingCost.Text = "$" + (string)__deskQuote.ShipPrice.ToString();
            SurfaceCost.Text = "$" + (string)__deskQuote.SurfaceAreaPrice.ToString();
            BasePrice.Text = $"${200}";
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            //var mainMenu = (MainMenu)Tag;
            //mainMenu.Show();

            var addQuote = (AddQuote)Tag;
            addQuote.Show();
            Close();

        }
    }
}
