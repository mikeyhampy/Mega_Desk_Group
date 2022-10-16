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
    public partial class SearchQuotes : Form
    {
        private List<DeskQuote> quoteList = new List<DeskQuote>();
        private string DesktopMaterialSelectedValue;
        
        public SearchQuotes()
        {
            InitializeComponent();
            List<DesktopMaterial> materials = Enum.GetValues(typeof(DesktopMaterial)).Cast<DesktopMaterial>().ToList();
            comboBoxForSearch.DataSource = materials;

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

        private void SearchQuotes_FormClosed(object sender, FormClosedEventArgs e)
        {
            var mainMenu = (MainMenu)Tag;
            mainMenu.Show();
        }

        private void SearchQuotes_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxForSearch_SelectedValueChanged(object sender, EventArgs e)
        {

            DesktopMaterialSelectedValue = comboBoxForSearch.Text;

            List<DeskQuoteTableItem> foundDeskQuotes = new List<DeskQuoteTableItem>();

            var i = 0;
            foreach (DeskQuote deskQuote in quoteList)
            {
                //MessageBox.Show(deskQuote.FinalPrice.ToString());
                if (DesktopMaterialSelectedValue == deskQuote.surfaceMaterial)
                {

                   

                    DeskQuoteTableItem deskQuoteTableItem = new DeskQuoteTableItem();
                    foundDeskQuotes.Add(deskQuoteTableItem);

                    
                    //MessageBox.Show(deskQuote.surfaceMaterial);
                    foundDeskQuotes[i].Customer_Name = deskQuote.CustomerName;
                    foundDeskQuotes[i].Quote_Date = DateTime.Now;
                    foundDeskQuotes[i].Desk_Width = deskQuote.Width;
                    foundDeskQuotes[i].Desk_Depth = deskQuote.Depth;
                    foundDeskQuotes[i].Desktop_Material = deskQuote.surfaceMaterial;
                    foundDeskQuotes[i].Price_Quote = (decimal)deskQuote.FinalPrice;

                    
                    i++;
                }                
                //dataGridViewForSearch.Refresh();
            }
            dataGridViewForSearch.DataSource = foundDeskQuotes;
        }
    }
}
