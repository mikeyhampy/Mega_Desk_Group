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
    public partial class AddQuote : Form
    {
        public DeskQuote _deskQuote;
 
        public AddQuote(DeskQuote deskQuote)
        {
            _deskQuote = deskQuote;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var mainMenu = (MainMenu)Tag;
            mainMenu.Show();
            Close();
        }

        private void AddQuote_FormClosed(object sender, FormClosedEventArgs e)
        {
            var mainMenu = (MainMenu)Tag;
            mainMenu.Show();
        }

        private void WidthValue_Leave(object sender, EventArgs e)
        {
            int Width = (int) WidthValue.Value;
            if (Width > 96 )
            {
                Width = 96;
                WidthValue.Value = Width;
            } else if (Width < 24)
            {
                Width = 24;
                WidthValue.Value = Width;
            }
        }

        private void DepthValue_Leave(object sender, EventArgs e)
        {
            int Depth = (int)DepthValue.Value;
            if (Depth > 48)
            {
                Depth = 48;
                DepthValue.Value = Depth;
            }
            else if (Depth < 12)
            {
                Depth = 12;
                DepthValue.Value = Depth;
            }
        }

        private void numericUpDown1_Leave(object sender, EventArgs e)
        {
            int Drawer = (int) DrawerNumber.Value;
            if (Drawer > 7)
            {
                Drawer = 7;
                DrawerNumber.Value = Drawer;
            }
            else if (Drawer < 0)
            {
                Drawer = 0;
                DrawerNumber.Value = Drawer;
            }
;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CustomerName.Text.Length == 0 || ShipDays.Text.Length == 0 || SurfaceMaterial.Text.Length == 0)
            {
                // maybe prompt to do something else
            } else
            {
                //put all values gathered into the class
                _deskQuote.CustomerName = CustomerName.Text;
                _deskQuote.DaysShip = int.Parse(ShipDays.Text);
                _deskQuote.surfaceMaterial = SurfaceMaterial.Text.Trim();
                Console.WriteLine(SurfaceMaterial.Text);
                _deskQuote.DrawersNumber = (int) DrawerNumber.Value;
                _deskQuote.Depth = (int) DepthValue.Value;
                _deskQuote.Width = (int) WidthValue.Value;
                _deskQuote.CalcTotalPrice();

                DisplayQuote displayQuote = new DisplayQuote(_deskQuote);
                displayQuote.Tag = this;
                displayQuote.Show(this);
                Hide();
            }
        }
    }
}
