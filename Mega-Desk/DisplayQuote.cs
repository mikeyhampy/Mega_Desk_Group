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
    public partial class DisplayQuote : Form
    {
        public DeskQuote __deskQuote;
        private List<DeskQuote> quoteList = new List<DeskQuote>();
        public DisplayQuote(DeskQuote _deskquote)
        {
            __deskQuote = _deskquote;
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
            quoteList.Add(__deskQuote);
            var convertedJson = JsonConvert.SerializeObject(quoteList, Formatting.Indented);

            IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);
            using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("quotes.json", FileMode.Create, isoStore))
            {
                using (StreamWriter writer = new StreamWriter(isoStream))
                {
                    writer.WriteLine(convertedJson);
                }
            }
            var addQuote = (AddQuote)Tag;
            addQuote.Show();
            Close();

        }
    }
}
