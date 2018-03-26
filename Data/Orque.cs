using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Orque : Monstre
    {
        public new int LootCuir = 0;
        public override int Force
        {
            get { return base.Force + 1; }
        }
        public Orque() : base()
        {
            De Dice = new De(6);
            LootGold = Dice.Lancer();
        }
    }
}
