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
    public partial class MainMenu : Form
    {
        private readonly DeskQuote deskQuote = new DeskQuote();

        public MainMenu()
        {
            InitializeComponent();
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
