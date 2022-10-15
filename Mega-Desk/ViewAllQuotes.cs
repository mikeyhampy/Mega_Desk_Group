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

namespace Mega_Desk_Hampton
{
    public partial class ViewAllQuotes : Form
    {
        private List<DeskQuote> quoteList = new List<DeskQuote>();
        public ViewAllQuotes()
        {
            InitializeComponent();
            generate_quotes();

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

        private void ViewAllQuotes_Load(object sender, EventArgs e)
        {

        }
    }
}
