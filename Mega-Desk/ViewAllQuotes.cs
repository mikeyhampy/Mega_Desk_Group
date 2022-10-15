using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.IsolatedStorage; //https://learn.microsoft.com/en-us/dotnet/standard/io/how-to-read-and-write-to-files-in-isolated-storage
using Newtonsoft.Json; //https://stackoverflow.com/questions/33081102/json-add-new-object-to-existing-json-file-c-sharp
using System.Windows.Forms.VisualStyles;

namespace Mega_Desk_Hampton
{
    public partial class ViewAllQuotes : Form
    {
        private List<DeskQuote> quoteList = new List<DeskQuote>();
        
        public ViewAllQuotes()
        {
            InitializeComponent();
            viewDetailsBtn.Enabled = false;

            string objData = "";
            IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);
            using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("quotes.json", FileMode.Open, isoStore))
            {
                using (StreamReader reader = new StreamReader(isoStream))
                {
                    objData = reader.ReadToEnd();
                    string objDataSanitized = objData.Replace("\n", string.Empty);
                    objDataSanitized = objDataSanitized.Replace("\r", string.Empty);
                    objDataSanitized = objDataSanitized.Replace("\t", string.Empty);
                    if (objDataSanitized != "Nothing in this file")
                    {
                        quoteList = JsonConvert.DeserializeObject<List<DeskQuote>>(objData);
                    }
                }
            }

            generate_quotes();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
             Close();
            var mainMenu = (MainMenu)Tag;
            mainMenu.Show();
           
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
            //displays all deskquotes onto ViewAllQuotes form

            try
            {
                //Goes through each quote in quoteList that was pulled from the JSON file
                foreach (DeskQuote quote in quoteList)
                {   //This adds each quote to the quotebox. An override method of ToString was added to DeskQuote so it would display 
                    // Name - Total - Date
                    quotesBox.Items.Add(quote);
                }
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("There are no quotes to show");
                
            }

        }
        /**
         * viewDetailsBtn on click event
         * Purpose: to allow the user to see all the quote details from the selected quote
         */
        private void viewDetailsBtn_Click(object sender, EventArgs e)
        {
            //Opens displayDetails form with the rest of the quote's information

            DeskQuote select = (DeskQuote)quotesBox.SelectedItem;
            DisplayDetails displayDetails = new DisplayDetails();
            displayDetails.displayDetails(select);
            
        }

        private void ViewAllQuotes_Load(object sender, EventArgs e)
        {
            

        }

        private void quotesBox_Click(object sender, EventArgs e)
        {
            //Makes the viewDetailsBtn enabled if an item has been selected from the quotesBox
            if (quotesBox.SelectedItems.Count == 1)
            {
                viewDetailsBtn.Enabled = true;
            }
        }
    }
}
