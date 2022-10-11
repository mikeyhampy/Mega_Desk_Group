using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mega_Desk_Hampton
{
    public class DeskQuote : Desk
    {
        public const int BasePrice = 200;
        public const int CostPerIn = 1;
        public const int CostPerDrawer = 50;

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
            int dayCost = 0;
            int surfaceCost = 0;


            // check base shipping cost by day
            // check for surface area cost added

            // standard shipping (14 day)
            if (DaysShip == 14)
            {
                dayCost = 0;
                surfaceCost = 0;
            }

            // 7 day shipping
            else if (DaysShip == 7)
            {
                dayCost = 30;
                if (SurfaceArea > 2000)
                {
                    surfaceCost = 10;
                } else if (SurfaceArea >= 1000)
                {
                    surfaceCost = 5;
                }

            }

            // 5 day shipping
            else if (DaysShip == 5)
            {
                dayCost = 40;
                if (SurfaceArea > 2000)
                {
                    surfaceCost = 20;
                }
                else if (SurfaceArea >= 1000)
                {
                    surfaceCost = 10;
                }
            }

            // 3 day shipping
            else if (DaysShip == 3)
            {
                dayCost = 60;
                if (SurfaceArea > 2000)
                {
                    surfaceCost = 20;
                }
                else if (SurfaceArea >= 1000)
                {
                    surfaceCost = 10;
                }
            }
            ShipPrice = dayCost + surfaceCost;
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
    }
}
