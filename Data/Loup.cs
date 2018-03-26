using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Loup : Monstre
    {
        public new int LootGold = 0;
        public Loup() : base()
        {
            De D = new De(4);
            LootCuir = D.Lancer();
        }
    }
}
