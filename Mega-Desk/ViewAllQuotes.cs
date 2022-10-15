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

        private void ViewAllQuotes_Load(object sender, EventArgs e)
        {

        }
    }
}
