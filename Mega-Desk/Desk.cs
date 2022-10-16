using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Mega_Desk_Hampton
{
    public enum DesktopMaterial
    {
        Oak,
        Laminate,
        Pine,
        Rosewood,
        Veneer
    }
    public class Desk
    {
        public int Width;
        public int Depth;
        public int SurfaceArea;
        public int DrawersNumber;
        public string surfaceMaterial;
        public readonly Dictionary<string, int> surfaceMaterials =
        new Dictionary<string, int>
        {
            {"Laminate", 100},
            {"Oak", 200},
            {"Rosewood", 300},
            {"Veneer", 125},
            {"Pine", 50}
        };
        public void CalcSurfaceArea()
        {
            SurfaceArea = Width * Depth;
        }
    }
}
