using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Mega_Desk_Hampton
{
    public class DeskQuote : Desk
    {
        // gets path from the "bin/debug" folder
        public const string RushPriceFile = "rushOrderPrices.txt";

        public const int BasePrice = 200;
        public const int CostPerIn = 1;
        public const int CostPerDrawer = 50;
        public int[,] RushPrice = new int[3,3];
        public DateTime quoteDate = DateTime.Now;

        // get from user
        public string CustomerName;
        public int DaysShip;

        // calculate
        public int ShipPrice;
        public int SurfaceMaterialPrice;
        public int SurfaceAreaPrice;
        public int DrawerCost;
        public int FinalPrice;

        // calculate shipping cost
        public void CalcShippingCost()
        {
            int row = 0;
            int column = 0;
            
            
            var lines = File.ReadLines(RushPriceFile);

            foreach (var line in lines)
            {
                int lineInt = int.Parse(line.Trim());
                RushPrice[row,column] = lineInt;
                column++;
                if (column == 3)
                {
                    row++;
                    column = 0;
                }
            }


            // check base shipping cost by day
            // check for surface area cost added

            // 7 day shipping
            if (DaysShip == 7)
            {
                row = 2;
            }

            // 5 day shipping
            else if (DaysShip == 5)
            {
                row = 1;
            }

            // 3 day shipping
            else if (DaysShip == 3)
            {
                row = 0;
            }

            // take surface area  into account
            if (SurfaceArea > 2000)
            {
                column = 2;
            }
            else if (SurfaceArea >= 1000)
            {
                column = 1;
            }
            else
            {
                column = 0;
            }
            
            // output shipping price
            if (DaysShip == 14)
            {
                ShipPrice = 0;
            }
            else
            {
                ShipPrice = RushPrice[row, column];
            }
        }

        // calc surface cost
        public void CalcSurfacePrice()
        {
            SurfaceMaterialPrice = surfaceMaterials[surfaceMaterial];
        }

        // Calc Drawer Price
        public void CalcDrawerPrice()
        {
            DrawerCost = CostPerDrawer * DrawersNumber;
        }

        // Calc price per square in.
        public void CalcSquarePrice()
        {
            if (SurfaceArea > 1000)
            {
                SurfaceAreaPrice = (SurfaceArea - 1000) * CostPerIn;
            }
            else
            {
                SurfaceAreaPrice = 0;
            }
        }

        // Calc total Price
        public void CalcTotalPrice()
        {
            // run to get surface area
            CalcSurfaceArea();

            // calculate all costs
            CalcShippingCost();
            CalcSurfacePrice();
            CalcDrawerPrice();
            CalcSquarePrice();

            // calc total or final cost
            FinalPrice = BasePrice + ShipPrice + SurfaceMaterialPrice + DrawerCost + SurfaceAreaPrice;
        }

        public override string ToString()
        {
            // choose any format that suits you and display what you like
            return $"Name: {CustomerName} - Total: {FinalPrice} - Date: {quoteDate}";
        }
    }
}
