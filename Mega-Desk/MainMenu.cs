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
    public partial class MainMenu : Form
    {
        private readonly DeskQuote deskQuote = new DeskQuote();
        private List<DeskQuote> quoteList = new List<DeskQuote>();
        public MainMenu()
        {
            InitializeComponent();

            string objData = "";
            IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);
            if (isoStore.FileExists("quotes.json"))
            {
                using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("quotes.json", FileMode.Open, isoStore))
                {
                    using (StreamReader reader = new StreamReader(isoStream))
                    {
                        objData = reader.ReadToEnd();
                        Console.WriteLine(objData);
                        string objDataSanitized = Regex.Replace(objData, @"\t|\n|\r", "");
                        if (objDataSanitized != "Nothing in this file")
                        {
                            quoteList = JsonConvert.DeserializeObject<List<DeskQuote>>(objData);
                        }
                    }
                }
            } else
            {
                using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("quotes.json", FileMode.CreateNew, isoStore))
                {
                    using (StreamWriter writer = new StreamWriter(isoStream))
                    {
                        writer.WriteLine("Nothing in this file");
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Add_New_Quote_Click(object sender, EventArgs e)
        {
            AddQuote addQuote = new AddQuote(deskQuote);
            addQuote.Tag = this;
            addQuote.Show(this);
            Hide();
        }

        private void View_Quotes_Click(object sender, EventArgs e)
        {
            ViewAllQuotes viewAllQuotes = new ViewAllQuotes();
            viewAllQuotes.Tag = this;
            viewAllQuotes.Show(this);
            Hide();
        }
        private void Search_Quotes_Click(object sender, EventArgs e)
        {
            SearchQuotes searchQuotes = new SearchQuotes();
            searchQuotes.Tag = this;
            searchQuotes.Show(this);
            Hide();
        }

        private void Exit(object sender, EventArgs e)
        {
            Close();
        }
    }
}
