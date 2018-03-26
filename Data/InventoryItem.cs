using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class InventoryItem
    {
        public Cuir Nom { get; set; }
        public int Quantité { get; set; }

        public InventoryItem(Cuir nom, int quantité)
        {
            Nom = nom;
            Quantité = quantité;
        }
    }
}
