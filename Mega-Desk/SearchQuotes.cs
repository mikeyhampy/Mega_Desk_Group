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
using System.Text.RegularExpressions; //https://stackoverflow.com/questions/4140723/how-to-remove-new-line-characters-from-a-string

namespace Mega_Desk_Hampton
{
    public partial class SearchQuotes : Form
    {
        private List<DeskQuote> quoteList = new List<DeskQuote>();
        public SearchQuotes()
        {
            InitializeComponent();

            string objData = "";
            IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);
            using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("quotes.json", FileMode.Open, isoStore))
            {
                using (StreamReader reader = new StreamReader(isoStream))
                {
                    objData = reader.ReadToEnd();
                    string objDataSanitized = Regex.Replace(objData, @"\t|\n|\r", "");
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

        private void SearchQuotes_FormClosed(object sender, FormClosedEventArgs e)
        {
            var mainMenu = (MainMenu)Tag;
            mainMenu.Show();
        }

        private void SearchQuotes_Load(object sender, EventArgs e)
        {

        }
    }
}
