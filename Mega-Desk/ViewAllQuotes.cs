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
    public partial class ViewAllQuotes : Form
    {
        public ViewAllQuotes()
        {
            InitializeComponent();
            generate_quotes();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var mainMenu = (MainMenu)Tag;
            mainMenu.Show();
            Close();
        }

        private void ViewAllQuotes_FormClosed(object sender, FormClosedEventArgs e)
        {
            var mainMenu = (MainMenu)Tag;
            mainMenu.Show();
        }

        /**
         * generate_quotes method
         * Purpose: To display quote information from JSON file 
         */
        public void generate_quotes()
        {

            //This is just a placeholder for when we get the JSON data. 
            // I was thinking initially we could just show the quote NAME, AMOUNT AND DATE and then
            // the viewDetailsbtn button could pull up the DisplayQuote form with all the additional information
            // for the selected AddQuote object (the viewDetailsbtn click event is found just below this method).
            // please let me know if this was confusing, or if you have a better idea
            for (int i = 1; i < 4; i++)
            {
                quotesBox.Items.Add($"Quote {i}");
            }
            
        }
        /**
         * viewDetailsBtn on click event
         * Purpose: to allow the user to see all the quote details from the selected quote
         */
        private void viewDetailsBtn_Click(object sender, EventArgs e)
        {
            var select = quotesBox.SelectedItem.ToString();

            MessageBox.Show("This is a placeholder, we can instead pull up the DisplayQuote form to show all additional information", select);
        }
    }
}
