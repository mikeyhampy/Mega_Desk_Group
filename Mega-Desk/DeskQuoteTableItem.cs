using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mega_Desk_Hampton
{
    public class DeskQuoteTableItem
    {
        public string Customer_Name { get; set; }
        public DateTime Quote_Date { get; set; }
        public int Desk_Width { get; set; }
        public int Desk_Depth { get; set; }

        public string Desktop_Material { get; set; }
        public decimal Price_Quote { get; set; }
    }
}
