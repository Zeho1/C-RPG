using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Portal
    {
        public int CoordX { get; set; }
        public int CoordY { get; set; }

        public Portal(int coordX, int coordY)
        {
            CoordX = coordX;
            CoordY = coordY;
        }

        public void TransfertVersForet(Player Jacob)
        {
            //Jacob.CurrentLocation = Town;
            Jacob.CoordX = 12;
            Jacob.CoordY = 7;
        }
        public void TransfertVersVillage(Player Jacob)
        {
            Jacob.CoordX = 1;
            Jacob.CoordY = 6;
        }
    }

    
}
